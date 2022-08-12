using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Ships
{
    internal class Destroyer : Ship
    {
        public override string ShortName { get; } = "D";
        public override int Size { get; protected set; } = 2;
    }
}
