using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Projectplace.Gui;

namespace Uno
{
    partial class SortedPlayersView : Form
    {
        private Game game;
        private List<SortedPlayerView> sortedPlayerViews = new List<SortedPlayerView>(Game.MAXPLAYERS);




        public SortedPlayersView(Game theGame)
        {
            InitializeComponent();

            // Save the parameter for later
            game = theGame;

            sortedPlayerViews.Add(sortedPlayerView1);
            sortedPlayerViews.Add(sortedPlayerView2);
            sortedPlayerViews.Add(sortedPlayerView3);
            sortedPlayerViews.Add(sortedPlayerView4);

            // Setup the sorted player views
            for (int i = 0; i < Game.MAXPLAYERS; i++)
            {
                // Check if the player exists
                if (i < game.NumberOfPlayers)
                {
                    // Set the info so the view can display the player's properties
                    sortedPlayerViews[i].SetInfo(game.Players[i], game);
                    
                }
                else
                {
                    // If the player doesn't exist, hide its view
                    sortedPlayerViews[i].Visible = false;
                }
            }

            // Handle the form closing event
            FormClosed += new FormClosedEventHandler(SortedPlayersView_FormClosed);

            // Set the height of the form to only what's needed
            Height = game.NumberOfPlayers * 94 + 145;

            // Set the background image
            BackgroundImage = Properties.Resources.CardTable;

        }

        void SortedPlayersView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CloseWindow();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            Program.NewStartup();

            Close();
        }

        private void moreDetailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Tell the player views whether or not to use more detail
            foreach (SortedPlayerView v in sortedPlayerViews)
            {
                if(v.Visible)
                    v.SetMoreDetail(moreDetailCheckBox.Checked);
            }


            int width = moreDetailCheckBox.Checked ? 434 : 296;

            // Animate changing the width

            TweenPairs p = new TweenPairs();
            p.Add("theFormWidth", width);
            Tweener t = new Tweener(this, p, Tweener.easeOutElastic, 30, 0);

            //t.setOnComplete(new Tweener.onCompleteFunction(resizeCompleted));
            Tweener.add(t);


        }

        public Single theFormWidth
        {
            get { return (Single) this.Width; }
            set { this.Width = (int) value; }
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
        

        


    }
}
