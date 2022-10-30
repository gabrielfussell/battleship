using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// A location on the board stored in the user friendly format used by
    /// the console when displaying the board.
    /// </summary>
    /// <remarks>
    /// Format is a single character and a number (i.e. "A3").
    /// The X and Y values of the coordinate are calculated and stored
    /// in the object when it is created.
    /// </remarks>
    internal class Coordinate : IPoint
    {
        /// <summary>
        /// The location of the coodinate.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// The X value of the coordiante.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// The Y value of the coordinate.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Create a Coordinate object.
        /// </summary>
        /// <param name="value">The location of the coordinate in the format of a single character and a number.</param>
        /// <param name="coordinateMap">A CoordinateMap created for the size of the board.</param>
        /// <exception cref="ArgumentException">Thrown when the format of the coordinate is invalid.</exception>
        public Coordinate(string value, CoordinateMap coordinateMap)
        {
            if (value.Length != 2)
            {
                throw new ArgumentException("Coordinate must have a length of two characters");
            }
            else if(!Char.IsLetter(value,0))
            {
                throw new ArgumentException("First value of a coordinate must be a letter");
            }
            else if(!Char.IsNumber(value,1))
            {
                throw new ArgumentException("Second value of a coordinate must be a number");
            }
            else
            {
                Value = value;
                X = Int32.Parse(value.Substring(1, 1));
                Y = coordinateMap.GetYValue(char.Parse(value.Substring(0, 1)));
            }
        }
    }
}
