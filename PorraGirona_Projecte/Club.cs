using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorraGirona_Projecte
{
    public class Club
    {
        private string name;
        private string shortName;
        private int id;
        private Championship championship;
        private string stadium;
        private string locality;

        public Club() { }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Championship Championship
        {
            get {  return championship; }
            set {  championship = value;}
        }
        public string Stadium
        {
            get { return stadium; }
            set { stadium = value; }
        }
        public string Locality
        {
            get { return locality; }
            set { locality = value; }
        }

        //SELECT
        #region
        public List<Club> GetAll()
        {
            DataBase database = new DataBase();
            database.Connect();
            List<Club> output = database.SelectClub();
            database.Disconnect();

            return output;
        }
        public Club GetOne(int id)
        {
            DataBase database = new DataBase();
            database.Connect();
            Club output = database.GetOneClub(id);
            database.Disconnect();

            return output;
        }
        #endregion

        //INSERT
        #region
        public bool AddOne(string name, string shortName, int championshipId, string stadium, string locality)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.AddClub(name, shortName, championshipId, stadium, locality);
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
        public bool ModOne(int id, string name, string shortName, int championshipId, string stadium, string locality)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.ModClub(id, name, shortName, championshipId, stadium, locality);
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
                database.RmClub(id);
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