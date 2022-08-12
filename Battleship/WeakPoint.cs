using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class WeakPoint : Point
    {
        public IShip ContainingShip { get; private set; }
        public override string MapLabel
        {
            get
            {
                if(IsHit)
                {
                    return ContainingShip.ShortName + "X";
                }
                else
                {
                    return ContainingShip.ShortName;
                }
            }
        }

        public WeakPoint(int x, int y, IShip containingShip) : base(x, y)
        {
            ContainingShip = containingShip;
        }

        public WeakPoint(Coordinate coordinate, IShip containingShip) : base(coordinate.X, coordinate.Y)
        {
            ContainingShip = containingShip;
        }

        public override void Hit()
        {
            if(IsHit == false)
            {
                IsHit = true;
                ContainingShip.DecrementHealth();
            }
            else
            {
                throw new Exception("Weak point can only be hit once.");
            }
        }
    }
}
