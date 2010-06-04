using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Uno
{
    static class Program
    {

        static private int windowCount = 0;
        static private Help help;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Open the startup window
            NewStartup();

            // Keep the application running
            Application.Run();
        }


        /// <summary>
        /// Create a new startup window
        /// </summary>
        static public void NewStartup()
        {
            StartupDisplay startupDisplay = new StartupDisplay();
            startupDisplay.Show();

            windowCount++;
        }

        /// <summary>
        /// Create a new game window
        /// </summary>
        /// <param name="players"></param>
        /// <param name="options"></param>
        static public GameController NewGame(List<Player> players, GameOptions options)
        {
            Game game = new Game(players, options);
            GameController controller = new GameController(game);

            windowCount++;

            return controller;
        }

        static public void NewSortedPlayersView(Game game)
        {
            SortedPlayersView view = new SortedPlayersView(game);
            view.Show();

            windowCount++;
        }

        static public int CloseWindow()
        {
            windowCount--;

            // Exit the application if no windows are left
            if (windowCount <= 0) Application.Exit();

            return windowCount;
        }

        static public void ShowHelp(Help.HelpPage page)
        {
            if (help == null) help = new Help();

            help.SelectPage(page);
            help.Show();
            help.BringToFront();
        }
    }
}
