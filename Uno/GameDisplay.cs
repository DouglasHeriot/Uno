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
    public partial class GameDisplay : Form
    {
        public GameDisplay()
        {
            InitializeComponent();

            new Card();

            Card.CardFace test = (Card.CardFace) 2;

            MessageBox.Show(test.ToString());
        }
    }
}
