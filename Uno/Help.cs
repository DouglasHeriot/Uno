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
    partial class Help : Form
    {

        public enum HelpPage
        {
            NewGame,
            Options,
            Playing
        }


        public Help()
        {
            InitializeComponent();         
        }


        public Help(HelpPage page)
            :this()
        {
            SelectPage(page);
        }


        public void SelectPage(HelpPage page)
        {
            // Select the tab for the user
            tabView.SelectedIndex = (int) page;
        }
    }
}
