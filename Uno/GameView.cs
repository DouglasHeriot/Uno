using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Projectplace.Gui;

namespace Uno
{
    partial class GameView : Form
    {

        private Game game;
        private GameController controller;

        // Stores the relationship between cards and their picture boxes on the form
        private Hashtable cardsViews = new Hashtable(108);

        private List<Label> playerLabels = new List<Label>(Game.MAXPLAYERS);
        private List<PictureBox> playerComputerBadges = new List<PictureBox>(Game.MAXPLAYERS);

        // Timer to flash the end game button highlight
        Timer endGameHighlightTimer = new Timer();

        // Is this the first time the view has been drawn?
        bool first = true;

        // Has the player confirmed closing the form?
        bool confirmedClose = false;

        // If there are too many cards, they shouldn't be animated all dealt at once
        bool tooManyCards;

        ToolTip toolTip;


        public GameView(Game newGame, GameController gameController)
        {
            InitializeComponent();

            toolTip = new ToolTip();

            // Must redefine the background image to make the optimizing code work properly
            BackgroundImage = Properties.Resources.GameView;

            // Save the parameters
            game = newGame;
            controller = gameController;

            


            // Create picture boxes for each card, and store them in a hash table
            foreach (Card c in game.Deck)
                cardsViews.Add(c, createPictureBoxForCard(c));



            // Add controls to their arrays

            playerLabels.Add(player1Label);
            playerLabels.Add(player2Label);
            playerLabels.Add(player3Label);
            playerLabels.Add(player4Label);

            playerComputerBadges.Add(player1ComputerBadge);
            playerComputerBadges.Add(player2ComputerBadge);
            playerComputerBadges.Add(player3ComputerBadge);
            playerComputerBadges.Add(player4ComputerBadge);


            // Set player name and type labels
            for (int i = 0; i < 4; i++)
            {
                if (i < game.Players.Count)
                {
                    playerLabels[i].Text = game.Players[i].Name;
                    playerComputerBadges[i].Image = Player.PlayerTypeBadge(game.Players[i].Type);
                }

                else
                {
                    playerLabels[i].Visible = false;
                    playerComputerBadges[i].Visible = false;
                }
            }


            // Set the game info message
            gameInfoMessage.Text = GameOptions.ScoringSystemToString(game.Options.ScoringSystem) + (game.Options.StopPlayingAfterFirst ? ",\r\nStopping after winner" : "");

            // Handle the form closing event
            FormClosing += new FormClosingEventHandler(GameView_FormClosing);

            // Set up the end game highlight flashing timer
            endGameHighlightTimer.Interval = 500;
            endGameHighlightTimer.Tick += new EventHandler(endGameHighlightTimer_Tick);


            // Check if there's too many cards
            tooManyCards = game.NumberOfPlayers * game.Options.CardsForEachPlayer > 50;



            #if DEBUG
                debugControls.Visible = true;
            #endif
        }

