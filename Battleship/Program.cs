// See https://aka.ms/new-console-template for more information
char c = 'A';
int index = (int)c;

Console.WriteLine(index.ToString());
Console.WriteLine((index - 65).ToString());

int mapSize = 5;
char[] translate = new char[mapSize];

for (int i = 0; i < mapSize; i++)
{
    translate[i] = (char)(i + 65);
}

Console.WriteLine(translate);
Array.Reverse(translate);
Console.WriteLine(translate);


Battleship.Board b = new Battleship.Board(5);
