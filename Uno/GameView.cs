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

        private List<Label> playerLabels = new List<Label>(4);

        private bool animating = false;


        public GameView(Game newGame, GameController gameController)
        {


            InitializeComponent();

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


            // Set player name labels
            for (int i = 0; i < 4; i++)
            {
                if (i < game.Players.Count)
                    playerLabels[i].Text = game.Players[i].Name;

                else
                    playerLabels[i].Visible = false;
            }



            
            

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


            // Remove cards that are just in the deck
            foreach(Card c in game.Deck)
            {
                this.Controls.Remove(cardsViews[c] as PictureBox);
            }




            // Layout the cards for each player
            for (int i=0; i<game.Players.Count; i++)
            {

                Game.GamePlayer p = (Game.GamePlayer) game.PlayersCards[game.Players[i]];
                
                

                for (int k=0; k<p.Cards.Count; k++)
                {
                    Card c = p.Cards[k];

                    PictureBox pictureBox = cardsViews[c] as PictureBox;
                    this.Controls.Add(pictureBox);
                    pictureBox.BringToFront();



                    #if DEBUG
                    if (p.Cards.Count > 10)
                    {
                        //System.Diagnostics.Debugger.Break();
                    }
                    #endif

                    int left = p.Cards.Count <= 10 ? k * 60 + 260 : k * (650 / p.Cards.Count) + 260 ;


                    moveCardTo(pictureBox, left, i * 137 + 80);


                   
                }
            }


            // Remove all cards in the discard pile from the form except the top 2 cards
            for (int c = 0; c < game.DiscardPile.Count - 2; c++)
                Controls.Remove(cardsViews[game.DiscardPile[c]] as PictureBox);
            

            // Display the discard pile
            if (game.DiscardPile.Count > 0)
            {
                Control lastCard = cardsViews[game.DiscardPile.Last()] as Control;

                Controls.Add(lastCard);
                lastCard.BringToFront();

                moveCardTo(lastCard, 75, 65);
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
            moveCardTo(playerStatus, 213, game.CurrentPlayerIndex * 137 + 43);

            playerStatus.Image = (Image) Properties.Resources.ResourceManager.GetObject(Card.CardColorToString(game.CurrentColor)+ ( game.Reverse ? "_ccw" : "_cw" ));

            if (game.CurrentColor == Card.CardColor.Wild) playerStatus.BackColor = Color.Black;
            else playerStatus.BackColor = Color.Transparent;


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




        private void AnimateMotion(Control control, int left, int top, Projectplace.Gui.Tweener.ease easingFunction)
        {
            TweenPairs p = new TweenPairs();
            p.Add("Y", top);
            p.Add("X", left);
            Tweener t = new Tweener(control, p, easingFunction, 30, 0);

            t.setOnComplete(new Tweener.onCompleteFunction(completed));
            Tweener.add(t);

            // Set the animating flag, so we can prevent user interaction during this time (otherwise unpredicatable things can occurr)
            animating = true;
        }

        private void completed()
        {
            animating = false;

            controller.MakeComputerMove();
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
            if(!animating)
                controller.SelectCard((sender as PictureBox).Tag as Card);
        }


        private void pickupPileImage_Click(object sender, EventArgs e)
        {
            if(!animating)
                controller.PickupCard();
        }


        private void moveCardTo(Control card, int left, int top, Projectplace.Gui.Tweener.ease easingFunction)
        {
            if (game.Options.UseAnimation /*&& !animating*/)
                AnimateMotion(card, left, top, easingFunction);
            else
            {
                card.Top = top;
                card.Left = left;
            }
        }


        private void moveCardTo(Control card, int left, int top)
        {
            moveCardTo(card, left, top, Tweener.easeOutCubic);
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            Program.NewStartup();
        }

        private void endGameButton_Click(object sender, EventArgs e)
        {
            controller.EndGame();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
