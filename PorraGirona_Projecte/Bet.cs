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
            get { return shownMatch; }
            set { shownMatch = value; }
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

        //SELECT
        #region
        public List<Bet> GetAll()
        {
            DataBase database = new DataBase();
            database.Connect();
            List<Bet> output = database.SelectBet();
            database.Disconnect();

            return output;
        }
        public Bet GetOne(int pollMemberId, int shownMatchId)
        {
            DataBase database = new DataBase();
            database.Connect();
            Bet output = database.GetOneBet(pollMemberId, shownMatchId);
            database.Disconnect();

            return output;
        }
        #endregion

        //INSERT
        #region
        public bool AddOne(int pollMemberId, int shownMatchId, DateTime dateTime, int localGoals, int awayGoals)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.AddBet(pollMemberId, shownMatchId, dateTime, localGoals, awayGoals);
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
        public bool ModOne(int pollMemberId, int shownMatchId, int localGoals, int awayGoals)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.ModBet(pollMemberId, shownMatchId, localGoals, awayGoals);
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
                database.RmBet(pollMemberId, shownMatchId);
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
