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
    }
}