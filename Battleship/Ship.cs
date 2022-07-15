using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    enum ShipOrientation
    {
        Horizontal,
        Vertical
    }
    abstract class Ship : IShip
    {
        public bool HasSank { get; protected set; } = false;
        public abstract int Size { get; protected set; }
        public int Health { get; protected set; }
        public List<PegSlot> Pegs { get; protected set; }
        public ShipOrientation Orientation { get; protected set; }


        public Ship(int size, ShipOrientation orientation)
        {
            Size = size;
            Health = size;
            Pegs = new List<PegSlot>(size);
            Orientation = orientation;
        }

        public void Hit(Point location)
        {
            //mark the peg slot at that location as hit
            //decrement health
            //if health is zero then set HasSank to true
        }
    }
}
