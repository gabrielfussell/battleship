using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class CoordinateMap
    {
        /*
        Stores a list of letters in reverse order equal to the size of the board.
        EX: [E,D,C,B,A]
        This is to assist with converting coordinates in the format "B3" to a traditional X,Y point.
        Only needed for the Y value in a point.
        The first cell on the board is not available, so only create for boardSize - 1.
        */
        private List<char> _map { get; set; }
        public CoordinateMap(int size)
        {
            _map = new List<char>(size);
            for(int i = 0; i < size - 1; i++)
            {
                _map.Add((char)(i + 65));
            }

            _map.Reverse();
        }

        public int GetYValue(char character)
        {
            return _map.IndexOf(character);
        }
    }
}
