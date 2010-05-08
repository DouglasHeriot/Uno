using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Uno
{
    partial class SortedPlayerView : UserControl
    {

        private Player player = new Player();

        public SortedPlayerView()
        {
            InitializeComponent();

            
        }


        public Player Player
        {
            get { return player; }
            set
            {
                player = value;
                setupPlayer();
            }
        }


        private void setupPlayer()
        {
            nameLabel.Text = player.Name;
            scoreLabel.Text = "Score: " + player.Score;
            typeLabel.Text = Player.PlayerTypeToString(player.Type);

            // TODO: sort players properly!
            ordinalLabel.Text = GetOrdinalStringForInt(1);
            
        }



        public static string GetOrdinalStringForInt(int rank)
        {
            string output;

            switch (rank)
            {
                case 1:
                    output = "First";
                    break;
                case 2:
                    output = "Second";
                    break;
                case 3:
                    output = "Third";
                    break;
                case 4:
                    output = "Forth";
                    break;
                // Don't need to include more than 4, as this game can only handle 4 players
                default:
                    output = "";
                    break;
            }

            return output;
        }
    }
}
