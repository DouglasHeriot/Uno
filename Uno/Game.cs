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


        /// <summary>
        /// The number of cards in a Uno deck
        /// </summary>
        public const int MAXUNOCARDS = 108;



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


        /// <summary>
        /// The discard pile
        /// </summary>
        List<Card> _discardPile = new List<Card>(MAXUNOCARDS);


        /// <summary>
        /// Index of the current player
        /// </summary>
        int _currentPlayerIndex = 0;


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
            set { _deck = value; }
        }

        /// <summary>
        /// The discard pile
        /// </summary>
        public List<Card> DiscardPile
        {
            get { return _discardPile; }
        }


        /// <summary>
        /// Current player
        /// </summary>
        public Player CurrentPlayer
        {
            get { return _players[_currentPlayerIndex]; }
        }

        /// <summary>
        /// Current GamePlayer
        /// </summary>
        public GamePlayer CurrentGamePlayer
        {
            get { return _playersCards[_players[_currentPlayerIndex]] as Game.GamePlayer; }
        }

        /// <summary>
        /// Index of the current player
        /// </summary>
        public int CurrentPlayerIndex
        {
            get { return _currentPlayerIndex; }
            set { _currentPlayerIndex = value; }
        }

        /// <summary>
        /// The last card played on the discard pile
        /// </summary>
        public Card CurrentCard
        {
            get { return _discardPile.Last(); }
        }


        ///////////////////////////////////////////////////////////////////////////////////////
        // Constructors
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Create a new game
        /// </summary>
        private Game()
        {
            

            
            
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
        // Public Methods
        ///////////////////////////////////////////////////////////////////////////////////////


        public void NextPlayer()
        {
            // TODO: look at direction of play

            _currentPlayerIndex++;

            if (_currentPlayerIndex >= _players.Count)
                _currentPlayerIndex = 0;

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
            List<Card> _cards = new List<Card>(MAXUNOCARDS);
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


        


    }
}
