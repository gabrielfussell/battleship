// See https://aka.ms/new-console-template for more information
using Battleship;

//char c = 'A';
//int index = (int)c;

//Console.WriteLine(index.ToString());
//Console.WriteLine((index - 65).ToString());

//int mapSize = 5;
//char[] translate = new char[mapSize];

//for (int i = 0; i < mapSize; i++)
//{
//    translate[i] = (char)(i + 65);
//}

//Console.WriteLine(translate);
//Array.Reverse(translate);
//Console.WriteLine(translate);


Board b = new Board(5);

//foreach (char ch in b.CoordianteMap)
//{
//    Console.WriteLine(ch.ToString());
//}
b.DisplayBoard();

IShip tugboat = new Tugboat();

Console.Write("Location (2,3): " + tugboat.Place(b, ShipOrientation.Horizontal, new Point(2, 3)) + "\n");
//Console.Write("Location (0,0): " + tugboat.Place(b, ShipOrientation.Horizontal, new Point(0, 0)) + "\n");
//Console.Write("Location (1,5): " + tugboat.Place(b, ShipOrientation.Horizontal, new Point(1, 5)) + "\n");
Console.Write("Location (1,1): " + tugboat.Place(b, ShipOrientation.Horizontal, new Point(1, 1)) + "\n");

foreach (PegSlot peg in tugboat.Pegs)
{
    Console.WriteLine(peg.Location.ToString());
}

b.DisplayBoard();