using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona_Projecte
{
    public static class CurrentUser
    {
        static string Nif;
        static int Id;

        public static void SetUser(string nif)
        {
            Nif = nif;

            Id = PollMember.GetIdFromNif(nif);
        }
        public static void SetAdmin()
        {
            Nif = "Admin";

            Id = 1;
        }

        public static string GetNif()
        {
            return Nif;
        }
        public static int GetId()
        {
            return Id;
        }
    }
}
