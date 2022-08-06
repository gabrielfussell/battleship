using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal interface IShip
    {
        string MapLabel { get; }
        bool HasSank { get; }
        int Size { get; }
        int Health { get; }
        ShipOrientation Orientation { get; }
        List<WeakPoint> WeakPoints { get; }
        bool Place(Board board, ShipOrientation proposedOrientation, Point proposedLocation);
    }
}
