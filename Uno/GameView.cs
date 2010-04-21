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




        public GameView(Game game, GameController controller)
        {


            InitializeComponent();

            this.BackgroundImage = null;

            //BackgroundImage = Properties.Resources.GameView;

            _game = game;
            _controller = controller;


            // Create picture boxes for each card, and store them in a hash table
            foreach (Card c in _game.Deck)
                _cardsViews.Add(c, _createPictureBoxForCard(c));

            _playerLabels.Add(player1Label);
            _playerLabels.Add(player2Label);
            _playerLabels.Add(player3Label);
            _playerLabels.Add(player4Label);

            for (int i = 0; i < 4; i++)
            {
                if (i < _game.Players.Count)
                    _playerLabels[i].Text = i.ToString() + ": " + _game.Players[i].Name;

                else
                    _playerLabels[i].Visible = false;
            }




            

        }


        /*
         * http://blogs.msdn.com/mhendersblog/archive/2005/10/12/480156.aspx
         * and http://www.eggheadcafe.com/software/aspnet/30750705/help-with-form-painting-p.aspx
         */
        /*
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
        */



        public void ReDraw()
        {

            for (int c = 0; c < _game.DiscardPile.Count - 2; c++ )
            {
                Controls.Remove(_cardsViews[_game.DiscardPile[c]] as PictureBox);

            }

            if (_game.DiscardPile.Count > 0)
            {
                Control lastCard = _cardsViews[_game.DiscardPile.Last()] as Control;

                Controls.Add(lastCard);
                lastCard.BringToFront();

                if (Game.USEANIMATION)
                    AnimateMotion(lastCard, 50, 50);
                else
                {
                    lastCard.Top = 50;
                    lastCard.Left = 50;
                }
            }


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

                    int top = i * 137 + 80;
                    int left = k * 30 + 260;


                    if (Game.USEANIMATION)
                        AnimateMotion(pictureBox, left, top);
                    else
                    {
                        pictureBox.Left = left;
                        pictureBox.Top = top;
                    }


                   
                }

                
            }
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
    }
}
