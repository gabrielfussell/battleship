using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal interface IShip
    {
        /// <summary>
        /// The full name of the ship type.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A single character representing the ship type.
        /// </summary>
        string ShortName { get; }

        /// <summary>
        /// Whether the ship has sank. True when all weakpoint have been hit.
        /// </summary>
        bool HasSank { get; }

        /// <summary>
        /// The number of spaces on a board that a ship occupies.
        /// </summary>
        int Size { get; }

        int Health { get; }

        /// <summary>
        /// The horizontal or vertical orientation of a ship.
        /// </summary>
        ShipOrientation Orientation { get; }

        /// <summary>
        /// A list of the points where a ship may be hit.
        /// </summary>
        List<WeakPoint> WeakPoints { get; }

        /// <summary>
        /// Add a ship to a board using a coordinate.
        /// </summary>
        /// <param name="oceanBoard">The ocean board to place the ship onto.</param>
        /// <param name="proposedOrientation">The horizontal or vertical orientation of the ship.</param>
        /// <param name="proposedLocation">The location of the ship as a coordinate.</param>
        void Place(Board oceanBoard, ShipOrientation proposedOrientation, Coordinate proposedLocation);

        /// <summary>
        /// Add a ship to a board using an X, Y location.
        /// </summary>
        /// <param name="oceanBoard">The ocean board to place the ship onto.</param>
        /// <param name="proposedOrientation">The horizontal or vertical orientation of the ship.</param>
        /// <param name="x">The X coordinate of the ship's location.</param>
        /// <param name="y">The Y coordinate of the ship's location.</param>
        void Place(Board oceanBoard, ShipOrientation proposedOrientation, int x, int y);

        /// <summary>
        /// Decreases a ship's health.
        /// </summary>
        void DecrementHealth();
    }
}
