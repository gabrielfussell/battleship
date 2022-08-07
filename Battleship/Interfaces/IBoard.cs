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
        List<char> CoordinateMap { get; }
        BoardSpaces BoardSpaces { get; }
        void DisplayBoard();
        bool IsCoordinateOnBoard(string coordinate);
        bool IsPointOnBoard(Point point);
        Point CoordinateToPoint(string coordinate);
    }
}
