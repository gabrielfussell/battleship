using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal interface IShip
    {
        string Name { get; }
        string ShortName { get; }
        bool HasSank { get; }
        int Size { get; }
        int Health { get; }
        ShipOrientation Orientation { get; }
        List<WeakPoint> WeakPoints { get; }
        void Place(Board board, ShipOrientation proposedOrientation, Coordinate proposedLocation);
        void Place(Board oceanBoard, ShipOrientation proposedOrientation, int x, int y);
        void DecrementHealth();
    }
}
