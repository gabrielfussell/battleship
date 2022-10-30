using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// The grid a player uses to track ships and guesses.
    /// </summary>
    /// <remarks>
    /// Holds either ship weakpoints if an ocean board or guesses if a target board.
    /// </remarks>
    internal class Board
    {
        /// <summary>
        /// The size of the square board.
        /// </summary>
        /// <remarks>
        /// The first row and first column are always for labels.
        /// </remarks>
        public int Size { get; protected set; }

        /// <summary>
        /// The contents of the board.
        /// </summary>
        public BoardSpaces BoardSpaces { get; protected set; }
        private string _emptyCell { get; } = "|___";

        /// <summary>
        /// Create an emplty board.
        /// </summary>
        /// <param name="size">The size of one side of the square of playable spaces.</param>
        /// <remarks>
        /// Can become either an ocean board or a target board depending on what is
        /// stored in the BoardSpaces array.
        /// </remarks>
        public Board(int size)
        {
            /*
            The boardspaces array is created for the entire board, including the first row
            and column which are only for labels and not part of the playable area. The
            IsOnBoard methods serve to restrive players to only the spaces in the playable area.
            */
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

        /// <summary>
        /// Write the board to the console.
        /// </summary>
        /// <param name="coordinateMap"></param>
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

        /// <summary>
        /// Represents the a space on the board as displayed in the console.
        /// </summary>
        /// <param name="value">The contents of the cell.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when <c>value</c> is too long to fit in the cell.</exception>
        private string CreatePopulatedCell(string value)
        {
            // Empty: |___ Populated: |_S_ if hit or |_SX if unhit
            if(value.Length > 2)
            {
                throw new ArgumentException("value of a cell cannot be more than 2 characters long");
            }

            string cell = "|_" + value;
            if (value.Length == 1) cell += "_";
            return cell;
        }

        /// <summary>
        /// Whether the IPoint object is within the bounds of the playable area of the board.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>True if the point is within bounds, otherwise false.</returns>
        public bool IsOnBoard(IPoint point)
        { 
            return IsOnBoardLogic(point.X, point.Y);
        }

        /// <summary>
        /// Whether the X, Y pair is within the bounds of the playable area of the board.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if the X, Y pair is within bounds, otherwise false.</returns>
        public bool IsOnBoard(int x, int y)
        {
            return IsOnBoardLogic(x, y);
        }

        private bool IsOnBoardLogic(int x, int y)
        {
            /*
             The first row and first column are reserved for labels and aren't
             available to place points on.
             */
            return x > 0 && x < Size
                && y >= 0 && y <= Size - 2;
        }
    }
}
