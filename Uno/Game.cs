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




        /// <summary>
        /// Create a new game
        /// </summary>
        public Game()
        {
            

        }



        /// <summary>
        /// Records data about the player in the current game
        /// </summary>
        public class GamePlayer
        {
            Uno.Player _player;
            List<Card> _cards = new List<Card>(108);
            int _score = 0;


            /// <summary>
            /// The player represented
            /// </summary>
            public Uno.Player Player
            {
                get { return _player; }
            }


            /// <summary>
            /// The cards this player holds
            /// </summary>
            public List<Card> Cards
            {
                get { return _cards; }
            }

            /// <summary>
            /// The Player's score for this round
            /// </summary>
            public int Score
            {
                get { return _score; }
                set { _score = value; }
            }

        }


    }
}
