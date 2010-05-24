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
            OfficialUno,
            Hybrid
        }

        // TODO: break down into properties with private attributes


        public int CardsForEachPlayer = 25;
        public int ComputerPlayerDelay = 50;
        public bool UseAnimation = true;
        public bool AllowPickupPutDown = false;
        public bool AllowDrawStacking = false;

        public ScoringSystems ScoringSystem = ScoringSystems.Basic;
    }
}
