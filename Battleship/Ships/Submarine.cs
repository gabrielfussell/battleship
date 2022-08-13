using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Submarine : Ship
    {
        public override string Name { get; } = "Submarine";
        public override string ShortName { get; } = "S";
        public override int Size { get; protected set; } = 3;
    }
}
