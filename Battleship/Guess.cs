using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Guess : Point
    {
        public override string MapLabel
        {
            get
            {
                if(IsHit)
                {
                    return "Y";
                }
                else
                {
                    return "N";
                }
            }
        }

        public Guess(int x, int y) : base(x, y)
        {

        }

        public Guess(Coordinate coordinate) : base(coordinate.X, coordinate.Y)
        {

        }

        public override void Hit()
        {
            IsHit = true;
        }

        public void Place(Board targetBoard)
        {
            try
            {
                targetBoard.BoardSpaces.SetSpace(this);
            }
            catch (Exception e)
            {
                throw new Exception("You have already guessed this location", e);
            }
            
        }
    }
}
