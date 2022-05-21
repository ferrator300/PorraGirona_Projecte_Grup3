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

        //SELECT
        #region
        public List<ScoreHistory> GetAll()
        {
            DataBase database = new DataBase();
            database.Connect();
            List<ScoreHistory> output = database.SelectScoreHistory();
            database.Disconnect();

            return output;
        }
        public ScoreHistory GetOne(int pollMemberId, int shownMatchId)
        {
            DataBase database = new DataBase();
            database.Connect();
            ScoreHistory output = database.GetOneScoreHistory(pollMemberId, shownMatchId);
            database.Disconnect();

            return output;
        }
        #endregion

        //INSERT
        #region
        public bool AddOne(int pollMemberId, int shownMatchId, int score)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.AddScoreHistory(pollMemberId, shownMatchId, score);
                database.Disconnect();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        //UPDATE
        #region
        public bool ModOne(int pollMemberId, int shownMatchId, int score)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.ModScoreHistory(pollMemberId, shownMatchId, score);
                database.Disconnect();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        //DELETE
        #region
        public bool RemoveOne(int pollMemberId, int shownMatchId)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.RmScoreHistory(pollMemberId, shownMatchId);
                database.Disconnect();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
