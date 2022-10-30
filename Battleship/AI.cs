using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// A player object who guesses and places ships automatically.
    /// </summary>
    internal class AI : Player
    {
        private int GameSize { get; set; } //use to assist with getting random X and Y values
        
        /// <summary>
        /// All available points on the board in random order
        /// </summary>
        private List<Tuple<int, int>> AllPoints { get; set; }

        /// <summary>
        /// Create an AI object
        /// </summary>
        /// <param name="gameSize">The size of the game being played.</param>
        /// <param name="coordinateMap">A CoordinateMap object created for the size of the game.</param>
        /// <param name="name">The name of the AI.</param>
        public AI(int gameSize, CoordinateMap coordinateMap, string name) : base(gameSize, coordinateMap, name)
        {
            /*
            GameSize is NOT incremented by 1 like in the Board class since AI isn't dealing
            directly with the row and column labels.
            */
            GameSize = gameSize;

            /*
            Populate AllPoints with a list of all x,y pairs where a ship or guess
            can be placed, in random order. Used to make guesses.

            Valid points are:
            X > 0 && X <= GameSize
            Y >= 0 && Y < GameSize;
            */

            List<Tuple<int, int>> pointsInOrder = new List<Tuple<int, int>>(GameSize * GameSize);

            for(int x = 1; x <= GameSize; x++)
            {
                for(int y = 0; y < GameSize; y++)
                {
                    pointsInOrder.Add(new Tuple<int, int>(x, y));
                }
            }

            int count = pointsInOrder.Count;
            AllPoints = new List<Tuple<int, int>>(count);
            
            for(int i = 0; i < count; i++)
            {
                int randomElementIndex = Random.Next(0, pointsInOrder.Count);
                AllPoints.Add(pointsInOrder[randomElementIndex]);
                pointsInOrder.RemoveAt(randomElementIndex);
            }
        }

        /// <summary>
        /// Automatically place ships on the ocean board
        /// </summary>
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

        /// <summary>
        /// Automatically guess the location of the enemy's ships.
        /// </summary>
        /// <param name="enemy">The player object for the human player.</param>
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

                //Console.WriteLine("(Guaranteed hit)\n");
                DisplayHit(shipWeakPoint);
                if (shipWeakPoint.ContainingShip.HasSank)
                {
                    enemy.DecrementHealth();
                    DisplaySank(shipWeakPoint);
                }

                /*
                Because we don't know where in AllPoints this (x,y) value is, the ELSE block will
                remove it from the list when it tries to guess it again.
                */
            }
            else
            {
                //Pick a random spot on the target board that hasn't already been guessed
                while(true)
                {
                    //Console.WriteLine("Choosing random point...");
                    Tuple<int, int> randomPoint = AllPoints[0];

                    if(TargetBoard.BoardSpaces.GetSpace(randomPoint.Item1, randomPoint.Item2) == null)
                    {
                        guess =  new Guess(randomPoint.Item1, randomPoint.Item2);
                        guess.Place(TargetBoard);
                        AllPoints.RemoveAt(0);
                        break;
                    }

                    //Space has already been guessed so remove from list of options
                    AllPoints.RemoveAt(0);
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

        /// <summary>
        /// Write to the console that a weakpoint on the player's ship was hit.
        /// </summary>
        /// <param name="wp">The weakpoint on the ship that was hit.</param>
        private void DisplayHit(WeakPoint wp)
        {
            Console.WriteLine("-----" + Name + " hit your " + wp.ContainingShip.Name + "!-----\n");
        }

        /// <summary>
        /// Write to the console that a player's ship was sank.
        /// </summary>
        /// <param name="wp">The weakpoint on the ship that was sank.</param>
        private void DisplaySank(WeakPoint wp)
        {
            Console.WriteLine("-----" + Name + " SANK YOUR " + wp.ContainingShip.Name.ToUpper() + "!-----\n");
        }
    }
}
