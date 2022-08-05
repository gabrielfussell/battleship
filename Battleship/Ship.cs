using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    enum ShipOrientation
    {
        Horizontal,
        Vertical
    }
    abstract class Ship : IShip
    {
        public abstract string MapLabel { get; }
        public bool HasSank { get; protected set; } = false;
        public abstract int Size { get; protected set; }
        public int Health { get; protected set; }
        public List<PegSlot> Pegs { get; protected set; }
        public ShipOrientation Orientation { get; protected set; }

        public Ship()
        {
            Health = Size;
            Pegs = new List<PegSlot>(Size);
        }

        public void Hit(Point location)
        {
            //mark the peg slot at that location as hit
            //decrement health
            //if health is zero then set HasSank to true
        }

        public bool Place(Board board, ShipOrientation proposedOrientation, Point proposedLocation)
        {

            //Check that starting location is valid
            if(!board.IsPointOnBoard(proposedLocation)) return false;

            List<Point> points = new List<Point>(Size);

            /*
             * Because the points are all in a line either the X or Y value will change for each point.
             * Horizontal = increment X
             * Veritcal = decrement Y
             */

            for(int i = 0; i < Size; i++)
            { 
                if (i == 0)
                {
                    //Starting location has already been checked
                    points.Add(proposedLocation);
                }
                else
                {
                    if(proposedOrientation == ShipOrientation.Horizontal)
                    {
                        //increment X each time. Y stays the same for all points.
                        points.Add(new Point(proposedLocation.X + i, proposedLocation.Y));   
                    }
                    else if(proposedOrientation == ShipOrientation.Vertical)
                    {
                        //decrement Y each time. X stays the same for all points.
                        points.Add(new Point(proposedLocation.X, proposedLocation.Y - i));
                    }

                    //Is the point we just created on the board?
                    if (!board.IsPointOnBoard(points[i])) return false;
                }
            }

            //Now that we know all the locations are valid we can populate the Pegs list and
            //put a reference to the ship object in the BoardSpaces array
            foreach(Point p in points)
            {
                Pegs.Add(new PegSlot(p));
                board.BoardSpaces.SetSpace(this, p);
            }

            Orientation = proposedOrientation;

            return true;
        }
    }
}
