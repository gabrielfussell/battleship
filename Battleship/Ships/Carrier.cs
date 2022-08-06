using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Ships
{
    internal class Carrier : Ship
    {
        public override string MapLabel { get; } = "C";
        public override int Size { get; protected set; } = 5;
    }
}
