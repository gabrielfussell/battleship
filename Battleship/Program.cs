// See https://aka.ms/new-console-template for more information
using Battleship;



//Board b = new Board(5);
//CoordinateMap coordinateMap = new CoordinateMap(5);


//b.DisplayBoard(coordinateMap);

//Tugboat tugboat = new Tugboat();
//Carrier carrier = new Carrier();
//Destroyer destroyer = new Destroyer();


//Console.Write("Location A1: " + tugboat.Place(b, ShipOrientation.Horizontal, new Coordinate("A1", coordinateMap)) + "\n");
////Console.Write("Location B4: " + tugboat.Place(b, ShipOrientation.Horizontal, b.CoordinateToPoint("B4")) + "\n");
//Console.Write("Location A4: " + carrier.Place(b, ShipOrientation.Vertical, new Coordinate("A4", coordinateMap)) + "\n");
//Console.Write("Location D2: " + destroyer.Place(b, ShipOrientation.Horizontal, new Coordinate("D2", coordinateMap)) + "\n");

//carrier.WeakPoints[0].Hit();
//carrier.WeakPoints[2].Hit();

//foreach (WeakPoint weakPoint in carrier.WeakPoints)
//{
//    Console.WriteLine(weakPoint.ToString());
//}

//Console.WriteLine("Carrier size: " + carrier.Size);

//b.DisplayBoard(coordinateMap);

int gameSize = 5;
CoordinateMap coordinateMap = new CoordinateMap(5);

Player player = new Player(gameSize, coordinateMap);
player.PlaceShips();
player.DisplayOceanBoard();