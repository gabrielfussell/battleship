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
                new Tugboat()
                , new Destroyer()
                , new Submarine()
                , new Cruiser()
                , new Battleship()
                , new Carrier()
            };

            OceanBoard = new Board(gameSize);
            TargetBoard = new Board(gameSize);
            CoordinateMap = coordinateMap;
        }

        public void DisplayOceanBoard()
        {
            OceanBoard.DisplayBoard(CoordinateMap);
        }

        public void DisplayTargetBoard()
        {
            TargetBoard.DisplayBoard(CoordinateMap);
        }

        public void PlaceShips()
        {
            //not the final verison of this method
            //locations hard coded for testing
            Ships[0].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("D4", CoordinateMap)); //Tugboat
            Ships[1].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("A4", CoordinateMap)); //Destroyer
            Ships[2].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("C3", CoordinateMap)); //Submarine
            Ships[3].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("A2", CoordinateMap)); //Cruiser
            Ships[4].Place(OceanBoard, ShipOrientation.Horizontal, new Coordinate("E2", CoordinateMap)); //Battleship
            Ships[5].Place(OceanBoard, ShipOrientation.Vertical, new Coordinate("A1", CoordinateMap)); //Carrier

            /*
            Final version:
            - loop through each of the ships in the array
            - show the ocean board, then ask where to place the ship.
                Give the name of the ship type and how many spaces it will occupy.
             */
        }

        public void GuessEnemyLocation(Player enemy, Coordinate coordinate)
        {
            /*
            check the other player's ocean board and see if there is a weakpoint there
            If so, hit the weakpoint, check if the ship has sank, and check if all the
                enemy ships have sank.
            Place a Guess object on the player's target board saying if the guess was
                successful.
            Write the results to the console and display the player's boards.
            */
        }
    }
}
