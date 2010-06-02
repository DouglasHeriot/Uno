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
    partial class GameOptionsView : Form
    {
        // Create a GameOptions object to be edited and later returned
        private GameOptions options = new GameOptions();

        public GameOptionsView()
        {
            InitializeComponent();

            // Setup controls

            scoringMethodDropDown.SelectedIndex = 0;


            // Add event handler that will prevent the form from closing
            FormClosing += new FormClosingEventHandler(GameOptionsView_FormClosing);
        }


        /// <summary>
        /// Selected game options
        /// </summary>
        public GameOptions Options
        {
            get
            {
                // Update options before returning
                options.UseAnimation = animationCheckbox.Checked;
                options.CardsForEachPlayer = (int)cardsPerPlayerUpDown.Value;
                options.ComputerPlayerDelay = (int)computerDelayUpDown.Value;
                options.HighlightPlayableCards = highlightPlayableCards.Checked;
                options.StopPlayingAfterFirst = stopAfterFirst.Checked;
                options.ScoringSystem = scoringMethodDropDown.SelectedIndex == 0 ? GameOptions.ScoringSystems.Basic : GameOptions.ScoringSystems.OfficialUno;

                options.AllowDraw4Always = allowDraw4.Checked;
                options.SwapHandsWith0 = swapWith0.Checked;

                return options;
            }
        }


        void GameOptionsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void scoringMethodDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scoringMethodDropDown.SelectedIndex == 1)
            {
                stopAfterFirst.Checked = true;
                stopAfterFirst.Enabled = false;
                requiredOfficialLabel.Visible = true;
            }
            else
            {
                stopAfterFirst.Enabled = true;
                requiredOfficialLabel.Visible = false;
            }
        }

    }
}
