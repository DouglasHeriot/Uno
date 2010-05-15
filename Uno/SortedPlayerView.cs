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

        private Player player;
        private bool moreDetail = false;
        private Game game;
        private Game.GamePlayer gamePlayer;




        public SortedPlayerView()
        {
            InitializeComponent();

            
            
        }

        public void SetInfo(Player thePlayer, Game theGame)
        {
            game = theGame;
            player = thePlayer;
            gamePlayer = game.PlayersCards[player] as Game.GamePlayer;

            // Don't show the score label if basic scoring is used
            if (game.Options.ScoringSystem == GameOptions.ScoringSystems.Basic)
                scoreLabel.Visible = false;


            nameLabel.Text = player.Name;
            scoreLabel.Text = "Score: " + player.Score;
            typeLabel.Text = Player.PlayerTypeToString(player.Type);

            turnsLabel.Text = gamePlayer.NumberOfTurns.ToString();
            cardsPickedUpLabel.Text = gamePlayer.NumberOfCardsPickedUp.ToString();
            cardsPlayedLabel.Text = gamePlayer.NumberOfCardsPlayed.ToString();
            
            ordinalLabel.Text = GetOrdinalStringForInt(player.Rank + 1);
        }

        

        /// <summary>
        /// Show or hide the extra detail
        /// </summary>
        /// <param name="detail"></param>
        public void SetMoreDetail(bool detail)
        {
            moreDetail = detail;

            if (moreDetail)
            {
                scoreLabel.Visible = true;
                
                Width = 370;
            }
            else
            {
                Width = 232;
                if (game.Options.ScoringSystem == GameOptions.ScoringSystems.Basic)
                    scoreLabel.Visible = false;
            }
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
