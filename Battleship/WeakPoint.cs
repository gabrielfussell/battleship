using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class WeakPoint : Point
    {
        public bool IsHit { get; private set; } = false;
        public IShip ContainingShip { get; private set; }

        public WeakPoint(int x, int y, IShip containingShip) : base(x, y)
        {
            ContainingShip = containingShip;
        }

        public void Hit()
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
