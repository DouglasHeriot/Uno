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
            NewGame = 0,
            Options,
            Playing,
            Rules
        }


        public Help()
        {
            InitializeComponent();

            // Handle some events, to allow the selected tab to gain focus so the mouse scroll wheel works
            tabView.SelectedIndexChanged += new EventHandler(setFocusEventHandler);
            ResizeEnd += new EventHandler(setFocusEventHandler);
            GotFocus += new EventHandler(setFocusEventHandler);
            VisibleChanged += new EventHandler(setFocusEventHandler);
            Shown += new EventHandler(setFocusEventHandler);
        }

        /// <summary>
        /// Select a page to view
        /// </summary>
        /// <param name="page"></param>
        public void SelectPage(HelpPage page)
        {
            // Select the tab for the user
            tabView.SelectedIndex = (int) page;
        }

        public void ShowPage(HelpPage page)
        {
            SelectPage(page);
            Show();
            BringToFront();
            SetFocusToTab();
        }

        public void SetFocusToTab()
        {
            // Set focus to the new tab, so the scroll wheel on the user's mouse will work
            tabView.SelectedTab.Focus();
        }

        /// <summary>
        /// Handle any events which may require the tab to need focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void setFocusEventHandler(object sender, EventArgs e)
        {
            // Set focus to the new tab, so the scroll wheel on the user's mouse will work
            SetFocusToTab();
        }
    }
}
