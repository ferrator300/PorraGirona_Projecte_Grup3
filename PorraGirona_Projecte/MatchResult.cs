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

        //SELECT
        #region
        public List<MatchResult> GetAll()
        {
            DataBase database = new DataBase();
            database.Connect();
            List<MatchResult> output = database.SelectMatchResult();
            database.Disconnect();

            return output;
        }
        public MatchResult GetOne(int shownMatchId)
        {
            DataBase database = new DataBase();
            database.Connect();
            MatchResult output = database.GetOneMatchResult(shownMatchId);
            database.Disconnect();

            return output;
        }
        #endregion

        //INSERT
        #region
        public bool AddOne(int shownMatchId, int localGoals, int awayGoals)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.AddMatchResult(shownMatchId, localGoals, awayGoals);
                database.AssignScoreToAllMembers(shownMatchId, localGoals, awayGoals);
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
        public bool ModOne(int shownMatchId, int localGoals, int awayGoals)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.ModMatchResult(shownMatchId, localGoals, awayGoals);
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
        public bool RemoveOne(int shownMatchId)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.RmMatchResult(shownMatchId);
                database.Disconnect();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        protected void UpdateGlobalScore()
        {
            DataBase database = new DataBase();


            
        }

        
    }
}
