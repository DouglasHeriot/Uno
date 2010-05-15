using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uno
{
    class Player
    {

        ///////////////////////////////////////////////////////////////////////////////////////
        // Enums
        ///////////////////////////////////////////////////////////////////////////////////////

        public enum PlayerType
        {
            Human,
            Computer,
            SmartComputer
        }


        ///////////////////////////////////////////////////////////////////////////////////////
        // Attributes
        ///////////////////////////////////////////////////////////////////////////////////////


        private string name;
        private int score;
        private PlayerType type = PlayerType.Human;
        private int rank = -1;

        ///////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The Player's name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
            // TODO: trigger events when the name is changed
        }

        /// <summary>
        /// The Player's total score
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }


        /// <summary>
        ///  The type of the player
        /// </summary>
        public PlayerType Type
        {
            get { return type; }
            set { type = value; }
        }


        /// <summary>
        /// The rank of the player. Will be calculated at the end of each game, when the list is sorted
        /// </summary>
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }





        ///////////////////////////////////////////////////////////////////////////////////////
        // Constructors
        ///////////////////////////////////////////////////////////////////////////////////////



        /// <summary>
        /// Create a new Player
        /// </summary>
        public Player()
        {

        }


        /// <summary>
        /// Create a new Player with a name
        /// </summary>
        /// <param name="name"></param>
        public Player(string newName)
            :this()
        {
            name = newName;
        }

        /// <summary>
        /// Create a new player with a name and type
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="newType"></param>
        public Player(string newName, PlayerType newType)
            :this(newName)
        {
            type = newType;
        }




        ///////////////////////////////////////////////////////////////////////////////////////
        // Static Methods
        ///////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Get a string that can be displayed from a PlayerType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string PlayerTypeToString(PlayerType type)
        {
            string playerTypeString;

            switch(type)
            {
                case PlayerType.SmartComputer:
                    playerTypeString = "Smart Compuer";
                    break;

                default:
                    playerTypeString = type.ToString();
                    break;
            }

            return playerTypeString;
        }

    }
}
