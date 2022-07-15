using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal interface IShip
    {
        bool HasSank { get; }
        int Size { get; }
        int Health { get; }
        ShipOrientation Orientation { get; }
        List<PegSlot> Pegs { get; }
        void Hit(Point location);
    }
}
