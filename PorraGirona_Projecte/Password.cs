using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona_Projecte
{
    internal class Password
    {
        private PollMember pollMember;
        private string securityKey;

        public Password() { }

        public PollMember PollMember
        {
            get { return pollMember; }
            set { pollMember = value; }
        }
        public string SecurityKey
        {
            get { return securityKey; }
            set { securityKey = value; }
        }
    }
}
