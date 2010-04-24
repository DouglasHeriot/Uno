using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Uno
{
    class GameController
    {
        ///////////////////////////////////////////////////////////////////////////////////////
        // Attributes
        ///////////////////////////////////////////////////////////////////////////////////////


        private Game _game;
        private GameView _gameView;


        private int _cardsToDraw = 0;
        private Card.CardColor _wildColor = Card.CardColor.Wild;


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

            

            // Setup the uno deck
            _game.Deck = GenerateUnoDeck();
            _shuffleDeck();

            

            // Create a new game view
            _gameView = new GameView(game, this);


            // Deal the cards to players
            _dealCards();


            // Sort the cards in each player's hand
            foreach (System.Collections.DictionaryEntry p in _game.PlayersCards)
                _sortCards((p.Value as Game.GamePlayer).Cards);
            

            // Prepare the game view
            _gameView.ReDraw();



            _gameView.Show();


            
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Public Methods
        ///////////////////////////////////////////////////////////////////////////////////////



        /// <summary>
        /// Choose a card for the current player to play
        /// </summary>
        /// <param name="card"></param>
        public void SelectCard(Card card)
        {
            if (_game.CurrentGamePlayer.Cards.IndexOf(card) >= 0)
            {
                if (_canPlayCard(card))
                {
                    _game.DiscardPile.Add(card);
                    _game.CurrentGamePlayer.Cards.Remove(card);

                    if (card.Color == Card.CardColor.Wild)
                    {
                        WildColorChooser wildColor = new WildColorChooser();
                        wildColor.ShowDialog();

                        if (wildColor.DialogResult == DialogResult.OK)
                        {
                            _game.CurrentColor = wildColor.Color;
                        }
                        
                    }
                    else
                    {
                        _game.CurrentColor = card.Color;
                    }
                    

                    _nextPlayer();
                    _gameView.ReDraw();
                }
                else
                {
                    // Sorry, you can't play that card!
                }
            }
            else
            {
                // It's not your turn!
            }

            
            
        }


        /// <summary>
        /// Choose to pickup a card instead of playing
        /// </summary>
        public void PickupCard()
        {
            //Avoid crashing when the deck is empty
            if (_game.Deck.Count == 0)
                // Should take cards from the discard pile to fill the deck (but what if there's only 1 there?)
                return;


            // Add a card from the deck to the current player's hand
            _game.CurrentGamePlayer.Cards.Add(_game.Deck[0]);
            _game.Deck.RemoveAt(0);

            // Sort the hand
            _sortCards(_game.CurrentGamePlayer.Cards);

            // Move onto the next player
            _nextPlayer();

            // Re-layout the game view
            _gameView.ReDraw();
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Private Methods
        ///////////////////////////////////////////////////////////////////////////////////////



        private void _shuffleDeck()
        {
            ShuffleList<Card>(_game.Deck);
        }


        
        /// <summary>
        /// Deal cards to each player and to the discard pile
        /// </summary>
        private void _dealCards()
        {
                       
            // Continue until the last player has the required number of cards
            while ((_game.PlayersCards[_game.Players.Last()] as Game.GamePlayer).Cards.Count < _game.Options.CardsForEachPlayer)
            {
                // Give each player a card from the 'top' of the deck
                foreach (System.Collections.DictionaryEntry p in _game.PlayersCards)
                {
                    // Add to player's hand
                    (p.Value as Game.GamePlayer).Cards.Add(_game.Deck[0]);

                    // Remove from deck
                    _game.Deck.RemoveAt(0);   
                }
            }


            // Add a card to start the discard pile
            _game.DiscardPile.Add(_game.Deck[0]);
            _game.Deck.RemoveAt(0);

            _game.CurrentColor = _game.CurrentCard.Color;
            
        }



        private void _nextPlayer()
        {
            
            // TODO: look at direction of play

            _game.CurrentPlayerIndex++;

            if (_game.CurrentPlayerIndex >= _game.Players.Count)
                _game.CurrentPlayerIndex = 0;

        }



        private bool _canPlayCard(Card card)
        {
            bool success = false;

            if (_canPlayCardOn(_game.CurrentCard, card))
            {
                success = true;
            }
            return success;
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




        /// <summary>
        /// Sort a list of cards
        /// </summary>
        /// <param name="cards"></param>
        public static void _sortCards(List<Card> cards)
        {
            for (int i = 1; i < cards.Count; i++)
            {
                for (int k = i; k > 0 && cards[k].SortingValue < cards[k - 1].SortingValue; k--)
                {
                    Card temp = cards[k];
                    cards[k] = cards[k - 1];
                    cards[k - 1] = temp;
                }
            }
        }



        /// <summary>
        /// Check if a card can be played on another. Does not take into account draw cards.
        /// </summary>
        /// <param name="current">Current card on the top of the discard pile</param>
        /// <param name="newCard">New card asking to be played</param>
        /// <returns></returns>
        private bool _canPlayCardOn(Card current, Card newCard)
        {
            //bool success = false;

            return current.Color == newCard.Color || newCard.Color == Card.CardColor.Wild || current.Color == Card.CardColor.Wild || current.Face == newCard.Face;
        }




        /// <summary>
        /// Generate a Uno deck of cards
        /// </summary>
        /// <returns></returns>
        public static List<Card> GenerateUnoDeck()
        {
            List<Card> deck = new List<Card>(Game.MAXUNOCARDS);


            // Loop to go through each colour
            for (int i = 0; i < 5; i++)
            {
                Card.CardColor color = (Card.CardColor)i;

                if (color != Card.CardColor.Wild)
                {
                    // Loop to make 2 of each face card for the selected color, but only one 0 (standard Uno deck)
                    // only count from 0-12 to exclude draw 4
                    for (int k = 0; k < 13; k++)
                    {
                        deck.Add(new Card(color, (Card.CardFace)k));

                        // Add the second idenical card, except for 0s
                        if (k != 0)
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
