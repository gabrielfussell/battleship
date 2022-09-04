using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class AI : Player
    {
        private int GameSize { get; set; } //use to assist with getting random X and Y values

        public AI(int gameSize, CoordinateMap coordinateMap, string name) : base(gameSize, coordinateMap, name)
        {
            GameSize = gameSize;
        }

        public override void PlaceShips()
        {
            int i = Random.Next(0, 3);

            //Choose from a set of pre defined ship locations
            if(GameSize == 5)
            {
                switch(i)
                {
                    case 0:
                        Ships[0].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A1", CoordinateMap)); //Carrier 5
                        Ships[1].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("E2", CoordinateMap)); //Battleship 4
                        Ships[2].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("A2", CoordinateMap)); //Cruiser 3
                        Ships[3].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("C3", CoordinateMap)); //Submarine 3
                        Ships[4].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("B4", CoordinateMap)); //Destroyer 2
                        break;
                    case 1:
                        Ships[0].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A2", CoordinateMap)); //Carrier 5
                        Ships[1].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("B4", CoordinateMap)); //Battleship 4
                        Ships[2].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("A3", CoordinateMap)); //Cruiser 3
                        Ships[3].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("C3", CoordinateMap)); //Submarine 3
                        Ships[4].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("B1", CoordinateMap)); //Destroyer 2
                        break;
                    case 2:
                        Ships[0].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("E1", CoordinateMap)); //Carrier 5
                        Ships[1].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("B2", CoordinateMap)); //Battleship 4
                        Ships[2].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("A3", CoordinateMap)); //Cruiser 3
                        Ships[3].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("B1", CoordinateMap)); //Submarine 3
                        Ships[4].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("C4", CoordinateMap)); //Destroyer 2
                        break;
                }
            }
            else if(GameSize == 6)
            {
                switch (i)
                {
                    case 0:
                        Ships[0].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("B2", CoordinateMap)); //Carrier 5
                        Ships[1].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("C3", CoordinateMap)); //Battleship 4
                        Ships[2].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("A1", CoordinateMap)); //Cruiser 3
                        Ships[3].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("D1", CoordinateMap)); //Submarine 3
                        Ships[4].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("E6", CoordinateMap)); //Destroyer 2
                        break;
                    case 1:
                        Ships[0].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A6", CoordinateMap)); //Carrier 5
                        Ships[1].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("F1", CoordinateMap)); //Battleship 4
                        Ships[2].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("C4", CoordinateMap)); //Cruiser 3
                        Ships[3].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A3", CoordinateMap)); //Submarine 3
                        Ships[4].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A5", CoordinateMap)); //Destroyer 2
                        break;
                    case 2:
                        Ships[0].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("C2", CoordinateMap)); //Carrier 5
                        Ships[1].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A1", CoordinateMap)); //Battleship 4
                        Ships[2].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("D5", CoordinateMap)); //Cruiser 3
                        Ships[3].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("D2", CoordinateMap)); //Submarine 3
                        Ships[4].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A6", CoordinateMap)); //Destroyer 2
                        break;
                }

            }
            else if(GameSize == 7)
            {
                switch (i)
                {
                    case 0:
                        Ships[0].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("G3", CoordinateMap)); //Carrier 5
                        Ships[1].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A2", CoordinateMap)); //Battleship 4
                        Ships[2].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("C5", CoordinateMap)); //Cruiser 3
                        Ships[3].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("C4", CoordinateMap)); //Submarine 3
                        Ships[4].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("F1", CoordinateMap)); //Destroyer 2
                        break;
                    case 1:
                        Ships[0].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A2", CoordinateMap)); //Carrier 5
                        Ships[1].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("A4", CoordinateMap)); //Battleship 4
                        Ships[2].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("E4", CoordinateMap)); //Cruiser 3
                        Ships[3].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("C6", CoordinateMap)); //Submarine 3
                        Ships[4].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("F7", CoordinateMap)); //Destroyer 2
                        break;
                    case 2:
                        Ships[0].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("C7", CoordinateMap)); //Carrier 5
                        Ships[1].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("C4", CoordinateMap)); //Battleship 4
                        Ships[2].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("B2", CoordinateMap)); //Cruiser 3
                        Ships[3].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("E1", CoordinateMap)); //Submarine 3
                        Ships[4].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("A6", CoordinateMap)); //Destroyer 2
                        break;
                }

            }
        }

        public override void GuessEnemyLocation(Player enemy)
        {
            /*
            20% of the time choose a board space directly from the emeny ship for a guaranteed hit
            80% of the time choose a random spot in the target board
            */

            int i = Random.Next(0, 10);
            Guess guess;
            WeakPoint shipWeakPoint;

            if(i < 2)
            {
                shipWeakPoint = enemy.GetRandomUnhitShipWeakPoint();
                shipWeakPoint.Hit();

                guess = new Guess(shipWeakPoint.X, shipWeakPoint.Y);
                guess.Place(TargetBoard);
                guess.Hit();

                Console.WriteLine("(Guaranteed hit)\n");
                DisplayHit(shipWeakPoint);
                if (shipWeakPoint.ContainingShip.HasSank)
                {
                    enemy.DecrementHealth();
                    DisplaySank(shipWeakPoint);
                }
            }
            else
            {
                //Pick a random spot on the target board that hasn't already been guessed
                while(true)
                {
                    int x = GetRandomXValue();
                    int y = GetRandomYValue();

                    if(TargetBoard.BoardSpaces.GetSpace(x, y) == null)
                    {
                        guess =  new Guess(x, y);
                        guess.Place(TargetBoard);
                        break;
                    }
                }

                //Does an enemy ship exist at the point we've guessed?
                if (enemy.OceanBoard.BoardSpaces.IsSpaceOccupied(guess.X, guess.Y))
                {
                    shipWeakPoint = (WeakPoint)enemy.OceanBoard.BoardSpaces.GetSpace(guess.X, guess.Y);
                    shipWeakPoint.Hit();
                    guess.Hit();

                    DisplayHit(shipWeakPoint);

                    if (shipWeakPoint.ContainingShip.HasSank)
                    {
                        enemy.DecrementHealth();
                        DisplaySank(shipWeakPoint);
                    }
                }
                else
                {
                    Console.WriteLine("-----" + Name + " did not hit any of your ships-----\n");
                }
            }  
        }

        /*
        Valid points where ships can be placed:
            X > 0 && X < GameSize
            Y >= 0 && Y <= GameSize - 2;

        X and Y  are in separate methods so that either a WeakPoint or a Guess can be constructed by the calling method.
         */

        private int GetRandomXValue()
        {
            return Random.Next(1, GameSize - 1);
        }

        private int GetRandomYValue()
        {
            return Random.Next(0, GameSize - 2);
        }

        private void DisplayHit(WeakPoint wp)
        {
            Console.WriteLine("-----" + Name + " hit your " + wp.ContainingShip.Name + "!-----\n");
        }

        private void DisplaySank(WeakPoint wp)
        {
            Console.WriteLine("-----" + Name + " SANK YOUR " + wp.ContainingShip.Name.ToUpper() + "!-----\n");
        }
    }
}
