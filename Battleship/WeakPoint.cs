using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class WeakPoint
    {
        public Point Location { get; private set; }
        public bool IsHit { get; private set; } = false;
        public IShip ContainingShip { get; private set; }

        public WeakPoint(Point location, IShip containingShip)
        {
            Location = location;
            ContainingShip = containingShip;
        }
    }
}
