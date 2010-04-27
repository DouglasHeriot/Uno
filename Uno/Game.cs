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
        List<Card> deck;



        /// <summary>
        /// The Players
        /// </summary>
        List<Player> players;



        /// <summary>
        /// Hash table containing players and the Game.Player objects, which contains data about the current game
        /// </summary>
        Hashtable playersCards = new Hashtable(MAXPLAYERS);


        /// <summary>
        /// Game options object
        /// </summary>
        GameOptions options;


        /// <summary>
        /// The discard pile
        /// </summary>
        List<Card> discardPile = new List<Card>(MAXUNOCARDS);


        /// <summary>
        /// Index of the current player
        /// </summary>
        int currentPlayerIndex = 0;


        /// <summary>
        /// Is the play order reversed?
        /// </summary>
        bool reverse = false;


        /// <summary>
        /// The selected color for the last Wild card
        /// </summary>
        private Card.CardColor wildColor = Card.CardColor.Wild;


        /// <summary>
        /// The number of players that have finished playing
        /// </summary>
        private int finishedPlayers = 0;


        ///////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The players
        /// </summary>
        public List<Player> Players
        {
            get { return players; }
        }


        /// <summary>
        /// The cards held by each player
        /// </summary>
        public Hashtable PlayersCards
        {
            get { return playersCards; }
        }


        /// <summary>
        /// The Game Options
        /// </summary>
        public GameOptions Options
        {
            get { return options; }
        }


        /// <summary>
        /// The cards in the Uno deck, not added to player's hands or the discard pile
        /// </summary>
        public List<Card> Deck
        {
            get { return deck; }
            set { deck = value; }
        }

        /// <summary>
        /// The discard pile
        /// </summary>
        public List<Card> DiscardPile
        {
            get { return discardPile; }
        }


        /// <summary>
        /// Current player
        /// </summary>
        public Player CurrentPlayer
        {
            get { return players[currentPlayerIndex]; }
        }

        /// <summary>
        /// Current GamePlayer
        /// </summary>
        public GamePlayer CurrentGamePlayer
        {
            get { return playersCards[players[currentPlayerIndex]] as Game.GamePlayer; }
        }

        /// <summary>
        /// Index of the current player
        /// </summary>
        public int CurrentPlayerIndex
        {
            get { return currentPlayerIndex; }
            set { currentPlayerIndex = value; }
        }

        /// <summary>
        /// The last card played on the discard pile
        /// </summary>
        public Card CurrentCard
        {
            get { return discardPile.Last(); }
        }

        public bool Reverse
        {
            get { return reverse; }
            set { reverse = value; }
        }


        public Card.CardColor CurrentColor
        {
            get
            {
                Card.CardColor color;

                if (wildColor == Card.CardColor.Wild)
                    color = discardPile.Last().Color;
                else
                    color = wildColor;

                return color;
            }
            
        }


        /// <summary>
        /// The color selected for the last wild card. Returns wild when the previous card was not wild
        /// </summary>
        public Card.CardColor WildColor
        {
            get { return wildColor; }
            set { wildColor = value; }
        }



        public bool Finished
        {
            get
            {
                bool finished = true;

                for (int i = 0; i < players.Count; i++)
                {
                    if (!(playersCards[players[i]] as Game.GamePlayer).Finished)
                    {
                        finished = false;
                        break;
                    }
                }

                return finished;
            }
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
        public Game(List<Player> gamePlayers, GameOptions gameOptions)
            :this()
        {
            // store parameters
            players = gamePlayers;
            options = gameOptions;

            // Create entries for each player in the hash table
            foreach (Player p in players)
            {
                playersCards.Add(p, new GamePlayer(p));
            }
        }




        ///////////////////////////////////////////////////////////////////////////////////////
        // Public Methods
        ///////////////////////////////////////////////////////////////////////////////////////





        ///////////////////////////////////////////////////////////////////////////////////////
        // Classes
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Records data about the player in the current game
        /// </summary>
        public class GamePlayer
        {
            Uno.Player player;
            List<Card> cards = new List<Card>(MAXUNOCARDS);
            int score = 0;


            /// <summary>
            /// The player represented
            /// </summary>
            public Uno.Player Player
            {
                get { return player; }
            }


            /// <summary>
            /// The cards this player holds
            /// </summary>
            public List<Card> Cards
            {
                get { return cards; }
            }

            /// <summary>
            /// The Player's score for this round
            /// </summary>
            public int Score
            {
                get { return score; }  
                set { score = value; }
            }

            /// <summary>
            /// Is the player finished?
            /// </summary>
            public bool Finished
            {
                get { return cards.Count <= 0; }
            }


            /// <summary>
            /// Create a new GamePlayer object
            /// </summary>
            /// <param name="player"></param>
            public GamePlayer(Player inputPlayer)
            {
                player = inputPlayer;
            }

        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Static Methods
        ///////////////////////////////////////////////////////////////////////////////////////


        


    }
}
