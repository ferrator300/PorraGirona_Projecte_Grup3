using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorraGirona_Projecte
{
    public class ShownMatch
    {
        //private System.DateTime sm_dateTime;
        //private int sm_localGoals;
        //private int sm_awayGoals;
        //private int sm_id;
        //private bool sm_open;

        //public ShownMatch() { }
        //public int Sm_localGoals
        //{
        //    get { return sm_localGoals; }
        //    set { sm_localGoals = value; }
        //}
        //public Championship Championship
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        //public Club LocalClub
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        //public Club AwayClub
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        private int id;
        private DateTime dateTime;
        private Club localClub;
        private Club awayClub;

        public ShownMatch() { }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        public Club LocalClub
        {
            get { return localClub; }
            set { localClub = value; }
        }
        public Club AwayClub
        {
            get {  return awayClub; }
            set { awayClub = value; }
        }

        //SELECT
        #region
        public List<ShownMatch> GetAll()
        {
            DataBase database = new DataBase();
            database.Connect();
            List<ShownMatch> output = database.SelectShownMatch();
            database.Disconnect();

            return output;
        }
        public ShownMatch GetOne(int id)
        {
            DataBase database = new DataBase();
            database.Connect();
            ShownMatch output = database.GetOneShownMatch(id);
            database.Disconnect();

            return output;
        }

        public static ShownMatch GetLastShownMatch()
        {
            DataBase database = new DataBase();
            database.Connect();
            ShownMatch output = database.GetLastShownMatch();
            database.Disconnect();

            return output;
        }
        #endregion

        //INSERT
        #region
        public bool AddOne(DateTime dateTime, int localClubId, int awayClubId)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.AddShownMatch(dateTime, localClubId, awayClubId);
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
        public bool ModOne(int id, DateTime dateTime, int localClubId, int awayClubId)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.ModShownMatch(id, dateTime, localClubId, awayClubId);
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
        public bool RemoveOne(int id)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.RmShownMatch(id);
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