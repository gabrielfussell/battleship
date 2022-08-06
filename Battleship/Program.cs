// See https://aka.ms/new-console-template for more information
using Battleship;
using Battleship.Ships;

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

Tugboat tugboat = new Tugboat();
Carrier carrier = new Carrier();
Destroyer destroyer = new Destroyer();


Console.Write("Location A1: " + tugboat.Place(b, ShipOrientation.Horizontal, b.CoordinateToPoint("A1")) + "\n");
//Console.Write("Location B4: " + tugboat.Place(b, ShipOrientation.Horizontal, b.CoordinateToPoint("B4")) + "\n");
Console.Write("Location A4: " + carrier.Place(b, ShipOrientation.Vertical, b.CoordinateToPoint("A4")) + "\n");
Console.Write("Location D2: " + destroyer.Place(b, ShipOrientation.Horizontal, b.CoordinateToPoint("D2")) + "\n");

foreach (WeakPoint weakPoint in carrier.WeakPoints)
{
    Console.WriteLine(weakPoint.ToString());
}

b.DisplayBoard();