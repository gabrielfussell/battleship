using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// A list of letters to assist in converting the Y value of a Coordinate object to a traditional X, Y point.
    /// </summary>
    internal class CoordinateMap
    {
        /*
        Stores a list of characters in reverse order equal to the game size (the size of one side of the playable spaces)/
        EX: [E,D,C,B,A]
        This is to assist with converting coordinates in the format "B3" to a traditional X,Y point.

        Only needed for the Y value in a point.
        */
        private List<char> _characterList { get; set; }

        /// <summary>
        /// Create a new CoordinateMap object.
        /// </summary>
        /// <param name="gameSize">The size of one side of the square of playable spaces.</param>
        /// <remarks>
        /// Only needs to be created once for the entire game.
        /// </remarks>
        public CoordinateMap(int gameSize)
        {
            _characterList = new List<char>(gameSize);
            for(int i = 0; i < gameSize; i++)
            {
                _characterList.Add((char)(i + 65));
            }

            _characterList.Reverse();
        }

        /// <summary>
        /// Get the Y value in an X, Y point for a character.
        /// </summary>
        /// <param name="character"></param>
        /// <returns>A single integer.</returns>
        public int GetYValue(char character)
        {
            return _characterList.IndexOf(character);
        }

        /// <summary>
        /// Get the letter at a specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>A single character.</returns>
        /// <remarks>Used to create the label column of the board in the console.</remarks>
        public char GetValueAtIndex(int index)
        {
            return _characterList[index];
        }
    }
}
