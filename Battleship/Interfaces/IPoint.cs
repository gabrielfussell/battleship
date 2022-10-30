using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Interface defining an X, Y point
    /// </summary>
    internal interface IPoint
    {
        int X { get; }
        int Y { get; }
    }
}
