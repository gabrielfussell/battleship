using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Ships
{
    internal class Battleship : Ship
    {
        public override string MapLabel { get; } = "B";
        public override int Size { get; protected set; } = 4;
    }
}
