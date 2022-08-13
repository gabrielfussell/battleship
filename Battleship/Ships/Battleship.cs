using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Battleship : Ship
    {
        public override string Name { get; } = "Battleship";
        public override string ShortName { get; } = "B";
        public override int Size { get; protected set; } = 4;
    }
}
