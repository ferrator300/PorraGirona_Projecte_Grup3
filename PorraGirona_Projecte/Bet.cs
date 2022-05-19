using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona_Projecte
{
    public class Bet
    {
        private PollMember pollMember;
        private ShownMatch shownMatch;
        private DateTime submissionTime;
        private int localGoals;
        private int awayGoals;

        public Bet() { }

        public PollMember PollMember
        {
            get { return pollMember; }
            set { pollMember = value; }
        }
        public ShownMatch ShownMatch
        {
            get { return shownMatchId; }
            set { shownMatchId = value; }
        }
        public DateTime SubmissionTime
        {
            get { return submissionTime; }
            set { submissionTime = value; }
        }
        public int LocalGoals
        {
            get { return localGoals; }
            set { localGoals = value; }
        }
        public int AwayGoals
        {
            get { return awayGoals; }
            set { awayGoals = value; }
        }
    }
}
