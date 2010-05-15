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
        private GameOptionsView optionsView = new GameOptionsView();

        public StartupDisplay()
        {
            InitializeComponent();

            // Populate the startup player views list
            startupPlayerViews.Add(startupPlayerView1);
            startupPlayerViews.Add(startupPlayerView2);
            startupPlayerViews.Add(startupPlayerView3);
            startupPlayerViews.Add(startupPlayerView4);

            for (int i = 0; i < startupPlayerViews.Count; i++)
            {
                startupPlayerViews[i].FormName = "Player " + (i + 1).ToString();
            }

            numberOfPlayers.Maximum = Game.MAXPLAYERS;
            numberOfPlayers.Value = 2;

            this.FormClosed += new FormClosedEventHandler(StartupDisplay_FormClosed);


            // Only show the debug buton when in debug mode in VisualC#
            quickDebugGameButton.Visible = false;

            #if DEBUG
            quickDebugGameButton.Visible = true;
            #endif
        }


        void StartupDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CloseWindow();
        }


        private void numberOfPlayers_ValueChanged(object sender, EventArgs e)
        {
            // Enable/disable the forms for different players depending on the number selecred
            for (int i = 0; i < Game.MAXPLAYERS; i++)
            {
                startupPlayerViews[i].Enabled = i < numberOfPlayers.Value ? true : false;
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            List<Player> players = new List<Player>(Game.MAXPLAYERS);

            // Add the players from the form into the list
            for (int i = 0; i < numberOfPlayers.Value; i++)
            {
                players.Add(startupPlayerViews[i].Player);

                // Add a name if one isn't provided
                if (players[i].Name == null) players[i].Name = "Player " + (i + 1).ToString();
            }

            // Create the new game in a new form
            Program.NewGame(players, optionsView.Options);


            // Close this form
            Close();

        }

        private void gameOptionsButton_Click(object sender, EventArgs e)
        {
            optionsView.ShowDialog();
        }


        private void quickDebugGameButton_Click(object sender, EventArgs e)
        {
            List<Player> players = new List<Player>(Game.MAXPLAYERS);
            
            // Set options for a quick game to be able to test the end of game window
            GameOptions options = new GameOptions();
            options.CardsForEachPlayer = 25;
            options.ComputerPlayerDelay = 1;
            options.UseAnimation = false;

            // Add the players from the form into the list
            for (int i = 0; i < numberOfPlayers.Value; i++)
                players.Add(new Player("Player " + (i + 1).ToString(), Player.PlayerType.Computer));

            // Create the new game in a new form
            Program.NewGame(players, options);


            // Close this form
            Close();
        }




    }
}
