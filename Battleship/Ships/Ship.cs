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
        public abstract string Name { get; }
        public abstract string ShortName { get; }
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

        public void Place(Board oceanBoard, ShipOrientation proposedOrientation, Coordinate proposedLocation)
        {

            //Check that starting location is valid
            if(!oceanBoard.IsOnBoard(proposedLocation))
            {
                throw new ArgumentException("Starting location is not on the board");
            }

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
                    if (!oceanBoard.IsOnBoard(weakPoints[i]))
                    {
                        throw new Exception("Ship does not fit in the spaces specified");
                    }
                    else if(oceanBoard.BoardSpaces.IsSpaceOccupied(weakPoints[i]))
                    {
                        throw new Exception("One or more spaces is already occupied by another ship");
                    }
                }
            }

            //Now that we know all the locations are valid we can populate the WeakPoints property and
            //put a reference to the WeakPoint objects in the BoardSpaces array
            WeakPoints = weakPoints;

            foreach (WeakPoint wp in WeakPoints)
            {
                oceanBoard.BoardSpaces.SetSpace(wp);
            }

            Orientation = proposedOrientation;
        }
    }
}
