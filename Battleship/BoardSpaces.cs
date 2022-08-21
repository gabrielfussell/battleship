using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class BoardSpaces
    {
        private Point[,] Spaces { get; set; }
        /*
        YTransform is needed because the Spaces array accesses items
        in Y, X order, starting from the top rather than the bottom.
        This array is used to allow the user to use standard X, Y
        coordinates.
        */
        private int[] YTransform { get; set; }

        public BoardSpaces(int boardSize)
        {
            Spaces = new Point[boardSize, boardSize];

            YTransform = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(YTransform);
        }

        public Point GetSpace(int x, int y)
        {
            return Spaces[YTransform[y], x];
        }

        public Point GetSpace(Point p)
        {
            return Spaces[YTransform[p.Y], p.X];
        }

        public void SetSpace(Point p)
        {
            if(!IsSpaceAvailable(p))
            {
                throw new ArgumentException("This space is already occupied");
            }

            Spaces[YTransform[p.Y], p.X] = p;
        }

        public bool IsSpaceAvailable(Point p)
        {
            try
            {
                return GetSpace(p) == null;
            }
            catch (Exception e)
            {
                throw new Exception("Space does not exist", e);
            }
            
        }
    }
}
