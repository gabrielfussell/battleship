using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// A location on a ship that is available to be hit.
    /// </summary>
    internal class WeakPoint : Point
    {
        /// <summary>
        /// A reference to the ship that the WeakPoint is located on.
        /// </summary>
        public IShip ContainingShip { get; private set; }

        /// <summary>
        /// How to display the WeakPoint on the grid in the console.
        /// </summary>
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

        /// <summary>
        /// Create a WeakPoint on a ship from an X, Y point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="containingShip">A reference to the ship that the WeakPoint is located on.</param>
        public WeakPoint(int x, int y, IShip containingShip) : base(x, y)
        {
            ContainingShip = containingShip;
        }

        /// <summary>
        /// Create a WeakPoint on a ship from a Coordinate.
        /// </summary>
        /// <param name="coordinate">A Coordinate object.</param>
        /// <param name="containingShip">A reference to the ship that the WeakPoint is located on.</param>
        public WeakPoint(Coordinate coordinate, IShip containingShip) : base(coordinate.X, coordinate.Y)
        {
            ContainingShip = containingShip;
        }

        /// <summary>
        /// Mark the WeakPoint as hit and decrement the containing ship's health.
        /// </summary>
        /// <exception cref="Exception">Thrown when the WeakPoint has already been hit.</exception>
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
