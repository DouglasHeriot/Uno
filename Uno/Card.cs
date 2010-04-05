using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uno
{

    
    

    /// <summary>
    /// Describes a card
    /// </summary>
    class Card
    {
        private CardColor _color;
        private CardFace _face;
        

        /// <summary>
        /// The color of the card
        /// </summary>
        public CardColor Color
        {
            get { return _color; }
        }

        /// <summary>
        /// The face of the card
        /// </summary>
        public CardFace Face
        {
            get { return _face; }
        }



        /// <summary>
        /// Construct a new card
        /// </summary>
        /// <param name="color"></param>
        /// <param name="face"></param>
        public Card(CardColor color, CardFace face)
        {
            // Save parameters in private attributes
            _color = color;
            _face = face;

            // TODO: implement validation, to prevent illegal card (eg. red wild, or black skip)
        }








        /// <summary>
        /// Defines the color of a card.
        /// </summary>
        public enum CardColor
        {
            /// <summary>
            /// Red cards
            /// </summary>
            Red,

            /// <summary>
            /// Yellow Cards
            /// </summary>
            Yellow,

            /// <summary>
            /// Green Cards
            /// </summary>
            Green,

            /// <summary>
            /// Blue cards
            /// </summary>
            Blue,

            /// <summary>
            /// Wild cards
            /// </summary>
            Black
        }

        /// <summary>
        /// Defines the face of the card
        /// </summary>
        public enum CardFace
        {
            Zero,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,

            /// <summary>
            /// A draw 2 card
            /// </summary>
            Draw2,

            /// <summary>
            /// A skip card
            /// </summary>
            Skip,

            /// <summary>
            /// A reverse card
            /// </summary>
            Reverse,

            /// <summary>
            /// A wild card
            /// </summary>
            Wild,

            /// <summary>
            /// A Wild Draw 4 card
            /// </summary>
            WildDraw4
        }


        /// <summary>
        /// Convert a CardFace into its integer. Action cards return -1.
        /// </summary>
        /// <param name="cardFace">The CardFace</param>
        /// <returns>The face's integer value, or -1 for action cards</returns>
        public static int CardFaceToInt(CardFace cardFace)
        {
            int value = (int)cardFace;
            return value > 9 ? -1 : value;
        }


        /// <summary>
        /// Convert an integer into a CardFace
        /// </summary>
        /// <param name="cardInt"></param>
        /// <returns></returns>
        public static CardFace IntToCardFace(int cardInt)
        {
            return (CardFace) cardInt;
        }
    }
}
