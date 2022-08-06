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
        public List<WeakPoint> WeakPoints { get; protected set; }
        public ShipOrientation Orientation { get; protected set; }

        public Ship()
        {
            Health = Size;
            WeakPoints = new List<WeakPoint>(Size);
        }

        public void DecrementHealth()
        {
            Health--;
            if (Health <= 0) HasSank = true;
        }

        public bool Place(Board board, ShipOrientation proposedOrientation, Point proposedLocation)
        {

            //Check that starting location is valid
            if(!board.IsPointOnBoard(proposedLocation)) return false;

            List<WeakPoint> weakPoints = new List<WeakPoint>(Size);

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
                    weakPoints.Add(new WeakPoint(proposedLocation.X, proposedLocation.Y, this));
                }
                else
                {
                    if(proposedOrientation == ShipOrientation.Horizontal)
                    {
                        //increment X each time. Y stays the same for all points.
                        weakPoints.Add(new WeakPoint(proposedLocation.X + i, proposedLocation.Y, this));   
                    }
                    else if(proposedOrientation == ShipOrientation.Vertical)
                    {
                        //decrement Y each time. X stays the same for all points.
                        weakPoints.Add(new WeakPoint(proposedLocation.X, proposedLocation.Y - i, this));
                    }

                    //Make sure the point we just created is on the board and not already occupied
                    if (
                        !(
                            board.IsPointOnBoard(weakPoints[i]) 
                            && board.BoardSpaces.IsSpaceAvailable(weakPoints[i])
                          )
                        ) return false;
                }
            }

            //Now that we know all the locations are valid we can populate the WeakPoints property and
            //put a reference to the WeakPoint objects in the BoardSpaces array
            WeakPoints = weakPoints;

            foreach (WeakPoint wp in WeakPoints)
            {
                board.BoardSpaces.SetSpace(wp);
            }

            Orientation = proposedOrientation;

            return true;
        }
    }
}
