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
    public partial class StartupDisplay : Form
    {
        private List<StartupPlayerView> startupPlayerViews = new List<StartupPlayerView>(Game.MAXPLAYERS);

        public StartupDisplay()
        {
            InitializeComponent();

            // Populate the startup player views list
            startupPlayerViews.Add(startupPlayerView1);
            startupPlayerViews.Add(startupPlayerView2);
            startupPlayerViews.Add(startupPlayerView3);
            startupPlayerViews.Add(startupPlayerView4);

            numberOfPlayers.Maximum = Game.MAXPLAYERS;
            numberOfPlayers.Value = 2;

            this.FormClosed += new FormClosedEventHandler(StartupDisplay_FormClosed);
        }


        void StartupDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CloseWindow();
        }


        private void numberOfPlayers_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Game.MAXPLAYERS; i++)
            {
                startupPlayerViews[i].Enabled = i < numberOfPlayers.Value ? true : false;
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            List<Player> players = new List<Player>(Game.MAXPLAYERS);

            for (int i = 0; i < numberOfPlayers.Value; i++)
            {
                players.Add(startupPlayerViews[i].Player);
            }

            GameOptions options = new GameOptions();


            // Create the new game in a new form
            Program.NewGame(players, options);


            // Close this form
            Close();

        }




    }
}
