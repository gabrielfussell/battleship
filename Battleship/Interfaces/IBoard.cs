using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal interface IBoard
    {
        int Size { get; }
        BoardSpaces BoardSpaces { get; }
        void DisplayBoard();
        bool IsOnBoard(IPoint point);
    }
}
