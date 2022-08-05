using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point) || obj is null) return false;

            Point that = obj as Point;
            return this.X == that.X && this.Y == that.Y;
        }

        public override int GetHashCode()
        {
            return (X.GetHashCode() * 31) + Y.GetHashCode();
        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
    }
}
