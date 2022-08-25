using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class AI : Player
    {
        public AI(int gameSize, CoordinateMap coordinateMap, string name) : base(gameSize, coordinateMap, name)
        {

        }

        public override void PlaceShips()
        {
            //Picks a starting location and orientation randomly
            //If it doesn't fit then try another combination
        }

        public override void GuessEnemyLocation(Player enemy)
        {
            /*
            20% of the time choose a board space directly from the emeny ship for a guaranteed hit
            80% of the time choose a random spot in the target board
            */
        }
    }
}
