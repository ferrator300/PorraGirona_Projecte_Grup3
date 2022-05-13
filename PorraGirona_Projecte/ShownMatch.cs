using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorraGirona_Projecte
{
    public class ShownMatch
    {
        private System.DateTime sm_dateTime;
        private int sm_localGoals;
        private int sm_awayGoals;
        private int sm_id;
        private bool sm_open;

        public Championship Championship
        {
            get => default;
            set
            {
            }
        }

        public Club LocalClub
        {
            get => default;
            set
            {
            }
        }

        public Club AwayClub
        {
            get => default;
            set
            {
            }
        }
    }
}