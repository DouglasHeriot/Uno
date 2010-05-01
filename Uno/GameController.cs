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


        private Game game;
        private GameView gameView;


        private int cardsToDraw = 0;
        private bool skip = false;
        

        


        ///////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The game being played
        /// </summary>
        public Game Game
        {
            get { return game; }
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Constructors
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Create a new game controller for a new Game
        /// </summary>
        /// <param name="game"></param>
        public GameController(Game newGame)
        {
            game = newGame;

            

            // Setup the uno deck
            game.Deck = GenerateUnoDeck();
            shuffleDeck();

            

            // Create a new game view
            gameView = new GameView(game, this);


            // Deal the cards to players
            dealCards();


            // Sort the cards in each player's hand
            foreach (System.Collections.DictionaryEntry p in game.PlayersCards)
                sortCards((p.Value as Game.GamePlayer).Cards);

            // Perform the action of the first card (if applicable)
            performAction(Game.CurrentCard);

            // Prepare the game view
            gameView.ReDraw();


            // Show the game view
            gameView.Show();


            
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
            // Check that it's the current player's card, not someone else's
            if (game.CurrentGamePlayer.Cards.IndexOf(card) >= 0)
            {
                // Check that the card is allowed
                if (canPlayCard(card))
                {
                    // Move it to the discard pile
                    game.DiscardPile.Add(card);
                    game.CurrentGamePlayer.Cards.Remove(card);

                    // Ask for the color for a wild card
                    if (card.Color == Card.CardColor.Wild)
                    {
                        WildColorChooser wildColor = new WildColorChooser();
                        wildColor.ShowDialog();

                        if (wildColor.DialogResult == DialogResult.OK)
                        {
                            game.WildColor = wildColor.Color;
                        }

                    }
                    else
                    {
                        // If the card isn't a wild, reset the wildColor variable back to normal.
                        game.WildColor = Card.CardColor.Wild;
                    }


                    // Perform action on action cards
                    performAction(card);
                    

                    // Setup next player, and update the game view
                    nextPlayer();
                    gameView.ReDraw();
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
            // Pickup a card
            currentPlayerPickupCard();

            // Move onto the next player
            nextPlayer();

            // Re-layout the game view
            gameView.ReDraw();
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Private Methods
        ///////////////////////////////////////////////////////////////////////////////////////



        private void shuffleDeck()
        {
            ShuffleList<Card>(game.Deck);
        }


        
        /// <summary>
        /// Deal cards to each player and to the discard pile
        /// </summary>
        private void dealCards()
        {
                       
            // Continue until the last player has the required number of cards
            while ((game.PlayersCards[game.Players.Last()] as Game.GamePlayer).Cards.Count < game.Options.CardsForEachPlayer)
            {
                // Give each player a card from the 'top' of the deck
                foreach (System.Collections.DictionaryEntry p in game.PlayersCards)
                {
                    // Add to player's hand
                    (p.Value as Game.GamePlayer).Cards.Add(game.Deck[0]);

                    // Remove from deck
                    game.Deck.RemoveAt(0);   
                }
            }


            // Add a card to start the discard pile, but don't allow wilds
            do
            {
                game.DiscardPile.Add(game.Deck[0]);
                game.Deck.RemoveAt(0);
            }
            while (game.CurrentCard.Color == Card.CardColor.Wild);
            
        }



        private void nextPlayer()
        {
            // Stop if the game is all finished
            if (game.Finished)
                return;


            // Move onto the next player
            if (!game.Reverse)
            {
                game.CurrentPlayerIndex++;

                if (game.CurrentPlayerIndex >= game.Players.Count)
                    game.CurrentPlayerIndex = 0;
            }
            else
            {
                game.CurrentPlayerIndex--;

                if (game.CurrentPlayerIndex < 0)
                    game.CurrentPlayerIndex = game.Players.Count - 1;
            }


            // Check if the player is actually already finished (but the whole game isn't)
            if (game.CurrentGamePlayer.Finished)
            {
                nextPlayer();
                return;
            }
            




            // Skip the player if a skip card was played
            if (skip)
            {
                skip = false;
                nextPlayer();
            }

            if (cardsToDraw > 0)
            {
                bool success;

                for (int i = 0; i < cardsToDraw; i++)
                {
                    success = currentPlayerPickupCard();

#if DEBUG
                    if (!success)
                        MessageBox.Show("Failed to pickup a card!");
#endif
                }

                // Reset to 0
                cardsToDraw = 0;

                // Move onto the next player
                nextPlayer();
                return;

                // TODO: give the next player an opportunity to play another draw card on top, etc.
            }



        }


        /// <summary>
        /// Make the current player pickup a card
        /// </summary>
        private bool currentPlayerPickupCard()
        {
            bool successMovingCards;

            //Avoid crashing when the deck is empty
            if (game.Deck.Count == 0)
            {
                successMovingCards = discardPileToDeck();
                if (!successMovingCards)
                {
                    // Failed to pickup a card
                    return false;
                }
            }


            // Add a card from the deck to the current player's hand
            game.CurrentGamePlayer.Cards.Add(game.Deck[0]);
            game.Deck.RemoveAt(0);

            // Sort the hand
            sortCards(game.CurrentGamePlayer.Cards);


            // Successfully picked up a card
            return true;
        }


        /// <summary>
        /// Moves unused cards from the discard pile to the deck
        /// </summary>
        private bool discardPileToDeck()
        {
#if DEBUG
            //MessageBox.Show("Attempting to move cards from discard pile to deck");
#endif

            // Don't allow when the discard pile is already very empty
            if(Game.DiscardPile.Count < 2)
                // Report failure
                return false;


            // Get the cards to move
            List<Card> cardsToMove = Game.DiscardPile.GetRange(0, Game.DiscardPile.Count - 1);

            // Remove the cards from the discard pile
            foreach (Card c in cardsToMove)
                Game.DiscardPile.Remove(c);

            // Add the cards to the deck
            Game.Deck.AddRange(cardsToMove);

            // Shuffle the new deck
            shuffleDeck();

            // Success
            return true;
        }


        /// <summary>
        /// Perform the action on an action card
        /// </summary>
        /// <param name="card">The card played</param>
        private void performAction(Card card)
        {
            switch (card.Face)
            {
                case Card.CardFace.Draw2:
                    cardsToDraw = 2;
                    break;

                case Card.CardFace.Draw4:
                    cardsToDraw = 4;

                    // Selecting a color is handled by the SelectCard method, when the card is played

                    break;

                case Card.CardFace.Skip:
                    skip = true;
                    break;

                case Card.CardFace.Reverse:
                    reverse();
                    break;
            }
        }


        /// <summary>
        /// Reverse the direction of play
        /// </summary>
        private void reverse()
        {
            // If reverse is true, swap to false, and if false, swap to true.
            game.Reverse = game.Reverse ? false : true;
        }


        private bool canPlayCard(Card card)
        {
            bool success = false;

            // Check the basic card can be played
            if (canPlayCardOn(game.CurrentCard, card))
            {
                success = true;
            }
            // Check if the last card was a wild
            else if (game.WildColor != Card.CardColor.Wild)
            {
                if (card.Color == game.WildColor)
                {
                    success = true;
                }
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
        public static void sortCards(List<Card> cards)
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
        private bool canPlayCardOn(Card current, Card newCard)
        {
            //bool success = false;

            return current.Color == newCard.Color || newCard.Color == Card.CardColor.Wild || /* current.Color == Card.CardColor.Wild ||*/ current.Face == newCard.Face;
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
