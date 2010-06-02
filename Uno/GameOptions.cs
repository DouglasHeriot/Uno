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
            //Hybrid
        }

        // Auto properties are much nicer than splitting with separate fields, 
        // where no additional logic is required
        
        public int CardsForEachPlayer       { get; set; }
        public int ComputerPlayerDelay      { get; set; }
        public bool UseAnimation            { get; set; }
        public bool HighlightPlayableCards  { get; set; }

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

            SwapHandsWith0 = false;
            AllowDraw4Always = true;
            StopPlayingAfterFirst = false;

            ScoringSystem = ScoringSystems.Basic;
            
        }
    }
}
