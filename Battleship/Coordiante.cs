using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Coordinate : IPoint
    {
        public string Value { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
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
