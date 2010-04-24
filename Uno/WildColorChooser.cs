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
    partial class WildColorChooser : Form
    {
        public WildColorChooser()
        {
            InitializeComponent();
        }

        private Card.CardColor color;


        public Card.CardColor Color
        {
            get { return color; }
        }

        private void red_Click(object sender, EventArgs e)
        {
            color = Card.CardColor.Red;
        }

        private void yellow_Click(object sender, EventArgs e)
        {
            color = Card.CardColor.Yellow;
        }

        private void green_Click(object sender, EventArgs e)
        {
            color = Card.CardColor.Green;
        }

        private void blue_Click(object sender, EventArgs e)
        {
            color = Card.CardColor.Blue;
        }


    }
}
