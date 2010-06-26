using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Drawing;

namespace Uno
{

    
    

    /// <summary>
    /// Describes a card
    /// </summary>
    class Card
    {

        ///////////////////////////////////////////////////////////////////////////////////////
        // Enums
        ///////////////////////////////////////////////////////////////////////////////////////

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
            Wild
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
            /// A Wild Draw 4 card
            /// </summary>
            Draw4,

            /// <summary>
            /// No face (a wild card)
            /// </summary>
            None
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        // Attributes
        ///////////////////////////////////////////////////////////////////////////////////////

        public const int NUMBEROFCOLORS = 5;

        private CardColor color;
        private CardFace face;


        ///////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The color of the card
        /// </summary>
        public CardColor Color
        {
            get { return color; }
        }

        /// <summary>
        /// The face of the card
        /// </summary>
        public CardFace Face
        {
            get { return face; }
        }

        /// <summary>
        /// The image used to present this card on the interface
        /// </summary>
        public Image Image
        {
            get { return ImageForCard(color, face); }
        }


        /// <summary>
        /// The value of the card, used only for sorting purposes
        /// </summary>
        public int SortingValue
        {
            get
            {
                int value;

                if (color == CardColor.Wild && face == CardFace.None)
                    value = 13*4;
                else
                    value = (int)color * 13 + (int)face;

                return value;
            }
        }

        public int ScoringValue
        {
            get { return ScoringValueForFace(face); }
        }


        ///////////////////////////////////////////////////////////////////////////////////////
        // Constructors
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Construct a new card
        /// </summary>
        /// <param name="theColor"></param>
        /// <param name="theFace"></param>
        public Card(CardColor theColor, CardFace theFace)
        {
            // Check the card is value, otherwise throw a runtime error
            if (!IsValidCard(theColor, theFace))
                throw new Exception(CardColorToString(theColor) + " " + CardFaceToString(theFace) + " is not a valid Uno card");
        
            // Save parameters in private attributes
            color = theColor;
            face = theFace;
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Public Methods
        ///////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Get the string representing the card
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return StringForCard(color, face);
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        // Operators
        ///////////////////////////////////////////////////////////////////////////////////////


        // Based on code from http://www.blackwasp.co.uk/CSharpRelationalOverload.aspx


        /*

        public static bool operator >(Card v1, Card v2)
        {
            return (v1.Length > v2.Length);
        }

        public static bool operator <(Card v1, Card v2)
        {
            return (v1.Length < v2.Length);
        }

        public static bool operator >=(Card v1, Card v2)
        {
            return (v1.Length >= v2.Length);
        }

        public static bool operator <=(Card v1, Card v2)
        {
            return (v1.Length <= v2.Length);
        }

        */



        ///////////////////////////////////////////////////////////////////////////////////////
        // Static Methods
        ///////////////////////////////////////////////////////////////////////////////////////



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

        /// <summary>
        /// Get a card color from an Integer from 0-4, where 4 is wild
        /// </summary>
        /// <param name="colorInt"></param>
        /// <returns></returns>
        public static CardColor IntToCardColor(int colorInt)
        {
            return (CardColor) colorInt;
        }

        /// <summary>
        /// Get the integer representer a card color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int CardColorToInt(CardColor color)
        {
            return (int)color;
        }




        /// <summary>
        /// Get the letter representing the color
        /// </summary>
        /// <param name="cardColor"></param>
        /// <returns></returns>
        public static string CardColorToString(CardColor cardColor)
        {
            return cardColor.ToString().Substring(0,1).ToLowerInvariant();
        }


        /// <summary>
        /// Get the string representing the card face
        /// </summary>
        /// <param name="cardFace"></param>
        /// <returns></returns>
        public static string CardFaceToString(CardFace cardFace)
        {
            string ret = "";

            switch (cardFace)
            {
                case CardFace.Zero:
                case CardFace.One:
                case CardFace.Two:
                case CardFace.Three:
                case CardFace.Four:
                case CardFace.Five:
                case CardFace.Six:
                case CardFace.Seven:
                case CardFace.Eight:
                case CardFace.Nine:
                    ret = CardFaceToInt(cardFace).ToString();
                    break;

                case CardFace.Draw2:
                    ret = "d2";
                    break;

                case CardFace.Draw4:
                    ret = "d4";
                    break;

                case CardFace.Reverse:
                    ret = "r";
                    break;

                case CardFace.Skip:
                    ret = "s";
                    break;

            }


            return ret;
        }


        /// <summary>
        /// Get the string for a card
        /// </summary>
        /// <param name="color"></param>
        /// <param name="face"></param>
        /// <returns></returns>
        public static string StringForCard(CardColor color, CardFace face)
        {
            return CardColorToString(color) + CardFaceToString(face);
        }


        /// <summary>
        /// Get the Image for a card
        /// </summary>
        /// <param name="color"></param>
        /// <param name="face"></param>
        /// <returns></returns>
        public static Image ImageForCard(CardColor color, CardFace face)
        {
            // Check the card's valid, otherwise just return the back of a card!
            if (!IsValidCard(color, face)) return Properties.Resources.back;

            string card = StringForCard(color, face);
            return (Image)Properties.Resources.ResourceManager.GetObject(card);
        }


        /// <summary>
        /// Check if a color/face combination is a valid Uno card
        /// </summary>
        /// <param name="color"></param>
        /// <param name="face"></param>
        /// <returns></returns>
        public static bool IsValidCard(CardColor color, CardFace face)
        {
            // TODO: implement checking for valid card
            return true;
        }


        /// <summary>
        /// Get the Uno scoring value for a card face
        /// </summary>
        /// <param name="face">The face value of the card</param>
        /// <returns>The integer value</returns>
        public static int ScoringValueForFace(CardFace face)
        {
            int value = 0;

            switch (face)
            {
                case CardFace.Zero:
                case CardFace.One:
                case CardFace.Two:
                case CardFace.Three:
                case CardFace.Four:
                case CardFace.Five:
                case CardFace.Six:
                case CardFace.Seven:
                case CardFace.Eight:
                case CardFace.Nine:
                    value = CardFaceToInt(face);
                    break;
                case CardFace.Draw2:
                case CardFace.Reverse:
                case CardFace.Skip:
                    value = 20;
                    break;
                case CardFace.None:
                case CardFace.Draw4:
                    value = 50;
                    break;
            }

            return value;
        }
    }
}
