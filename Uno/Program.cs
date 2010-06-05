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
            // Creeate a new startup form, and show it
            StartupDisplay startupDisplay = new StartupDisplay();
            startupDisplay.Show();

            // Count the window
            windowCount++;
        }

        /// <summary>
        /// Create a new game window
        /// </summary>
        /// <param name="players"></param>
        /// <param name="options"></param>
        static public GameController NewGame(List<Player> players, GameOptions options)
        {
            // Create a new game, with the players and options
            Game game = new Game(players, options);

            // Give the game to a new controller, which will set up the form and other things
            GameController controller = new GameController(game);

            // Count the window
            windowCount++;

            return controller;
        }

        /// <summary>
        /// Crete and show a new sorted players view, for the end of a game
        /// </summary>
        /// <param name="game"></param>
        static public void NewSortedPlayersView(Game game)
        {
            // Create a new form, then show it
            SortedPlayersView view = new SortedPlayersView(game);
            view.Show();

            // Count this new window
            windowCount++;
        }

        /// <summary>
        /// Record a window close, and exit the applicatin if necessary
        /// </summary>
        /// <returns></returns>
        static public int CloseWindow()
        {
            windowCount--;

            // Exit the application if no windows are left
            if (windowCount <= 0) Application.Exit();

            return windowCount;
        }

        /// <summary>
        /// Show the help form for a given page
        /// </summary>
        /// <param name="page"></param>
        static public void ShowHelp(Help.HelpPage page)
        {
            // Check if the help form exists, otherwise create a new one
            if (help == null || !help.Visible) help = new Help();

            // Set the form to show the right tab, then show it in the front
            help.ShowPage(page);
        }
    }
}
