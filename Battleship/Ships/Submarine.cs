using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Ships
{
    internal class Submarine : Ship
    {
        public override string MapLabel { get; } = "S";
        public override int Size { get; protected set; } = 3;
    }
}
