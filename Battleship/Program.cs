// See https://aka.ms/new-console-template for more information
using Battleship;

//Game size of 5, 6, or 7 allowed

int gameSize = 5;
CoordinateMap coordinateMap = new CoordinateMap(gameSize);

Player player = new Player(gameSize, coordinateMap, "Kent Mansley");
AI computer = new AI(gameSize, coordinateMap, "The Iron Giant");
//Player computer = new Player(gameSize, coordinateMap, "The Iron Giant");

//For testing both the player and enemy ships are at the same location
//computer.PlaceShipsTest();
//player.PlaceShipsTest();
computer.PlaceShips();

//for (int i = 0; i < 4; i++)
//{
//    player.GuessEnemyLocation(computer);
//}
