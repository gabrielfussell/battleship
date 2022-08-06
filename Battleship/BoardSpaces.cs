using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class BoardSpaces
    {
        private WeakPoint[,] Spaces { get; set; }
        /*
        YTransform is needed because the Spaces array accesses items
        in Y, X order, starting from the top rather than the bottom.
        This array is used to allow the user to use standard X, Y
        coordinates.
        */
        private int[] YTransform { get; set; }

        public BoardSpaces(int boardSize)
        {
            Spaces = new WeakPoint[boardSize, boardSize];

            YTransform = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(YTransform);
        }

        public WeakPoint GetSpace(int x, int y)
        {
            return Spaces[YTransform[y], x];
        }

        public WeakPoint GetSpace(Point p)
        {
            return Spaces[YTransform[p.Y], p.X];
        }

        public void SetSpace(WeakPoint weakPoint)
        {
            if(!IsSpaceAvailable(weakPoint))
            {
                throw new ArgumentException("This space is already occupied by another ship");
            }

            Spaces[YTransform[weakPoint.Y], weakPoint.X] = weakPoint;
        }

        public bool IsSpaceAvailable(Point p)
        {
            return GetSpace(p) == null;
        }
    }
}
