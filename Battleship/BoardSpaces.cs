using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class BoardSpaces
    {
        private IShip[,] Spaces { get; set; }
        /*
        YTransform is needed because the Spaces array accesses items
        in Y, X order, starting from the top rather than the bottom.
        This array is used to allow the user to use standard X, Y
        coordinates.
        */
        private int[] YTransform { get; set; }

        public BoardSpaces(int boardSize)
        {
            Spaces = new IShip[boardSize, boardSize];

            YTransform = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(YTransform);
        }

        public IShip GetSpace(int x, int y)
        {
            return Spaces[YTransform[y], x];
        }

        public IShip GetSpace(Point p)
        {
            return Spaces[YTransform[p.Y], p.X];
        }

        public void SetSpace(IShip ship, int x, int y)
        {
            if(!IsSpaceAvailable(x, y))
            {
                throw new ArgumentException("This space is already occupied by another ship");
            }

            Spaces[YTransform[y], x] = ship;
        }

        public void SetSpace(IShip ship, Point p)
        {
            if(!IsSpaceAvailable(p))
            {
                throw new ArgumentException("This space is already occupied by another ship");
            }

            Spaces[YTransform[p.Y], p.X] = ship;
        }

        public bool IsSpaceAvailable(Point p)
        {
            return GetSpace(p) == null;
        }

        public bool IsSpaceAvailable(int x, int y)
        {
            return GetSpace(x, y) == null;
        }
    }
}
