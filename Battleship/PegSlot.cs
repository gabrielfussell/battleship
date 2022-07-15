using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class PegSlot
    {
        public Point Location { get; private set; }
        public bool IsHit { get; private set; } = false;

        public PegSlot(Point location)
        {
            Location = location;
        }
    }
}
