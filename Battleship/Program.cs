// See https://aka.ms/new-console-template for more information
using Battleship;

//Game size of 5, 6, or 7 allowed
string separator = "----------------------------------------------------------------------";

string welcome = @"
                           :
                       __;;|;;__   
  +                _-i-_  { }
__|__.`--._.`--.__|-o-o-|_| |_.^.__
 \________________________________|
~~~~~~~~~~~~~~Battleship~~~~~~~~~~~~~~

You and the computer will take turns guessing the location of each other's ships on the board. 
Your goal is to sink all 5 of the computer's ships before it sinks yours.
Both you and the computer have the same numbers and types of ships.

Your target board displays all your guesses and whether they were successful in hitting an enemy ship.
Your ocean board displays your ships and whether each of the spaces they occupy has been hit.";

Console.WriteLine(welcome);
Console.WriteLine(separator);

Console.WriteLine("What is your name? ");

string playerName;
while(true)
{
    try
    {
        playerName = Console.ReadLine();
        if (playerName is null || playerName == "")
        {
            throw new Exception("Your name cannot be empty. Please try again.");
        }
        break;
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.WriteLine("What is your opponent's name? ");

string computerName;
while (true)
{
    try
    {
        computerName = Console.ReadLine();
        if (computerName is null || computerName == "")
        {
            throw new Exception("Your opponent's name cannot be empty. Please try again.");
        }
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.WriteLine("Enter the size of the board you'd like to play on. Valid sizes are 5, 6, or 7. A larger board is more difficult.");

int gameSize;
while(true)
{
    try 
    {
        string sizeInput = Console.ReadLine();

        if(sizeInput is null)
        {
            throw new Exception("Game size cannot be empty");
        }
        else if(!Char.IsNumber(sizeInput, 0))
        {
            throw new Exception("Game size must be a number");
        }
        else if(sizeInput.Length > 1)
        {
            throw new Exception("Valid game sizes are 5, 6, or 7");
        }
        else if(sizeInput != "5" && sizeInput != "6" && sizeInput != "7")
        {
            throw new Exception("Valid game sizes are 5, 6, or 7");
        }

        gameSize = Int32.Parse(sizeInput);
        break;
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message + ". Please try again.\n");
        continue;
    }
}

Console.WriteLine(separator);

CoordinateMap coordinateMap = new CoordinateMap(gameSize);

Player player = new Player(gameSize, coordinateMap, playerName);
AI computer = new AI(gameSize, coordinateMap, computerName);

//player.PlaceShips();
player.PlaceShipsTest();
computer.PlaceShips();

while(player.Health > 0 && computer.Health > 0)
{
    Console.WriteLine(separator);
    player.GuessEnemyLocation(computer);
    computer.GuessEnemyLocation(player);
}

Console.WriteLine(separator);

if(player.Health <= 0)
{
    Console.WriteLine("-----" + computer.Name + " won this round. Better luck next time-----");
}
else if(computer.Health <= 0)
{
    Console.WriteLine("*****YOU WON!*****");
}

string goodbye = @"
              +
          ____|
          |__/|_
     ____/|-#-#-|_____
 (((_0_0_0_0______\___\_~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~
";

Console.WriteLine("Thank you for playing.");
Console.WriteLine(goodbye);
