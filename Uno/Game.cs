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

        ///////////////////////////////////////////////////////////////////////////////////////
        // Constants
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Max number of players allowed in a Uno game
        /// </summary>
        public const int MAXPLAYERS = 4;


        /// <summary>
        /// Should animation be used?
        /// </summary>
        public const bool USEANIMATION = true;




        ///////////////////////////////////////////////////////////////////////////////////////
        // Attributes
        ///////////////////////////////////////////////////////////////////////////////////////

        
        /// <summary>
        /// Array of cards to be dealt to other players, then used as the discard pile
        /// </summary>
        List<Card> _deck;



        /// <summary>
        /// The Players
        /// </summary>
        List<Player> _players;



        /// <summary>
        /// Hash table containing players and the Game.Player objects, which contains data about the current game
        /// </summary>
        Hashtable _playersCards = new Hashtable(MAXPLAYERS);


        /// <summary>
        /// Game options object
        /// </summary>
        GameOptions _options;



        ///////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The players
        /// </summary>
        public List<Player> Players
        {
            get { return _players; }
        }


        /// <summary>
        /// The cards held by each player
        /// </summary>
        public Hashtable PlayersCards
        {
            get { return _playersCards; }
        }


        /// <summary>
        /// The Game Options
        /// </summary>
        public GameOptions Options
        {
            get { return _options; }
        }


        /// <summary>
        /// The cards in the Uno deck, not added to player's hands or the discard pile
        /// </summary>
        public List<Card> Deck
        {
            get { return _deck; }
        }




        ///////////////////////////////////////////////////////////////////////////////////////
        // Constructors
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Create a new game
        /// </summary>
        private Game()
        {
            // Generate the Uno deck
            _deck = GenerateUnoDeck();
        }


        /// <summary>
        /// Create a new game with players and options
        /// </summary>
        /// <param name="players"></param>
        /// <param name="options"></param>
        public Game(List<Player> players, GameOptions options)
            :this()
        {
            // store parameters
            _players = players;
            _options = options;

            // Create entries for each player in the hash table
            foreach (Player p in _players)
            {
                _playersCards.Add(p, new GamePlayer(p));
            }
        }




        ///////////////////////////////////////////////////////////////////////////////////////
        // Classes
        ///////////////////////////////////////////////////////////////////////////////////////


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



            /// <summary>
            /// Create a new GamePlayer object
            /// </summary>
            /// <param name="player"></param>
            public GamePlayer(Player player)
            {
                _player = player;
            }

        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Static Methods
        ///////////////////////////////////////////////////////////////////////////////////////


        public static List<Card> GenerateUnoDeck()
        {
            List<Card> deck = new List<Card>(108);


            // Loop to go through each colour
            for (int i = 0; i < 5; i++)
            {
                Card.CardColor color = (Card.CardColor)i;

                if(color != Card.CardColor.Wild)
                {
                    // Loop to make 2 of each face card for the selected color, but only one 0 (standard Uno deck)
                    // only count from 0-12 to exclude draw 4
                    for (int k = 0; k < 13; k++)
                    {
                        deck.Add( new Card(color, (Card.CardFace) k));

                        // Add the second idenical card, except for 0s
                        if(k!=0)
                            deck.Add(new Card(color, (Card.CardFace)k));
                    }

                }
                else
                {
                    // Generate wild cards

                    for (int k = 0; k < 4; k++)
                    {
                        deck.Add(new Card(color, Card.CardFace.None));
                        deck.Add(new Card(color, Card.CardFace.Draw4));
                    }

                }

            }


            return deck;
        }


    }
}
