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

        private Game _game;
        private GameController _controller;
        private Hashtable _cardsViews = new Hashtable(108);

        private List<Label> _playerLabels = new List<Label>(4);
        private List<PictureBox> _playerStatus = new List<PictureBox>(4);



        public GameView(Game game, GameController controller)
        {


            InitializeComponent();

            //this.BackgroundImage = null;

            BackgroundImage = Properties.Resources.GameView;

            _game = game;
            _controller = controller;


            // Create picture boxes for each card, and store them in a hash table
            foreach (Card c in _game.Deck)
                _cardsViews.Add(c, _createPictureBoxForCard(c));

            // Add controls to their arrays

            _playerLabels.Add(player1Label);
            _playerLabels.Add(player2Label);
            _playerLabels.Add(player3Label);
            _playerLabels.Add(player4Label);

            _playerStatus.Add(player1Status);
            _playerStatus.Add(player2Status);
            _playerStatus.Add(player3Status);
            _playerStatus.Add(player4Status);



            // Set player name labels
            for (int i = 0; i < 4; i++)
            {
                if (i < _game.Players.Count)
                    _playerLabels[i].Text = _game.Players[i].Name;

                else
                    _playerLabels[i].Visible = false;
            }




            

        }


        /*
         * http://blogs.msdn.com/mhendersblog/archive/2005/10/12/480156.aspx
         * and http://www.eggheadcafe.com/software/aspnet/30750705/help-with-form-painting-p.aspx
         */
        
        private Bitmap _renderBmp;

        public override Image BackgroundImage
        {
            set
            {
                Image baseImage = value;
                if (_renderBmp != null)
                    _renderBmp.Dispose();
                _renderBmp = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                Graphics g = Graphics.FromImage(_renderBmp);
                g.DrawImage(baseImage, 0, 0, Width, Height);
                g.Dispose();
            }
            get
            {
                return _renderBmp;
            }
        }
        


        /// <summary>
        /// Updates the game view form to present the current state of the game
        /// </summary>
        public void ReDraw()
        {


            // Remove cards that are just in the deck
            foreach(Card c in _game.Deck)
            {
                this.Controls.Remove(_cardsViews[c] as PictureBox);
            }




            // Layout the cards for each player
            for (int i=0; i<_game.Players.Count; i++)
            {

                Game.GamePlayer p = (Game.GamePlayer) _game.PlayersCards[_game.Players[i]];
                
                

                for (int k=0; k<p.Cards.Count; k++)
                {
                    Card c = p.Cards[k];

                    PictureBox pictureBox = _cardsViews[c] as PictureBox;
                    this.Controls.Add(pictureBox);
                    pictureBox.BringToFront();



                    #if DEBUG
                    if (p.Cards.Count > 10)
                    {
                        //System.Diagnostics.Debugger.Break();
                    }
                    #endif

                    int left = p.Cards.Count <= 10 ? k * 60 + 260 : k * (650 / p.Cards.Count) + 260 ;


                    _moveCardTo(pictureBox, left, i * 137 + 80);


                   
                }
            }


            // Remove all cards in the discard pile from the form except the top 2 cards
            for (int c = 0; c < _game.DiscardPile.Count - 2; c++)
                Controls.Remove(_cardsViews[_game.DiscardPile[c]] as PictureBox);
            

            // Display the discard pile
            if (_game.DiscardPile.Count > 0)
            {
                Control lastCard = _cardsViews[_game.DiscardPile.Last()] as Control;

                Controls.Add(lastCard);
                lastCard.BringToFront();

                _moveCardTo(lastCard, 75, 65);
            }



            // Show the pickup pile as empty when it's empty
            if (_game.Deck.Count == 0)
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

            foreach (PictureBox p in _playerStatus)
                p.Image = null;

            _playerStatus[_game.CurrentPlayerIndex].Image = (Image) Properties.Resources.ResourceManager.GetObject(Card.CardColorToString(_game.CurrentColor)+"_cw");




        }

        void card_MouseLeave(object sender, EventArgs e)
        {
            int newTop = (sender as PictureBox).Top + 10;

            if (Game.USEANIMATION)
                AnimateMotion((Control)sender, (sender as Control).Left, newTop);
            else
                (sender as PictureBox).Top = newTop;


            //(sender as PictureBox).Invalidate();
            //this.Invalidate();
        }

        void card_MouseEnter(object sender, EventArgs e)
        {
            int newTop = (sender as PictureBox).Top - 10;

            if (Game.USEANIMATION)
                AnimateMotion((Control)sender, (sender as Control).Left, newTop);
            else
                (sender as PictureBox).Top = newTop;


            //(sender as PictureBox).Invalidate();
            //this.Invalidate(true);
        }




        private void AnimateMotion(Control control, int left, int top)
        {
            TweenPairs p = new TweenPairs();
            p.Add("Y", top);
            p.Add("X", left);
            Tweener t = new Tweener(control, p, Tweener.easeInOutCubic, 30, 0);

            //t.setOnComplete(new Tweener.onCompleteFunction(completed));
            Tweener.add(t);
        }



        private PictureBox _createPictureBoxForCard(Card card)
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
            _controller.SelectCard((sender as PictureBox).Tag as Card);
        }

        private void GameView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pickupPileImage_Click(object sender, EventArgs e)
        {
            _controller.PickupCard();
        }


        private void _moveCardTo(Control card, int left, int top)
        {
            if (Game.USEANIMATION)
                AnimateMotion(card, left, top);
            else
            {
                card.Top = top;
                card.Left = left;
            }
        }
    }
}
