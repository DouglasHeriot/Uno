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

        

        /// <summary>
        /// The color of the card
        /// </summary>
        public CardColor Color
        {
            get { return _color; }
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
            int ret = -1;

            switch (cardFace)
            {
                case CardFace.Zero:
                    ret = 0;
                    break;

                case CardFace.One:
                    ret = 1;
                    break;

                case CardFace.Two:
                    ret = 2;
                    break;

                case CardFace.Three:
                    ret = 3;
                    break;

                case CardFace.Four:
                    ret = 4;
                    break;

                case CardFace.Five:
                    ret = 5;
                    break;

                case CardFace.Six:
                    ret = 6;
                    break;

                case CardFace.Seven:
                    ret = 7;
                    break;

                case CardFace.Eight:
                    ret = 8;
                    break;

                case CardFace.Nine:
                    ret = 9;
                    break;
            }

            return ret;
        }


        public static CardFace IntToCardFace(int cardInt)
        {
            CardFace ret;

            switch (cardInt)
            {
                case 0:
                    ret = CardFace.Zero;
                    break;

                case 1:
                    ret = CardFace.One;
                    break;

                case 2:
                    ret = CardFace.Two;
                    break;

                case 3:
                    ret = CardFace.Three;
                    break;

                case 4:
                    ret = CardFace.Four;
                    break;

                case 5:
                    ret = CardFace.Five;
                    break;

                case 6:
                    ret = CardFace.Six;
                    break;

                case 7:
                    ret = CardFace.Seven;
                    break;

                case 8:
                    ret = CardFace.Eight;
                    break;

                case 9:
                    ret = CardFace.Nine;
                    break;

                default:
                    ret = 0;
                    break;


            }

            return ret;
        }
    }
}
