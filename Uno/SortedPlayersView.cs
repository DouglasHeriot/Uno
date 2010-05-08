using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            for (int i = 0; i < Game.MAXPLAYERS; i++)
            {
                // Check if the player exists
                if (i < game.NumberOfPlayers)
                {
                    // Set the player so the view can display the player's properties
                    sortedPlayerViews[i].Player = game.Players[i];
                }
                else
                {
                    // If the player doesn't exist, hide its view
                    sortedPlayerViews[i].Visible = false;
                }
                
            }

            FormClosed += new FormClosedEventHandler(SortedPlayersView_FormClosed);


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




    }
}
