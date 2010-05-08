using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Uno
{
    static class Program
    {

        static private int windowCount = 0;

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
            

            // TEMPORARY CODE UNTIL STARTUP WINDOW IS IMPLEMENTED
            /*
            List<Player> players = new List<Player>();
            players.Add(new Player("Me"));
            players.Add(new Player("You"));
            players.Add(new Player("Someone Else"));

            

            GameOptions options = new GameOptions();

            NewGame(players, options);
            */



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
    }
}
