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

        public int AddPollMember(string name, string surname, string address, string nif, string email)
        {
            string command = $"INSERT INTO PollMember(null,'{name}','{surname}','{address}','{nif}','{email}')";

            bool dataIsValid = true;

            //PER SI VOLEM FER COMPROVACIONS A LA CLASSE BASE DE DADES

            //Comprovacions amb Regex o el mètode de validació que acabem fent servir..
            /* if (false) //nom
            {
                dataIsValid = false; 
            }
            else if (false) //cognom
            {
                dataIsValid = false;
            }   
            else if (false) //adreça
            {
                dataIsValid = false; 
            }
            else if (false) //nif
            {
                dataIsValid = false; 
            }
            else if (false) //email
            {
                dataIsValid = false; 
            }
            */

            if (dataIsValid)
            {
                try
                {
                    MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

                    oCommand.ExecuteNonQuery();

                    //Retornem true si s'ha pogut fer l'insert correctament.
                    //D'aquesta manera, el formulari xaml sabrà si el penyista s'ha afegit o no.
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
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