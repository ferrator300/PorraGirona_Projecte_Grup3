using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorraGirona_Projecte
{
    public class Championship
    {
        private string name;
        private int id;
        private int division;
        private int clubSlots;

        public Championship() { }

        public string Name 
        {  
            get {  return name; }
            set { name = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Division
        {
            get { return division; }
            set { division = value; }
        }
        public int ClubSlots
        {
            get { return clubSlots; }
            set { clubSlots = value; }
        }

        //SELECT
        #region
        public List<Championship> GetAll()
        {
            DataBase database = new DataBase();
            database.Connect();
            List<Championship> output = database.SelectChampionship();
            database.Disconnect();

            return output;
        }
        //public List<Championship> GetAll(bool databaseConnection)
        //{
        //    DataBase database = new DataBase();
        //    List<Championship> output;
        //    if (databaseConnection == true)
        //    {
        //        database.Connect();
        //        output = database.SelectChampionship();
        //        database.Disconnect();
        //    }
        //    else
        //    {
        //        output = database.SelectChampionship();
        //    }

        //    return output;
        //}
        public Championship GetOne(int id)
        {
            DataBase database = new DataBase();
            database.Connect();
            Championship output = database.GetOneChampionship(id);
            database.Disconnect();

            return output;
        }
        public Championship GetOne(int id, bool databaseConnection)
        {
            DataBase database = new DataBase();
            Championship output;

            if (databaseConnection)
            {
                database.Connect();
                output = database.GetOneChampionship(id);
                database.Disconnect();
            }
            else
            {
                output = database.GetOneChampionship(id);
            }
            

            return output;
        }
        #endregion

        //INSERT
        #region
        public bool AddOne(string name, int division, int clubSlots)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.AddChampionship(name, division, clubSlots);
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
        public bool ModOne(int id, string name, int division, int clubSlots)
        {
            try
            {
                DataBase database = new DataBase();
                database.Connect();
                database.ModChampionship(id, name, division, clubSlots);
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
                database.RmChampionship(id);
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