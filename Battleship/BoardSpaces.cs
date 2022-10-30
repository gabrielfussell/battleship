using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// The spaces that compose the main contents of a board object
    /// </summary>
    internal class BoardSpaces
    {
        /// <summary>
        /// A multi-dimensional array representing all of a board's spaces
        /// </summary>
        private Point[,] Spaces { get; set; }

        /*
        YTransform is an array storing integers between 0 and the
        size of the board, in reverse order.
        
        Thinking of the spaces array as a coordinate plane, the
        standard syntax Spaces[1,4] on a 5x5 grid returns 
        the item from row 1 (Y = 1), column 4 (X = 4) starting from 
        the upper left corner instead of the bottom left.
        
        In a standard coordinate plane this same space is represented
        by (4, 3). The X value remains the same but is listed first
        and the Y value is counted from the bottom instead of the 
        top.

        YTransform allows consumers of the BoardSpaces class to enter
        in a standard X, Y pair and have it automatically converted
        to the format needed to access the expected item in the Point
        array.

        The X coordinate is used as the second number when accessing the
        array, and the Y coordinate is obtained by accessing 
        YTransform[Y coordinate parameter].

        An example of the contents of YTransform for 5x5 grid:
        {5, 4, 3, 2, 1, 0}
        */
        private int[] YTransform { get; set; }

        /// <summary>
        /// Create a BoardSpaces object.
        /// </summary>
        /// <param name="boardSize">The total size of one side of the board, including playable and non-playable spaces.</param>
        public BoardSpaces(int boardSize)
        {
            Spaces = new Point[boardSize, boardSize];

            YTransform = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(YTransform);
        }

        /// <summary>
        /// Return the contents of a space located at an X, Y point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Point GetSpace(int x, int y)
        {
            return Spaces[YTransform[y], x];
        }

        /// <summary>
        /// Return the contents of a space at the location stored in a Point object
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point GetSpace(Point p)
        {
            return Spaces[YTransform[p.Y], p.X];
        }

        /// <summary>
        /// Set the contents of a space at the location stored in a Point object
        /// </summary>
        /// <param name="p"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetSpace(Point p)
        {
            if(IsSpaceOccupied(p))
            {
                throw new ArgumentException("This space is already occupied");
            }

            Spaces[YTransform[p.Y], p.X] = p;
        }

        /// <summary>
        /// Return whether the space at the location stored in a Point object already contains another object.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="Exception">Thrown when the requested space does not exist</exception>
        public bool IsSpaceOccupied(Point p)
        {
            try
            {
                return GetSpace(p) != null;
            }
            catch (Exception e)
            {
                throw new Exception("Space does not exist", e);
            }
            
        }

        /// <summary>
        /// Return whether the space located at an X, Y point already contains another object.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="Exception">Thrown when the requested space does not exist.</exception>
        public bool IsSpaceOccupied(int x, int y)
        {
            try
            {
                return GetSpace(x, y) != null;
            }
            catch(Exception e)
            {
                throw new Exception("Space does not exist", e);
            }
        }
    }
}
