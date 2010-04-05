using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Uno
{
    /// <summary>
    /// Stores the data about the game
    /// </summary>
    class Game
    {

        /// <summary>
        /// Max number of players allowed in a Uno game
        /// </summary>
        public const int MAXPLAYERS = 4;
        
        
        
        /// <summary>
        /// Array of cards to be dealt to other players, then used as the discard pile
        /// </summary>
        List<Card> _cards = new List<Card>(108);

        /// <summary>
        /// Hash table containing players and the Game.Player objects, which contains data about the current game
        /// </summary>
        Hashtable _playersCards = new Hashtable(MAXPLAYERS);

        public Game()
        {
            

        }



        /// <summary>
        /// Records data about the player in the current game
        /// </summary>
        public class Player
        {



        }


    }
}
