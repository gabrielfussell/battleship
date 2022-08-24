using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Player
    {
        private List<IShip> Ships { get; set; }
        private Board OceanBoard { get; set; }
        private Board TargetBoard { get; set; }
        private CoordinateMap CoordinateMap { get; set; }

        public Player(int gameSize, CoordinateMap coordinateMap)
        {
            Ships = new List<IShip>()
            {
                new Carrier()
                , new Battleship()
                , new Cruiser()
                , new Submarine()
                , new Destroyer()   
            };

            OceanBoard = new Board(gameSize);
            TargetBoard = new Board(gameSize);
            CoordinateMap = coordinateMap;
        }

        public void DisplayOceanBoard()
        {
            Console.WriteLine("Ocean Board");
            OceanBoard.DisplayBoard(CoordinateMap);
        }

        public void DisplayTargetBoard()
        {
            Console.WriteLine("Target Board");
            TargetBoard.DisplayBoard(CoordinateMap);
        }

        public void PlaceShips()
        {
            string instructions = @"Enter the coordinate where you want to place your ships followed by its orientation (without a space in between).
The coordinate you enter represents the bow of the ship. 
Horizontally placed ships are left to right, starting from the bow.
Vertically placed ships are top to bottom, starting from the bow.
Enter H for horizontal and V for vertical.
Only one ship may occupy a space at a time.
                
For example: 
You place a Cruiser at A2H. Because it has a size of 3 it will occupy spaces A2, A3, and A4.
You place a Cruiser at B2V. Because it has a size of 3 it will occupy spaces B2, C2, and D2.
            ";

            Console.WriteLine(instructions);
            DisplayOceanBoard();

            foreach (IShip ship in Ships)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter a coordiante and orientation for your {0}, {1} space(s) long: ", ship.Name, ship.Size);
                        string input = Console.ReadLine().ToUpper();
                        if (input is null)
                        {
                            throw new Exception("Coordinate value cannot be null");
                        }
                        else if(input.Length != 3)
                        {
                            throw new Exception("Coordinate and orientation must be 3 characters long");
                        }

                        Coordinate coordinate = new Coordinate(input.Substring(0, 2), CoordinateMap);
                        ShipOrientation orientation;

                        if (input.Substring(2, 1) == "H")
                        {
                            orientation = ShipOrientation.Horizontal;
                        }
                        else if (input.Substring(2, 1) == "V")
                        {
                            orientation = ShipOrientation.Vertical;
                        }
                        else
                        {
                            throw new Exception("Invalid ship orientation. Acceptable values are H or V");
                        }

                        ship.Place(OceanBoard, orientation, coordinate);
                        Console.WriteLine();
                        DisplayOceanBoard();
                        break;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message + ". Please try again.");
                        continue;
                    }
                }   
            }
        }

        public void PlaceShipsTest()
        {
            //locations hard coded for testing
            Ships[0].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A1", CoordinateMap)); //Carrier 5
            Ships[1].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("E2", CoordinateMap)); //Battleship 4
            Ships[2].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("A2", CoordinateMap)); //Cruiser 3
            Ships[3].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("C3", CoordinateMap)); //Submarine 3
            Ships[4].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("B4", CoordinateMap)); //Destroyer 2
            DisplayOceanBoard();
        }

        public void GuessEnemyLocation(Player enemy)
        {
            /*
            check the other player's ocean board and see if there is a weakpoint there
            If so, hit the weakpoint, check if the ship has sank, and check if all the
                enemy ships have sank.
            Place a Guess object on the player's target board saying if the guess was
                successful.
            Write the results to the console and display the player's boards.
            Only allow a spot to be guessed once!
            */

            string instructions = "Enter a coordinate where you think an enemy ship may be located.";
   
            DisplayTargetBoard();
            Coordinate coordinate;
            Guess guess;

            while (true)
            {
                try
                {
                    Console.WriteLine(instructions);
                    string input = Console.ReadLine().ToUpper();
                    if (input is null)
                    {
                        throw new Exception("Coordinate value cannot be empty");
                    }

                    coordinate = new Coordinate(input, CoordinateMap);

                    if(!TargetBoard.IsOnBoard(coordinate))
                    {
                        throw new Exception("Coordinate is not on board");
                    }

                    guess = new Guess(coordinate);
                    guess.Place(TargetBoard);

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + ". Please try again.");
                    continue;
                }
            }
            

            if(enemy.OceanBoard.BoardSpaces.IsSpaceOccupied(guess.X, guess.Y))
            {
                /*
                The ocean board's BoardSpaces object holds a set of WeakPoints, with a reference to
                the ship object they belong to. These are created and set in Player.PlaceShips
                which calls Ship.Place
                */
                Point shipWeakPoint = enemy.OceanBoard.BoardSpaces.GetSpace(guess.X, guess.Y);
                shipWeakPoint.Hit();
                guess.Hit();

                Console.WriteLine("Enemy ship hit!");
            }
            else
            {
                Console.WriteLine("Did not hit any ships");
            }

            TargetBoard.DisplayBoard(CoordinateMap);
        }
    }
}
