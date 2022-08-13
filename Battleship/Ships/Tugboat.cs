using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Tugboat : Ship
    {
        public override string Name { get; } = "Tugboat";
        public override string ShortName { get; } = "T";
        public override int Size { get; protected set; } = 1;
    }
}
