using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace PorraGirona_Projecte
{
    public class DataBase
    {

        //Miquel
        string mariaDBConnectionString = "server=localhost;userid=root;database=footballpoll;port3306";
        MySqlConnection mdbConnection = null;

        public DataBase()
        {
            mdbConnection = new MySqlConnection(mariaDBConnectionString);
        }

        /// <summary>
        /// Tries to establish a connection with the footballpoll database.
        /// </summary>
        /// <returns>true if the connection is successful, or false if it isn't.</returns>
        public bool Connect()
        {
            try
            {
                mdbConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Tries to disconnect from the footballpoll database.
        /// </summary>
        /// <returns>true if the disconnection is successful, or false if it isn't.</returns>
        public bool Disconnect()
        {
            try
            {
                mdbConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //

        //DANIIL

        //
        public ShownMatch ShownMatch
        {
            get => default;
            set
            {
            }
        }

        public PollMember PollMember
        {
            get => default;
            set
            {
            }
        }

        public void bd_AddShownMatch()
        {
            throw new System.NotImplementedException();
        }

        public void bd_ModShownMatch()
        {
            throw new System.NotImplementedException();
        }

        public void bd_RemoveShownMatch()
        {
            throw new System.NotImplementedException();
        }

        public void bd_AddPollMember()
        {
            throw new System.NotImplementedException();
        }

        public void bd_ModPollMember()
        {
            throw new System.NotImplementedException();
        }

        public void bd_RemovePollMember()
        {
            throw new System.NotImplementedException();
        }

        public void bd_AddClub()
        {
            throw new System.NotImplementedException();
        }

        public void bd_ModClub()
        {
            throw new System.NotImplementedException();
        }

        public void bd_RemoveClub()
        {
            throw new System.NotImplementedException();
        }

        public void bd_CheckShownMatch()
        {
            throw new System.NotImplementedException();
        }

        public void bd_CheckClub()
        {
            throw new System.NotImplementedException();
        }

        public void bd_CheckPollMember()
        {
            throw new System.NotImplementedException();
        }

        public void bd_Points()
        {
            throw new System.NotImplementedException();
        }

        public void bd_CalculatePoints()
        {
            throw new System.NotImplementedException();
        }
    }
}