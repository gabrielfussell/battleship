using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Board
    {
        
        public int Size { get; private set; }
        private static char[]? _coordianteMap { get; set; }

        public Board(int size)
        {
            Size = size;
            _coordianteMap = CreateCoordinateMap(size);
        }

        /* Empty board layout:

        |___|_1_|_2_|_3_|_4_|_5_|
        |_A_|___|___|___|___|___|
        |_B_|___|___|___|___|___|
        |_C_|___|___|___|___|___|
        |_D_|___|___|___|___|___|
        |_E_|___|___|___|___|___|
         */
        public bool OnBoard(Point point)
        {
            /*
             The first row and first column shown above are only added visually in the console.
             They are not part of the board that the class uses.
             */
            return point.X >= 0 && point.X < Size
                && point.Y >= 0 && point.Y < Size;
        }

        public bool OnBoard(string coordinate)
        {
            //take in a coordinate in the format "B3" from the console
            return true;
        }

        //create another OnBoard that takes in a point?

        private Point CoordinateToPoint(string coordinate)
        {
            int x = Array.IndexOf(_coordianteMap, coordinate);
            int y = Int32.Parse(coordinate.Substring(1, 1));
            return new Point(x, y);
        }

        private char[] CreateCoordinateMap(int boardSize)
        {
            /*
             Returns an array of letters in reverse order equal to the size of the board.
                EX: [E,D,C,B,A]
             This is to assist with converting coordinates in the format "B3" to a traditional X,Y point
            */
            char[] coordinateMap = new char[boardSize];
            for(int i = 0; i < coordinateMap.Length; i++)
            {
                coordinateMap[i] = (char)(i + 65);
            }

            Array.Reverse(coordinateMap);
            return coordinateMap;
        }

        ////Converts a letter of the alphabet to a number, starting with A = 0, B = 1, C = 2, etc.
        //private int ConvertToNumber(char c) => Convert.ToInt32(c) - 65;
        //private int ConvertToNumber(string s)
        //{
        //    if(s.Length != 1)
        //    {
        //        throw new ArgumentException("Input string can only be 1 character long");
        //    }
        //    else
        //    {
        //        char c = Char.Parse(s);
        //        return ConvertToNumber(c);
        //    }
        //}
    }
}
