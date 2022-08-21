using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Board
    {
        
        public int Size { get; protected set; }
        public BoardSpaces BoardSpaces { get; protected set; }
        private string _emptyCell { get; } = "|___";

        public Board(int size)
        {
            Size = size + 1; //add one to account for first row and column being labels
            BoardSpaces = new BoardSpaces(Size);
        }

        /* Empty board layout:

        |___|_1_|_2_|_3_|_4_|_5_|
        |_A_|___|___|___|___|___|
        |_B_|___|___|___|___|___|
        |_C_|___|___|___|___|___|
        |_D_|___|___|___|___|___|
        |_E_|___|___|___|___|___|
         */

        //Should this just loop through BoardSpaces instead?
        public void DisplayBoard(CoordinateMap coordinateMap)
        {
            string boardToDisplay = "";
            for(int y = 0; y < Size; y++) //rows are created bottom to top
            {
                string row = "";

                for(int x = 0; x < Size; x++) //cells
                {
                    if(y == Size - 1) //top row
                    {
                        if(x == 0)
                        {
                            row += _emptyCell;
                        }
                        else
                        {
                            row += CreatePopulatedCell(x.ToString());
                        } 
                    }
                    else if(y < Size - 1 && x == 0)
                    {
                        /*
                         First column in all rows other than the top.
                         Convert the row number to a character and use that as the label.
                         */
                        char letter = coordinateMap.GetValueAtIndex(y);
                        row += CreatePopulatedCell(letter.ToString());
                    }
                    else
                    {
                        //Otherwise check for data in board array at the coordinate
                        Point p = BoardSpaces.GetSpace(x, y);
                        
                        if (p == null)
                        {
                            row += _emptyCell;
                        }
                        else
                        {
                            row += CreatePopulatedCell(p.MapLabel); 
                        }
                        
                    }
                }

                row += "|\n";
                boardToDisplay = row + boardToDisplay;
            }
            Console.WriteLine(boardToDisplay);
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

        public bool IsOnBoard(IPoint point)
        {
            /*
             The first row and first column are reserved for labels and aren't
             available to place points on.
             */
            return point.X > 0 && point.X < Size
                && point.Y >= 0 && point.Y <= Size - 2;
        }
    }
}
