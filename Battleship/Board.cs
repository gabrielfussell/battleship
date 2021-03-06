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
        public List<char> CoordianteMap { get; set; } = new List<char>();
        //change to a more general class than Ship. The Board subclass Target will need to hold pegs.
        public Ship[,] board { get; set; }
        private string _emptyCell { get; } = "|___";

        public Board(int size)
        {
            Size = size + 1; //add one to account for first row and column being labels
            CoordianteMap = CreateCoordinateMap(Size);
            board = new Ship[Size,Size];
        }

        /* Empty board layout:

        |___|_1_|_2_|_3_|_4_|_5_|
        |_A_|___|___|___|___|___|
        |_B_|___|___|___|___|___|
        |_C_|___|___|___|___|___|
        |_D_|___|___|___|___|___|
        |_E_|___|___|___|___|___|
         */

        public void DisplayBoard()
        {
            for(int i = 0; i < Size; i++) //rows
            {
                string row = "";

                for(int ii = 0; ii < Size; ii++) //cells
                {
                    if(i == 0) //first row
                    {
                        if(ii == 0)
                        {
                            row += _emptyCell;
                        }
                        else
                        {
                            row += CreatePopulatedCell(ii.ToString());
                        } 
                    }
                    else if(i > 0 && ii == 0)
                    {
                        /*
                         First column in all rows past the first.
                         Convert the row number to a character and use that as the label.
                         */
                        char letter = (char)(i + 64);
                        row += CreatePopulatedCell(letter.ToString());
                    }
                    else
                    {
                        //Otherwise check for an item in board array at the coordinate
                        if (board[i, ii] == null)
                        {
                            row += _emptyCell;
                        }
                        else
                        {
                            //display the ship type abbreviation and whether it's been hit
                        }
                        
                    }
                }

                row += "|";
                Console.WriteLine(row);
            }
            Console.WriteLine();
        }

        private string CreatePopulatedCell(string value)
        {
            // Empty: |___ Populated: |_S_ or |_SX
            if(value.Length > 2)
            {
                throw new ArgumentException("value of a cell cannot be more than 2 characters long");
            }

            string cell = "|_" + value;
            if (value.Length == 1) cell += "_";
            return cell;
        }

        public bool IsOnBoard(string coordinate)
        {
            Point p = CoordinateToPoint(coordinate);
            return IsPointOnBoard(p);
        }

        public bool IsPointOnBoard(Point point)
        {
            /*
             The first row and first column are reserved for labels and aren't
             available to place points on.
             */
            return point.X > 0 && point.X <= Size
                && point.Y > 0 && point.Y <= Size;
        }

        private Point CoordinateToPoint(string coordinate)
        {
            if(coordinate.Length != 2)
            {
                throw new ArgumentException("coordinate must have a length of two characters.");
            }

            int x = CoordianteMap.IndexOf(char.Parse(coordinate.Substring(0, 1)));
            int y = Int32.Parse(coordinate.Substring(1, 1));
            return new Point(x, y);
        }

        private List<char> CreateCoordinateMap(int boardSize)
        {
            /*
             Returns a list of letters in reverse order equal to the size of the board.
                EX: [E,D,C,B,A]
             This is to assist with converting coordinates in the format "B3" to a traditional X,Y point.
             The first cell on the board is not available, so only create for boardSize - 1.
            */
            List<char> coordinateMap = new List<char>(boardSize);
            for (int i = 0; i < boardSize - 1; i++)
            {
                coordinateMap.Add((char)(i + 65));
            }

            coordinateMap.Reverse();
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
