﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Player
    {
        /// <summary>
        /// The user-defined name for the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The player's health, initially equal to the number of ships they possess.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// A list of all ships in a player's possession.
        /// </summary>
        protected List<IShip> Ships { get; set; }

        /// <summary>
        /// The board where the player places their ships.
        /// </summary>
        public Board OceanBoard { get; protected set; }

        /// <summary>
        /// The board used to track hits and misses on enemy ships.
        /// </summary>
        protected Board TargetBoard { get; set; }

        protected CoordinateMap CoordinateMap { get; set; }
        protected readonly static Random Random = new Random();

        public Player(int gameSize, CoordinateMap coordinateMap, string name)
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
            Name = name;
            Health = Ships.Count();
        }

        /// <summary>
        /// Write the ocean board to the console.
        /// </summary>
        public void DisplayOceanBoard()
        {
            Console.WriteLine(Name + "'s " + "Ocean Board");
            OceanBoard.DisplayBoard(CoordinateMap);
        }

        /// <summary>
        /// Write the target board to the console
        /// </summary>
        public void DisplayTargetBoard()
        {
            Console.WriteLine(Name + "'s " + "Target Board");
            TargetBoard.DisplayBoard(CoordinateMap);
        }

        /// <summary>
        /// Decrease the player's health by 1.
        /// </summary>
        public void DecrementHealth()
        {
            Health = Health - 1;
        }

        /// <summary>
        /// Get an unhit weakpoint from a random player ship. Used by the AI.
        /// </summary>
        /// <returns>A weakpoint object where IsHit is false.</returns>
        public WeakPoint GetRandomUnhitShipWeakPoint()
        {
            /*
             Used by the AI subclass so that it can guarantee a hit
             on the enemy a certain percentage of the time.

             First gets a ship that hasn't sank, then returns a
             weakpoint on that ship that hasn't been hit.
            */
            List<IShip> unsunkShips = Ships.Where(s => s.HasSank == false).ToList();
            int shipIndex = Random.Next(0, unsunkShips.Count - 1);
            IShip ship = unsunkShips[shipIndex];

            List<WeakPoint> unhitWeakPoints = ship.WeakPoints.Where(wp => wp.IsHit == false).ToList();
            int weakPointIndex = Random.Next(0, unhitWeakPoints.Count - 1);
            return unhitWeakPoints[weakPointIndex];
        }

        /// <summary>
        /// Prompt a player for the locations to place their ships on their ocean board.
        /// </summary>
        public virtual void PlaceShips()
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

            foreach (IShip ship in Ships)
            {
                DisplayOceanBoard();
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
                        break;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message + ". Please try again.\n");
                        continue;
                    }
                }   
            }
            Console.Clear();
        }

        /// <summary>
        /// Automatically places a player's ships on their ocean board. Used for testing only.
        /// </summary>
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

        /// <summary>
        /// Prompt a player to guess where an enemy ship may be located on their target board.
        /// </summary>
        /// <param name="enemy">The player object of the AI.</param>
        public virtual void GuessEnemyLocation(Player enemy)
        {
            /*
            Check the other player's ocean board and see if there is a weakpoint there.
            If so, hit the weakpoint, check if the ship has sank, and check if all the
                enemy ships have sank.
            Place a Guess object on the player's target board saying if the guess was
                successful.
            Write the results to the console and display the player's boards.
            A spot can only be guessed once!
            */

            string instructions = "Enter a coordinate where you think an enemy ship may be located.";

            DisplayTargetBoard();
            DisplayOceanBoard();

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
                WeakPoint shipWeakPoint = (WeakPoint)enemy.OceanBoard.BoardSpaces.GetSpace(guess.X, guess.Y);
                shipWeakPoint.Hit();
                guess.Hit();
                Console.Clear();

                Console.WriteLine("*****You hit an enemy " + shipWeakPoint.ContainingShip.Name + "*****\n");

                if(shipWeakPoint.ContainingShip.HasSank)
                {
                    enemy.DecrementHealth();
                    Console.WriteLine("*****YOU SANK AN ENEMY " + shipWeakPoint.ContainingShip.Name.ToUpper() + "*****\n");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("*****You did not hit any ships*****\n");
            }
        }
    }
}
