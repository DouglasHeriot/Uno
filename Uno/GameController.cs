using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Uno
{
    class GameController
    {
        ///////////////////////////////////////////////////////////////////////////////////////
        // Enums
        ///////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Determine the status of playing a card
        /// </summary>
        public enum CardPlayStatus
        {
            /// <summary>
            /// The card may be played
            /// </summary>
            Success,

            /// <summary>
            /// The card is the wrong color
            /// </summary>
            WrongColor,

            /// <summary>
            /// The card is the wrong face value
            /// </summary>
            WrongFace,

            /// <summary>
            /// The card does not belong to the current player
            /// </summary>
            IncorrectPlayer,

            /// <summary>
            /// Draw 4 may only be played when no other card of current colour are available
            /// </summary>
            Draw4NotAllowed,

            /// <summary>
            /// The reason is unknown: an error may have occurred
            /// </summary>
            UnkownError
        }


        ///////////////////////////////////////////////////////////////////////////////////////
        // Attributes
        ///////////////////////////////////////////////////////////////////////////////////////


        private Game game;
        private GameView gameView;


        private int cardsToDraw = 0;
        private bool skip = false;

        private Timer computerPlayerTimer = new Timer();
        


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
        /// <param name="newGame"></param>
        public GameController(Game newGame)
        {
            game = newGame;

            

            // Setup the uno deck
            game.Deck = GenerateUnoDeck();
            shuffleDeck();

            

            // Create a new game view
            gameView = new GameView(game, this);
            gameView.FormClosed += new FormClosedEventHandler(gameView_FormClosed);

            // Deal the cards to players
            dealCards();


            // Sort the cards in each player's hand
            foreach (System.Collections.DictionaryEntry p in game.PlayersCards)
                sortCards((p.Value as Game.GamePlayer).Cards);

            // Perform the action of the first card (if applicable)
            performAction(Game.CurrentCard);
            handleActions();


            // Get ready for the first player (make a move if it's a computer)
            setupCurrentPlayer();

            // Prepare the game view
            gameView.ReDraw();


            // Setup the computer player delay timer
            computerPlayerTimer.Interval = game.Options.ComputerPlayerDelay;
            computerPlayerTimer.Tick += new EventHandler(computerPlayerTimer_Tick);


            
            
            // Show the game view
            gameView.Show();



            // Testing purposes only!
            //makeComputerMove();

            
        }




        ///////////////////////////////////////////////////////////////////////////////////////
        // Public Methods
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Choose a card for the current player to play
        /// </summary>
        /// <param name="card"></param>
        public CardPlayStatus SelectCard(Card card)
        {
            
            // Check if the card can be played before asking for wild colour
            CardPlayStatus wildCheckStatus = CanPlayCardStatus(card);
            if (wildCheckStatus != CardPlayStatus.Success)
                return wildCheckStatus;
            

            // Ask for the color for a wild card
            if (card.Color == Card.CardColor.Wild)
            {
                WildColorChooser wildColorChooser = new WildColorChooser();
                do
                {
                    wildColorChooser.ShowDialog();

                    if (wildColorChooser.DialogResult == DialogResult.OK)
                    {
                        // Remember the chosen wild color
                        game.WildColor = wildColorChooser.Color;
                    }
                } while (wildColorChooser.DialogResult != DialogResult.OK);

            }

            return SelectCard(card, game.CurrentPlayer, false);
        }


        /// <summary>
        /// Choose a card for the current player to play
        /// </summary>
        public CardPlayStatus SelectCard(Card card, Player player, bool computer)
        {
            CardPlayStatus theStatus = CardPlayStatus.UnkownError;


            // Check that it's the current player's card, not someone else's
            if (game.CurrentGamePlayer.Cards.IndexOf(card) >= 0)
            {
                CardPlayStatus status = CanPlayCardStatus(card);

                // Check that the card is allowed
                if (status == CardPlayStatus.Success)
                {
                    // Move it to the discard pile
                    game.DiscardPile.Add(card);
                    game.CurrentGamePlayer.Cards.Remove(card);

                    // Perform action on action cards
                    performAction(card);
                    
                    // Add to number of cards played statistic
                    game.CurrentGamePlayer.NumberOfCardsPlayed++;

                    if (game.CurrentGamePlayer.Finished)
                    {
                        game.CurrentGamePlayer.FinishRank = game.NumberOfFinishedPlayers - 1;
                    }

                    // Setup next player, and update the game view
                    nextPlayer();
                    gameView.ReDraw();
                }
                else
                {
                    // Sorry, you can't play that card!
                    theStatus = status;
                }
            }
            else
            {
                // It's not your turn!
                theStatus = CardPlayStatus.IncorrectPlayer;
            }

            return theStatus;
            
        }


        /// <summary>
        /// Choose to pickup a card instead of playing
        /// </summary>
        public void PickupCard()
        {
            PickupCard(false);
        }

        /// <summary>
        /// Choose to pickup a card instead of playing
        /// </summary>
        public void PickupCard(bool computer)
        {
            // Don't let a player pick up a card after the game is finished!
            if (game.Finished)
                return;

            // Don't let users make the computer pickup a card!
            if (game.CurrentPlayer.Type != Player.PlayerType.Human && !computer)
                return;


            // Pickup a card
            currentPlayerPickupCard();

            // Move onto the next player
            nextPlayer();

            // Re-layout the game view
            gameView.ReDraw();
        }


        public void EndGame()
        {
            

            // Calculate scores
            if (game.Options.ScoringSystem == GameOptions.ScoringSystems.Basic)
            {
                for (int i = 0; i < game.NumberOfPlayers; i++)
                {
                    Game.GamePlayer gamePlayer = (game.PlayersCards[game.Players[i]] as Game.GamePlayer);
                    gamePlayer.Score = gamePlayer.FinishRank < 0 ? game.NumberOfPlayers - 1 : gamePlayer.FinishRank;

                    game.Players[i].Score += gamePlayer.Score;
                }


            }


            // Sort players based on score
            sortPlayersByScore();


            // Show the final results
            Program.NewSortedPlayersView(game);


            // Close the game view
            gameView.Close();
        }

        /// <summary>
        /// Check if a card can be played (by current or previous players)
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool CanPlayCard(Card card)
        {
            return CanPlayCardStatus(card) == CardPlayStatus.Success;
        }


        // Check if a card can be played
        public CardPlayStatus CanPlayCardStatus(Card card)
        {
            // Assume success unless otherwise
            CardPlayStatus success = CardPlayStatus.Success;

            if (card.Color != Card.CardColor.Wild && card.Color != game.CurrentColor && card.Face != game.CurrentFace)
            {
                // Check the colour is correct, or the card is a wild
                if (card.Color != Card.CardColor.Wild && card.Color != game.CurrentColor)
                    success = CardPlayStatus.WrongColor;

                // Check if the face is correct
                else if (card.Face != game.CurrentFace)
                    success = CardPlayStatus.WrongFace;
            }


            // Don't allow Draw 4s when the player has a card of the current color
            if (!game.Options.AllowDraw4Always)
            {
                bool checkForCurrentColor = false;

                foreach (Card c in game.CurrentGamePlayer.Cards)
                {
                    if (c.Color == game.CurrentColor)
                    {
                        checkForCurrentColor = true;
                        break;
                    }
                }

                if (checkForCurrentColor)
                    success = CardPlayStatus.Draw4NotAllowed;

            }

            // Don't allow playing somebody else's cards!
            // TODO: allow optional pickup put downs
            if (game.CurrentGamePlayer.Cards.IndexOf(card) < 0)
                success = CardPlayStatus.IncorrectPlayer;


            return success;
        }

       
        ///////////////////////////////////////////////////////////////////////////////////////
        // Private Methods
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Shuffle the deck of cards to pick up
        /// </summary>
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


        /// <summary>
        /// Get the index of the next player
        /// </summary>
        /// <param name="initial">The index of the current player</param>
        /// <param name="reverse">Reverse the current direction again</param>
        /// <returns>The index of the next player</returns>
        private int getNextPlayerIndex(int initial, bool reverse)
        {
            // Move onto the next player
            if (!reverse ? !game.Reverse : game.Reverse)
            {
                initial++;

                if (initial >= game.Players.Count)
                    initial = 0;
            }
            else
            {
                initial--;

                if (initial < 0)
                    initial = game.Players.Count - 1;
            }

            return initial;

        }

        private int getNextPlayingPlayerIndex(int initial, bool reverse)
        {
            int value = getNextPlayerIndex(initial, reverse);

            while ((game.PlayersCards[game.Players[value]] as Game.GamePlayer).Finished)
                value = getNextPlayerIndex(value, reverse);

            return value;
        }

        /// <summary>
        /// Get the index of the next player
        /// </summary>
        /// <param name="initial">The index of the current player</param>
        /// <returns>The index of the next player</returns>
        private int getNextPlayerIndex(int initial)
        {
            return getNextPlayerIndex(initial, false);
        }

        private void nextPlayer()
        {
            // Stop if the game is all finished
            if (game.Finished)
                return;


            // Move onto the next player
            game.CurrentPlayerIndex = getNextPlayerIndex(game.CurrentPlayerIndex);

            // Check if the player is actually already finished (but the whole game isn't)
            if (game.CurrentGamePlayer.Finished)
            {
                nextPlayer();
                return;
            }


            // Do the actions required for the action cards
            handleActions();
            

            // Get ready for the next player
            setupCurrentPlayer();


        }

        /// <summary>
        /// Get ready for the next player
        /// </summary>
        private void setupCurrentPlayer()
        {
            // If the player is a computer, get ready to make a move
            if (game.CurrentPlayer.Type != Player.PlayerType.Human)
                startComputerMove();

            // Add to number of turns statistic
            game.CurrentGamePlayer.NumberOfTurns++;
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


            // Get the index to insert the card into
            // (more efficient than sorting the whole hand again when adding a card)
            int index = 0;

            // Index must be checked first, to prevent out of range exceptions in the second half of the condition
            while (index < game.CurrentGamePlayer.Cards.Count && game.CurrentGamePlayer.Cards[index].SortingValue < game.Deck[0].SortingValue)
                index++;


            // Add a card from the deck to the current player's hand
            game.CurrentGamePlayer.Cards.Insert(index, game.Deck[0]);
            game.Deck.RemoveAt(0);

            // Add to the number of cards picked up statistic
            game.CurrentGamePlayer.NumberOfCardsPickedUp++;

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
                    cardsToDraw += 2;
                    break;

                case Card.CardFace.Draw4:
                    cardsToDraw += 4;
                    // Selecting a color is handled by the SelectCard method, when the card is played
                    break;

                case Card.CardFace.Skip:
                    skip = true;
                    break;

                case Card.CardFace.Reverse:
                    reverse();
                    break;

                case Card.CardFace.Zero:
                    if(game.Options.SwapHandsWith0)
                        swapAllPlayerHands();
                    break;
            }
        }

        /// <summary>
        /// Implement the actions of the action cards on the next player
        /// </summary>
        private void handleActions()
        {


            // Skip the player if a skip card was played
            if (skip)
            {
                skip = false;
                nextPlayer();
                return;
            }


            // Force the player to draw their cards
            // TODO: give the next player an opportunity to play another draw card on top, etc.
            if (cardsToDraw > 0 && game.NumberOfPlayingPlayers > 1)
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





        void gameView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CloseWindow();
        }



        /// <summary>
        /// Gets ready to make a move for the computer
        /// </summary>
        private void startComputerMove()
        {
            

            // Check the next player actually is a computer
            if(game.CurrentPlayer.Type != Player.PlayerType.Human)
                // Start a timer to add some delay before the computer moves
                computerPlayerTimer.Start();
        }


        /// <summary>
        /// Makes the move for a computer player (should only be called by a timer)
        /// </summary>
        private void makeComputerMove()
        {

            // Stop if for some reason this method got called when it's actually a human
            if (game.CurrentPlayer.Type == Player.PlayerType.Human)
                return;

            // Set a flag to check if it should be smart (easier than referencing the type all the time)
            bool smart = game.CurrentPlayer.Type == Player.PlayerType.SmartComputer ? true : false;
            
            // Make cards easier to access
            List<Card> cards = game.CurrentGamePlayer.Cards;



            // Store cards that can be played in a list
            List<Card> playableCards = new List<Card>(Game.MAXUNOCARDS);


            if (smart)
            {
                // Look for cards the same color
                foreach(Card c in cards)
                {
                    if (CanPlayCard(c) && game.CurrentColor == c.Color)
                        playableCards.Add(c);
                }

                // If no cards of the same color were found, look for any with the same face value
                if (playableCards.Count <= 0)
                {
                    foreach (Card c in cards)
                    {
                        if (CanPlayCard(c) && game.CurrentFace == c.Face)
                            playableCards.Add(c);
                    }
                }

                // If still no cards are found, look for any wilds to play
                if (playableCards.Count <= 0)
                {
                    foreach (Card c in cards)
                    {
                        if (CanPlayCard(c) && c.Color == Card.CardColor.Wild)
                            playableCards.Add(c);
                    }
                }
            }
            else
            {
                // Look for any cards that can be played
                foreach (Card c in cards)
                {
                    if (CanPlayCard(c))
                        playableCards.Add(c);
                }
            }



            // Choose a card to play
            if (playableCards.Count > 0)
            {
                Random random = new Random();
                Card selectedCard;

                if (smart)
                {
                    // Smart player should choose the highest-value card (as its good to get rid of more points if using Uno scoring)
                    sortCards(playableCards);
                    selectedCard = playableCards.Last();
                }
                else
                {
                    // Choose a card randomly to play
                    selectedCard = playableCards[random.Next(0, playableCards.Count)];
                }


                // If the card's a wild, randomly choose a color
                if (selectedCard.Color == Card.CardColor.Wild)
                {
                    if (smart)
                    {
                        List<Card.CardColor> colorsToChoose = new List<Card.CardColor>();
                        Dictionary<Card.CardColor, int> colorCounts = new Dictionary<Card.CardColor, int>();
                        Card.CardColor greatestColor;

                        // Reset the color counts
                        for (int i = 0; i < Card.NUMBEROFCOLORS - 1; i++)
                        {
                            colorCounts.Add((Card.CardColor)i,0);
                        }

                        // Add 1 to the count of the color for each card
                        foreach (Card c in cards)
                        {
                            if(c.Color != Card.CardColor.Wild)
                                colorCounts[c.Color]++;
                        }

                        // Set the greatest color to the first one
                        greatestColor = (Card.CardColor)0;

                        // Look for the greatest color
                        for (int i = 1; i < (Card.NUMBEROFCOLORS-1); i++)
                        {
                            if (colorCounts[greatestColor] < colorCounts[(Card.CardColor)i])
                                greatestColor = (Card.CardColor)i;
                        }

                        // If more than one color has the highest number of cards, choose it
                        for (int i = 0; i < (Card.NUMBEROFCOLORS -1); i++)
                        {
                            if (colorCounts[(Card.CardColor)i] == colorCounts[greatestColor])
                                colorsToChoose.Add((Card.CardColor)i);
                        }

                        // Randomly choose an appropriate color
                        game.WildColor = colorsToChoose[random.Next(0, colorsToChoose.Count)];


                    }
                    else
                    {
                        // Randomly choose a color
                        game.WildColor = Card.IntToCardColor(random.Next(0, 4));
                    }
                }

                // Play the card
                SelectCard(selectedCard, game.CurrentPlayer, true);
            }
            else
            {
                // Pickup a card if there's nothing else to play
                PickupCard(true);
            }
        
        }



        void computerPlayerTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer and make a move
            computerPlayerTimer.Stop();
            makeComputerMove();
        }


        private void swapAllPlayerHands()
        {


            List<Card> temp = (game.PlayersCards[game.Players[0]] as Game.GamePlayer).Cards;


            int index = 0;

            for (int i = 0; i < game.NumberOfPlayingPlayers; i++)
            {
                if(i<game.NumberOfPlayingPlayers-1)
                    (game.PlayersCards[game.Players[index]] as Game.GamePlayer).Cards = (game.PlayersCards[game.Players[getNextPlayingPlayerIndex(index, true)]] as Game.GamePlayer).Cards;
                else
                    (game.PlayersCards[game.Players[index]] as Game.GamePlayer).Cards = temp;

                
                index = getNextPlayingPlayerIndex(index, true);
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////
        // Static Methods
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Shuffle a list
        /// 
        /// Copied from http://www.vcskicks.com/code-snippet/shuffle-array.php
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
        /// Sort the players
        /// </summary>
        private void sortPlayersByScore()
        {

            if (game.Options.ScoringSystem == GameOptions.ScoringSystems.Basic)
            {
                for (int i = 1; i < game.NumberOfPlayers; i++)
                {
                    for (int k = i; k > 0 && game.Players[k].Score < game.Players[k - 1].Score; k--)
                    {
                        Player temp = game.Players[k];
                        game.Players[k] = game.Players[k - 1];
                        game.Players[k - 1] = temp;
                    }
                }
            }

            // Give the players ranks so strings for "first", "second", etc. can be generated
            for (int j = 0; j < game.NumberOfPlayers; j++)
                game.Players[j].Rank = j;
            // TODO: handle ties, so both players recieve the same rank
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