        void GameView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!confirmedClose)
            {
                DialogResult result = MessageBox.Show(this, "Are you sure you want to close this Uno game?", "Close Uno Game", MessageBoxButtons.OKCancel);

                if (result != DialogResult.OK)
                    e.Cancel = true;
                else
                    confirmedClose = true;
            }
        }

        

        /*
         * Using Background images without reducing performance
         * http://blogs.msdn.com/mhendersblog/archive/2005/10/12/480156.aspx
         * and http://www.eggheadcafe.com/software/aspnet/30750705/help-with-form-painting-p.aspx
         */
        
        private Bitmap renderBmp;

        public override Image BackgroundImage
        {
            set
            {
                Image baseImage = value;
                if (renderBmp != null)
                    renderBmp.Dispose();
                renderBmp = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                Graphics g = Graphics.FromImage(renderBmp);
                g.DrawImage(baseImage, 0, 0, Width, Height);
                g.Dispose();
            }
            get
            {
                return renderBmp;
            }
        }
        


        /// <summary>
        /// Updates the game view form to present the current state of the game
        /// </summary>
        public void ReDraw()
        {


            // Remove cards that are just in the deck, but set to appropriate positions
            foreach (Card c in game.Deck)
            {
                this.Controls.Remove(cardsViews[c] as PictureBox);
                (cardsViews[c] as PictureBox).Location = new Point(75, 182);
            }




            // Layout the cards for each player
            for (int i = 0; i < game.Players.Count; i++)
            {
                // Get the GamePlayer
                Game.GamePlayer p = (Game.GamePlayer)game.PlayersCards[game.Players[i]];


                for (int k = 0; k < p.Cards.Count; k++)
                {
                    // Get the card
                    Card c = p.Cards[k];

                    // Get the picture box and make sure it's shown on the form
                    PictureBox pictureBox = cardsViews[c] as PictureBox;
                    this.Controls.Add(pictureBox);
                    pictureBox.BringToFront();

                    // Highlight playable cards
                    if (game.Options.HighlightPlayableCards)
                        pictureBox.BorderStyle = controller.CanPlayCard(c) ? BorderStyle.FixedSingle : BorderStyle.None;



                    // Extra things to try while in Debug mode (incomplete features)
#if DEBUG

                    // Set the tooltip to the status of the card
                    toolTip.SetToolTip(pictureBox, controller.CanPlayCardStatus(c).ToString());


                    if (p.Cards.Count > 10)
                    {
                        //System.Diagnostics.Debugger.Break();
                    }

#endif

                    // Set the position of the card on the screen, putting them closer together when there's more than 10 cards
                    int left = p.Cards.Count <= 10 ? k * 60 + 260 : k * (650 / p.Cards.Count) + 260;

                    // Animate moving the position of the card
                    moveControlTo(pictureBox, left, i * 137 + 80, Tweener.easeOutCubic, !(first && tooManyCards));



                }
            }


            // Remove all cards in the discard pile from the form except some of the top cards
            for (int c = 0; c < game.DiscardPile.Count - 15; c++)
            {
                Controls.Remove(cardsViews[game.DiscardPile[c]] as PictureBox);
                (cardsViews[game.DiscardPile[c]] as PictureBox).Location = new Point(75, 182);

            }


            // Display the discard pile
            if (game.DiscardPile.Count > 0)
            {
                PictureBox lastCard = cardsViews[game.DiscardPile.Last()] as PictureBox;

                Controls.Add(lastCard);
                lastCard.BringToFront();

                moveControlTo(lastCard, 75, 65);

                // Remove tooltip
                toolTip.SetToolTip(lastCard, "");

                // Remove the highlighted border
                if (game.Options.HighlightPlayableCards)
                    lastCard.BorderStyle = BorderStyle.None;
            }



            // Show the pickup pile as empty when it's empty
            if (game.Deck.Count == 0)
            {
                pickupPileImage.Image = null;
                pickupPileImage.BackColor = Color.White;
            }
            else if (pickupPileImage.Image == null)
            {
                pickupPileImage.Image = Properties.Resources.back;
                pickupPileImage.BackColor = Color.Transparent;
            }




            // Set player status
            // Don't animate when computers are playing each other really quickly
            moveControlTo(playerStatus, 213, game.CurrentPlayerIndex * 137 + 43, Tweener.easeOutCubic, game.Options.ComputerPlayerDelay > 600, 50);

            playerStatus.Image = (Image)Properties.Resources.ResourceManager.GetObject(Card.CardColorToString(game.CurrentColor) + (game.Reverse ? "_ccw" : "_cw"));

            if (game.CurrentColor == Card.CardColor.Wild) playerStatus.BackColor = Color.Black;
            else playerStatus.BackColor = Color.Transparent;



            // Show the end game highlight
            if (game.Finished)
            {
                endGameHighlightTimer.Start();
                endGameButton.Focus();
            }


            // Set the first flag, to enable animation again
            first = false;

        }


        /// <summary>
        /// Animate the movement of a control. Does not check if animation is enabled or not
        /// </summary>
        /// <param name="control"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="easingFunction"></param>
        /// <param name="time"></param>
        private void AnimateMotion(Control control, int left, int top, Projectplace.Gui.Tweener.ease easingFunction, int time)
        {
            TweenPairs p = new TweenPairs();
            p.Add("Y", top);
            p.Add("X", left);
            Tweener t = new Tweener(control, p, easingFunction, time, 0);

            //t.setOnComplete(new Tweener.onCompleteFunction(completed));
            Tweener.add(t);
        }

        private PictureBox createPictureBoxForCard(Card card)
        {
            // Create the new picture box
            PictureBox pictureBox = new PictureBox();
            
            // Set the tag so its card can be easily retrieved
            pictureBox.Tag = card;
            
            // Set some properties
            pictureBox.Image = card.Image;
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.BackColor = Color.Transparent;

            // Set the width and hight
            pictureBox.Height = 80;
            pictureBox.Width = 50;

            // Set the default position to the deck
            pictureBox.Left = 75;
            pictureBox.Top = 182;

            // Setup click event handler, to allow users to select cards
            pictureBox.Click += new EventHandler(card_Click);

            return pictureBox;
        }


        void card_Click(object sender, EventArgs e)
        {
            // Select the card, and save the result
            GameController.CardPlayStatus result = controller.SelectCard((sender as PictureBox).Tag as Card);

            // Present the result to the user
            if (result != GameController.CardPlayStatus.Success)
            {
                string errorString;

                // Get the appropriate string for the error
                switch (result)
                {
                    case GameController.CardPlayStatus.IncorrectPlayer:
                        errorString = "Wrong Player";
                        break;
                    case GameController.CardPlayStatus.Draw4NotAllowed:
                        errorString = "Not allowed to play Draw 4 while you have " + game.CurrentColor.ToString() + " cards";
                        break;
                    case GameController.CardPlayStatus.WrongColor:
                        errorString = "Wrong Colour";
                        break;
                    case GameController.CardPlayStatus.UnkownError:
                        errorString = "Not Allowed";
                        break;
                    default:
                        errorString = "";
                        break;
                }

                // Show the label, with the string
                errorLabel.Text = errorString;
                errorLabel.Visible = true;
            }
            else
            {
                // Hide the label if there's no errors
                errorLabel.Visible = false;
            }
        }



        private void pickupPileImage_Click(object sender, EventArgs e)
        {
            // Tell the controller to pickup a card
            controller.PickupCard();

            // Hide the error label
            errorLabel.Visible = false;
        }



        /// <summary>
        /// Animate moving a control to a new position
        /// </summary>
        /// <param name="card"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="easingFunction"></param>
        /// <param name="useAnimation"></param>
        /// <param name="time"></param>
        private void moveControlTo(Control card, int left, int top, Projectplace.Gui.Tweener.ease easingFunction, bool useAnimation, int time)
        {
            // Check if the user disabled animation
            if (game.Options.UseAnimation && useAnimation)
            {
                // Perform the animation
                AnimateMotion(card, left, top, easingFunction, time);
            }
            else
            {
                // Just move the control if animation is disabled
                card.Top = top;
                card.Left = left;
            }
        }

        private void moveControlTo(Control card, int left, int top, Projectplace.Gui.Tweener.ease easingFunction, bool useAnimation)
        {
            moveControlTo(card, left, top, Tweener.easeOutCubic, useAnimation, 30);
        }


        private void moveControlTo(Control card, int left, int top, Projectplace.Gui.Tweener.ease easingFunction)
        {
            moveControlTo(card, left, top, Tweener.easeOutCubic, true);
        }


        private void moveControlTo(Control card, int left, int top)
        {
            moveControlTo(card, left, top, Tweener.easeOutCubic);
        }



        private bool endGame(string messageTitle, string message)
        {
            if (!game.Finished)
            {
                DialogResult result = MessageBox.Show(this, message, messageTitle, MessageBoxButtons.OKCancel);

                if (result != DialogResult.OK)
                    return false;
                else
                {
                    confirmedClose = true;
                    return true;
                }
            }
            else
            {
                // Allow the form to close without prompting the user
                confirmedClose = true;
                return true;
            }
        }


        private void newGameButton_Click(object sender, EventArgs e)
        {
            // First, check if it's ok to end the game
            if (!endGame("New Game", "Are you sure you want to start a new game? This current game will be lost")) return;

            // Open a new startup window
            Program.NewStartup();

            // Don't bother telling the controller about it - just close this window
            Close();
        }

        private void endGameButton_Click(object sender, EventArgs e)
        {
            // First, check if it's ok to end the game
            if (!endGame("End Game", "Are you sure you want to end this game?")) return;
            
            // Tell the controller to end the game
            controller.EndGame();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            // Modally show the about box
            new AboutBox().ShowDialog();
        }


        
        void endGameHighlightTimer_Tick(object sender, EventArgs e)
        {
            // Alterate the visibility property of the end highlighter on each timer tick
            endHighlight.Visible = !endHighlight.Visible;
        }


        private void helpButton_Click(object sender, EventArgs e)
        {
            // Show the help window
            Program.ShowHelp(Help.HelpPage.Playing);
        }

        private void swapHandsButton_Click(object sender, EventArgs e)
        {
            controller.SwapPlayersHands();
        }

        private void computerMoveButton_Click(object sender, EventArgs e)
        {
            controller.MakeComputerMoveForPlayer();
        }

    }
}
