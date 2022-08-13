using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Carrier : Ship
    {
        public override string Name { get; } = "Carrier";
        public override string ShortName { get; } = "C";
        public override int Size { get; protected set; } = 5;
    }
}
