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
        private Hashtable cardsViews = new Hashtable(108);

        private List<Label> playerLabels = new List<Label>(Game.MAXPLAYERS);
        private List<PictureBox> playerComputerBadges = new List<PictureBox>(Game.MAXPLAYERS);

        Timer endGameHighlightTimer = new Timer();

        bool first = true;

        ToolTip toolTip;


        public GameView(Game newGame, GameController gameController)
        {


            InitializeComponent();

            toolTip = new ToolTip();

            // Must redefine the background image to make the optimizing code work properly
            BackgroundImage = Properties.Resources.GameView;

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


            gameInfoMessage.Text = GameOptions.ScoringSystemToString(game.Options.ScoringSystem) + (game.Options.StopPlayingAfterFirst ? ",\r\nStopping after winner" : "");



            endGameHighlightTimer.Interval = 500;
            endGameHighlightTimer.Tick += new EventHandler(endGameHighlightTimer_Tick);

        }

        

        /*
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
            foreach(Card c in game.Deck)
            {
                this.Controls.Remove(cardsViews[c] as PictureBox);
                (cardsViews[c] as PictureBox).Location = new Point(75, 182);
            }




            // Layout the cards for each player
            for (int i=0; i<game.Players.Count; i++)
            {
                // Get the GamePlayer
                Game.GamePlayer p = (Game.GamePlayer) game.PlayersCards[game.Players[i]];

                
                for (int k=0; k<p.Cards.Count; k++)
                {
                    // Get the card
                    Card c = p.Cards[k];

                    // Get the picture box and make sure it's shown on the form
                    PictureBox pictureBox = cardsViews[c] as PictureBox;
                    this.Controls.Add(pictureBox);
                    pictureBox.BringToFront();

                    // Highlight playable cards
                    if(game.Options.HighlightPlayableCards)
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
                    int left = p.Cards.Count <= 10 ? k * 60 + 260 : k * (650 / p.Cards.Count) + 260 ;

                    // Animate moving the position of the card
                    moveCardTo(pictureBox, left, i * 137 + 80, Tweener.easeOutCubic, !first);


                   
                }
            }


            /*
            // Remove all cards in the discard pile from the form except the top 2 cards
            for (int c = 0; c < game.DiscardPile.Count - 2; c++)
            {
                Controls.Remove(cardsViews[game.DiscardPile[c]] as PictureBox);
                (cardsViews[game.DiscardPile[c]] as PictureBox).Location = new Point(75,182);
            }
            */
            

            // Display the discard pile
            if (game.DiscardPile.Count > 0)
            {
                PictureBox lastCard = cardsViews[game.DiscardPile.Last()] as PictureBox;

                Controls.Add(lastCard);
                lastCard.BringToFront();

                moveCardTo(lastCard, 75, 65);

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
            moveCardTo(playerStatus, 213, game.CurrentPlayerIndex * 137 + 43, Tweener.easeOutCubic, game.Options.ComputerPlayerDelay > 600, 50);

            playerStatus.Image = (Image) Properties.Resources.ResourceManager.GetObject(Card.CardColorToString(game.CurrentColor)+ ( game.Reverse ? "_ccw" : "_cw" ));

            if (game.CurrentColor == Card.CardColor.Wild) playerStatus.BackColor = Color.Black;
            else playerStatus.BackColor = Color.Transparent;



            // Show the end game highlight
            if(game.Finished)
                endGameHighlightTimer.Start();


            // Set the first flag, to enable animation again
            first = false;

        }

        void card_MouseLeave(object sender, EventArgs e)
        {
            int newTop = (sender as PictureBox).Top + 10;

            /*
            if (Game.USEANIMATION)
                AnimateMotion((Control)sender, (sender as Control).Left, newTop);
            else
                (sender as PictureBox).Top = newTop;
             */


            //(sender as PictureBox).Invalidate();
            //this.Invalidate();
        }

        void card_MouseEnter(object sender, EventArgs e)
        {
            int newTop = (sender as PictureBox).Top - 10;

            /*
            if (Game.USEANIMATION)
                AnimateMotion((Control)sender, (sender as Control).Left, newTop);
            else
                (sender as PictureBox).Top = newTop;
             */


            //(sender as PictureBox).Invalidate();
            //this.Invalidate(true);
        }




        private void AnimateMotion(Control control, int left, int top, Projectplace.Gui.Tweener.ease easingFunction, int time)
        {
            TweenPairs p = new TweenPairs();
            p.Add("Y", top);
            p.Add("X", left);
            Tweener t = new Tweener(control, p, easingFunction, time, 0);

            //t.setOnComplete(new Tweener.onCompleteFunction(completed));
            Tweener.add(t);
        }

        private void completed()
        {
            //controller.MakeComputerMove();
        }


        private PictureBox createPictureBoxForCard(Card card)
        {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Tag = card;
            

            pictureBox.Image = card.Image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.Transparent;

            pictureBox.Height = 80;
            pictureBox.Width = 50;

            pictureBox.Left = 75;
            pictureBox.Top = 182;

            pictureBox.Click += new EventHandler(card_Click);
            //pictureBox.MouseEnter += new EventHandler(card_MouseEnter);
            //pictureBox.MouseLeave += new EventHandler(card_MouseLeave);

            
            return pictureBox;
        }


        void card_Click(object sender, EventArgs e)
        {
            controller.SelectCard((sender as PictureBox).Tag as Card);
        }


        private void pickupPileImage_Click(object sender, EventArgs e)
        {
            controller.PickupCard();
        }



        private void moveCardTo(Control card, int left, int top, Projectplace.Gui.Tweener.ease easingFunction, bool useAnimation, int time)
        {
            if (game.Options.UseAnimation && useAnimation)
            {
                AnimateMotion(card, left, top, easingFunction, time);
            }
            else
            {
                card.Top = top;
                card.Left = left;
            }
        }

        private void moveCardTo(Control card, int left, int top, Projectplace.Gui.Tweener.ease easingFunction, bool useAnimation)
        {
            moveCardTo(card, left, top, Tweener.easeOutCubic, true, 30);
        }


        private void moveCardTo(Control card, int left, int top, Projectplace.Gui.Tweener.ease easingFunction)
        {
            moveCardTo(card, left, top, Tweener.easeOutCubic, true);
        }


        private void moveCardTo(Control card, int left, int top)
        {
            moveCardTo(card, left, top, Tweener.easeOutCubic);
        }



        private void newGameButton_Click(object sender, EventArgs e)
        {
            // Open a new startup window, while leaving this game to continue
            Program.NewStartup();
        }

        private void endGameButton_Click(object sender, EventArgs e)
        {
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

    }
}
