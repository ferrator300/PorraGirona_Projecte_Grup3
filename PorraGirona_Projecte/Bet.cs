using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona_Projecte
{
    public class Bet
    {
        private int pollMemberId { get; set; }
        private int shownMatchId { get; set; }
        private DateTime submissionTime { get; set; }
        private int localGoals { get; set; }
        private int awayGoals { get; set; }
    }
}
