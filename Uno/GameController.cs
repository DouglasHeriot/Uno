using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uno
{
    class GameController
    {
        ///////////////////////////////////////////////////////////////////////////////////////
        // Attributes
        ///////////////////////////////////////////////////////////////////////////////////////


        private Game _game;
        private GameView _gameView;


        ///////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The game being played
        /// </summary>
        public Game Game
        {
            get { return _game; }
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Constructors
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Create a new game controller for a new Game
        /// </summary>
        /// <param name="game"></param>
        public GameController(Game game)
        {
            _game = game;

            // Create a new game view
            _gameView = new GameView(game);

            _shuffleDeck();
            DealCards();


            _gameView.ReDraw();
            _gameView.Show();


            
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Public Methods
        ///////////////////////////////////////////////////////////////////////////////////////


        public void DealCards()
        {
           
            int i=0;

            while ((_game.PlayersCards[_game.Players.Last()] as Game.GamePlayer).Cards.Count < _game.Options.CardsForEachPlayer)
            {
                foreach (System.Collections.DictionaryEntry p in _game.PlayersCards)
                {
                    // TODO: deal the actual cards from the main cards array

                    (p.Value as Game.GamePlayer).Cards.Add(_game.Deck[i]);
                    _game.Deck.RemoveAt(i);
                    
                }
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////
        // Private Methods
        ///////////////////////////////////////////////////////////////////////////////////////



        private void _shuffleDeck()
        {
            ShuffleList<Card>(_game.Deck);
        }


        ///////////////////////////////////////////////////////////////////////////////////////
        // Static Methods
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Shuffle a list
        /// </summary>
        /// <typeparam name="E">Type contained in the list</typeparam>
        /// <param name="list">List to shuffle</param>
        public static void ShuffleList<E>(IList<E> list)
        {
            Random random = new Random();

            if (list.Count > 1)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    E tmp = list[i];
                    int randomIndex = random.Next(i + 1);

                    //Swap elements
                    list[i] = list[randomIndex];
                    list[randomIndex] = tmp;
                }
            }
        }

    }
}
