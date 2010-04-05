using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Uno
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            // TEMPORARY CODE UNTIL STARTUP WINDOW IS IMPLEMENTED

            List<Player> players = new List<Player>();
            players.Add(new Player("Me"));
            players.Add(new Player("You"));
            players.Add(new Player("Someone Else"));

            GameOptions options = new GameOptions();

            Game game = new Game(players, options);
            new GameController(game);



            Application.Run();
        }
    }
}
