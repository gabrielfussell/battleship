using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// A location in the BoardSpaces array.
    /// </summary>
    internal abstract class Point : IPoint
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        /// <summary>
        /// Whether the point on a ship has been hit or whether a guess was successful.
        /// </summary>
        public bool IsHit { get; protected set; } = false;

        /// <summary>
        /// How to display the point on the grid in the console.
        /// </summary>
        public abstract string MapLabel { get; }

        /// <summary>
        /// Create a new Point object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Mark the point on a ship as hit or a guess as successful.
        /// </summary>
        public abstract void Hit();
    }
}
