using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uno
{
    class GameOptions
    {

        public enum ScoringSystems
        {
            Basic,
            CardValue

            // TODO: Implement hybrid system, where it's scored simply, 
            //       but unfinished players are ordered based on their Uno score
            //       Also implement official Uno scoring could be implemented, where multiple games are played with first to 500 points
            //Hybrid
        }

        // Auto properties are much nicer than splitting with separate fields, 
        // where no additional logic is required
        
        public int CardsForEachPlayer       { get; set; }
        public int ComputerPlayerDelay      { get; set; }
        public bool UseAnimation            { get; set; }
        public bool HighlightPlayableCards  { get; set; }
        public bool AllowDebugWindow        { get; set; }

        // Optional Rules
        public bool SwapHandsWith0          { get; set; }
        public bool AllowDraw4Always        { get; set; }
        //public bool AllowPickupPutDown    { get; set; }
        //public bool AllowDrawStacking     { get; set; }


        private ScoringSystems scoringSystem = ScoringSystems.Basic;
        private bool stopPlayingAfterFirst = false;

        public ScoringSystems ScoringSystem
        {
            get { return scoringSystem; }
            set
            {
                scoringSystem = value;

                if (scoringSystem == ScoringSystems.CardValue)
                    stopPlayingAfterFirst = true;
            }
        }

        public bool StopPlayingAfterFirst
        {
            get { return stopPlayingAfterFirst; }
            set
            {
                stopPlayingAfterFirst = scoringSystem == ScoringSystems.CardValue ? true : value;
            }
        }


        public GameOptions()
        {
            // Set default values

            CardsForEachPlayer = 7;
            ComputerPlayerDelay = 1200;
            UseAnimation = true;
            HighlightPlayableCards = false;
            AllowDebugWindow = false;

            SwapHandsWith0 = false;
            AllowDraw4Always = true;
            StopPlayingAfterFirst = false;

            ScoringSystem = ScoringSystems.Basic;
            
        }


        /// <summary>
        /// Get a string to display a scoring system value
        /// </summary>
        /// <param name="system"></param>
        /// <returns></returns>
        public static string ScoringSystemToString(ScoringSystems system )
        {
            string theString;

            switch (system)
            {
                case ScoringSystems.Basic:
                    theString = "Simple Scoring";
                    break;
                case ScoringSystems.CardValue:
                    theString = "Card Value Scoring";
                    break;
                default:
                    theString = "";
                    break;
            }

            return theString;
        }
    }
}
