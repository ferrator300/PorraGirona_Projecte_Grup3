using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorraGirona_Projecte
{
    public class PollMember
    {
        private bool admin;
        private int id;
        private string name;
        private string surname;
        private string address;
        private string nif;
        private string email;
        private int globalScore;

        //public PollMember()
        //{
        //    DataBase database = new DataBase();
        //}
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool Admin
        { 
            get {  return admin; } 
            set { admin = value; } 
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int GlobalScore
        {
            get { return globalScore; }
            set { globalScore = value; }
        }

        //SELECT
        #region
        public List<PollMember> GetAll()
        {
            DataBase database = new DataBase();
            database.Connect();
            List<PollMember> output = database.SelectPollMember();
            database.Disconnect();

            return output;
        }
        public PollMember GetOne(int id)
        {
            DataBase database = new DataBase();
            database.Connect();
            PollMember output = database.GetOnePollMember(id);
            database.Disconnect();

            return output;
        }

        public static int GetIdFromNif(string nif)
        {
            DataBase database = new DataBase();
            database.Connect();
            int output = database.GetOnePollMemberId(nif);
            database.Disconnect();

            return output;
        }
        #endregion

        //INSERT
        #region
        public bool AddOne(string name, string surname, string address, string nif, string email)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.AddPollMember(name, surname, address, nif, email);
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
        public bool ModOne(int id, string name, string surname, string address, string nif, string email)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.ModMember(id, name, surname, address, nif, email);
                database.Disconnect();

                return true;
            }
            catch(Exception ex)
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
                database.RmMember(id);
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