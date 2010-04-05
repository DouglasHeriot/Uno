using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uno
{
    class Player
    {

        ///////////////////////////////////////////////////////////////////////////////////////
        // Attributes
        ///////////////////////////////////////////////////////////////////////////////////////


        private string _name;
        private int _score;



        ///////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The Player's name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
            // TODO: trigger events when the name is changed
        }

        /// <summary>
        /// The Player's total score
        /// </summary>
        public int Score
        {
            get { return _score; }
            set { _score = value; }
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
        public Player(string name)
            :this()
        {
            _name = name;
        }


    }
}
