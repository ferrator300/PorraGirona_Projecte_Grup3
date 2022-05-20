using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona_Projecte
{
    public class ScoreHistory
    {
        private PollMember pollMember;
        private ShownMatch shownMatch;
        private int score;

        public ScoreHistory() { }

        public PollMember PollMember
        {
            get { return pollMember; }
            set { pollMember = value; }
        }
        public ShownMatch ShownMatch
        {
            set {  shownMatch = value; }
            get { return shownMatch; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public List<ScoreHistory> GetScoreHistories()
        {
            DataBase database = new DataBase();
            database.Connect();
            List<ScoreHistory> output = database.SelectScoreHistory();
            database.Disconnect();

            return output;
        }
    }
}
