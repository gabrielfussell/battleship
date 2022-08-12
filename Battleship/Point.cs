using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal abstract class Point : IPoint
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public bool IsHit { get; protected set; } = false;
        public abstract string MapLabel { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {

        }

        //Hit() is what modifies the IsHit property
        public abstract void Hit();

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }

        /*
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
        */
    }
}
