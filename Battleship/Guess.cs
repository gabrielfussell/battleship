using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Stores whether the player's guess of a ship's location was successful.
    /// </summary>
    internal class Guess : Point
    {
        /// <summary>
        /// How to display the guess on the grid in the console.
        /// </summary>
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

        /// <summary>
        /// Create a Guess from an X, Y point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Guess(int x, int y) : base(x, y)
        {

        }

        /// <summary>
        /// Create a Guess from a Coordinate object.
        /// </summary>
        /// <param name="coordinate"></param>
        public Guess(Coordinate coordinate) : base(coordinate.X, coordinate.Y)
        {

        }

        /// <summary>
        /// Mark a guess as successful in hitting an enemy ship.
        /// </summary>
        public override void Hit()
        {
            IsHit = true;
        }

        /// <summary>
        /// Place a guess on the player's target board.
        /// </summary>
        /// <param name="targetBoard">The player's target board.</param>
        /// <exception cref="Exception">Thrown when the target board's space is already occupied by another Guess object.</exception>
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
