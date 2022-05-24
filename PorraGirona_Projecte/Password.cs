using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGirona_Projecte
{
    public class Password
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

        //SELECT
        #region
        public List<Password> GetAll()
        {
            DataBase database = new DataBase();
            database.Connect();
            List<Password> output = database.SelectPassword();
            database.Disconnect();

            return output;
        }
        public Password GetOne(int id)
        {
            DataBase database = new DataBase();
            database.Connect();
            Password output = database.GetOnePassword(id);
            database.Disconnect();

            return output;
        }

        public static string GetPasswordFromId(int id)
        {
            DataBase database = new DataBase();
            database.Connect();
            string output = database.GetPasswordFromId(id);
            database.Disconnect();

            return output;
        }
        #endregion

        //UPDATE
        #region
        public bool ModOne(int pollMemberId, string securityKey)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.ModPassword(pollMemberId, securityKey);
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
