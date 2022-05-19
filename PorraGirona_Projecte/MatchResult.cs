using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona_Projecte
{
    public class MatchResult
    {
        private ShownMatch shownMatch;
        private int localGoals;
        private int awayGoals;

        public MatchResult() { }

        public ShownMatch ShownMatch
        {
            get { return shownMatch; }
            set {  shownMatch = value; }
        }
        public int LocalGoals
        {
            get { return localGoals; }
            set { localGoals = value; }
        }
        public int AwayGoals
        {
            get {  return awayGoals; }
            set { awayGoals = value; }
        }
    }
}
