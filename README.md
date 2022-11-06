# Battleship
## Description
This is a windows console app of the board game Battleship written in C#. I created this to practice my skills with basic object oriented programming concepts. In designing and writing it I gained a better understanding of inheritance, encapsulation, and interfaces in particular.

## How to Play
In this game the player is pitted against the computer and the goal is to be the first to sink all of the computer’s ships. The player has two boards: 1) a Target Board which tracks the player’s guesses of enemy ship locations and whether those guesses were successful and 2) an Ocean Board which houses the player’s ships and how many of those ships’ weak points have been hit. The game is played on a board of 5x5, 6x6, or 7x7.

The player is first presented with their empty Ocean Board and asked to place their ships, moving from largest to smallest. Ships are placed at a coordinate location followed by H or V to indicate either a horizontal or vertical orientation (for example, A1H). Horizontal ships are placed from left to right, starting from the bow. Vertical ships are placed from top to bottom, also starting from the bow.

![A screenshot of a player placing ships](/assets/images/place-player-ships.png)

The computer places its ships automatically based on one of three predefined options for each board size.

Once the ships are placed the player and computer take turns guessing the location of the other’s ships. If a guess is unsuccessful an ‘N’ is placed on the player’s Target Board at the location they guessed. If a guess is successful, a ‘Y’ is placed on the player’s Target Board at the location they guessed. Then the corresponding weak point on the enemy’s ship is marked as hit and that ship’s health is decreased by one. When a player’s ship is hit an ‘X’ is added to that space on the player’s Ocean Board.

80% of the time the computer randomly guesses a space on the player’s Ocean Board, choosing a different space if the one selected has already been guessed by the computer. The other 20% of the time is a guaranteed hit on one of the player’s ships.

At the end of a turn a message is displayed saying who hit which type of ship, whether the ship was sunk, and the player’s and computer’s health.

The game is over when all of the ships have been sunk for either the player or the computer.

![A screenshot of a game in progress](/assets/images/game-in-progress.png)

## How to Run
To run this project clone the repository to your local machine and open the .sln file in visual studio. Then run the application using the F5 key.

## Challenges
### User Input
My biggest challenge with this project was allowing the user to enter coordinates using the same format as the original board game. This meant that instead of an (X, Y) point in the traditional coordinate plane, the coordinates were instead in the format “A1”, “C3”, “B5”, etc, with the first character representing the Y axis and the following number the X axis.

![A screenshot of the player’s empty Ocean Board](/assets/images/player-empty-ocean-board.png)

To assist with this I created a class called CoordinateMap, which is an array that helps transform a coordinate in the format “A1” into an (X, Y) pair. My goal was for the program to internally use the (X, Y) format and only use the “A1” format for user input. I was able to accomplish this, but found that it required a lot of extra code and also makes the program’s logic more challenging to understand.

### Computer Ship Placement
The second biggest challenge I encountered was how the computer initially placed the ships on its Ocean Board. I wanted the ships to be placed randomly. However, even on a 5x5 board with only 25 spaces to choose from, devising an efficient algorithm that took into account the size of the ship, its orientation, and non-overlapping placement proved difficult. I ultimately chose to create nine predefined placements for the computer’s ships, three for each board size, and have the computer pick one of the three at the start of each game.

## Improvements
In the future I would like to update the AI class so that it can place its ships randomly at the start of a game.
