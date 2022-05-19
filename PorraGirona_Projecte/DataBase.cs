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
        protected string mariaDBConnectionString = "server=localhost;userid=root;database=footballpoll;port3306";
        MySqlConnection mdbConnection = null;

        public DataBase()
        {
            mdbConnection = new MySqlConnection(mariaDBConnectionString);
        }

        //Methods to start and end the connection with the database.
        #region
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
        #endregion

        //Methods to add data to the database
        #region
        public bool AddPollMember(string name, string surname, string address, string nif, string email)
        {
            string command = $"INSERT INTO PollMember values(null,'{name}','{surname}','{address}','{nif}','{email}', 0);";

            bool dataIsValid = true;

            //PER SI VOLEM FER COMPROVACIONS A LA CLASSE BASE DE DADES

            //Comprovacions amb Regex o el mètode de validació que acabem fent servir..
            #region
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
            #endregion

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
            {
                return false;
            }
        }

        public bool AddShownMatch(string dateTime, string localClubId, string awayClubId)
        {
            string command = $"INSERT INTO ShownMatch values(null,{dateTime},{localClubId},{awayClubId});";

            bool dataIsValid = true;


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
            {
                return false;
            }
        }

        public bool AddClub(string name, string shortName, string championshipId, string stadium, string locality)
        {
            string command = $"INSERT INTO Club values('{name}','{shortName}',null, {championshipId},'{stadium}','{locality}');";

            bool dataIsValid = true;


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
            {
                return false;
            }
        }
        #endregion

        //Methods to get all rows from a table
        #region
        /// <summary>
        /// Obtains all the lines of the PollMember table in the database and returns them in list form.
        /// </summary>
        /// <returns>
        /// List<string[6]>
        /// string[0] --> PollMember_ID
        /// string[1] --> Name
        /// string[2] --> Surname
        /// string[3] --> Address
        /// string[4] --> Nif
        /// string[5] --> Email
        /// string[6] --> GlobalScore
        /// </returns>
        public List<PollMember> SelectPollMember()
        {
            string command = $"SELECT * FROM PollMember;";
            
            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<PollMember> output = new List<PollMember>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    PollMember newPollMember = new PollMember();

                    newPollMember.Id = lines.GetInt32(0);
                    newPollMember.Name = lines.GetString(1);
                    newPollMember.Surname = lines.GetString(2);
                    newPollMember.Address = lines.GetString(3);
                    newPollMember.Nif = lines.GetString(4);
                    newPollMember.Email = lines.GetString(5);
                    newPollMember.GlobalScore = lines.GetInt32(6);

                    output.Add(newPollMember);
                }

                lines.Close();
                return output;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        /// <summary>
        /// Obtains all the lines of the ShownMatch table in the database and returns them in list form.
        /// </summary>
        /// <returns>
        /// List<string[4]>
        /// string[0] --> ShownMatch_ID
        /// string[1] --> Match_dateTime
        /// string[2] --> LocalClub_ID
        /// string[3] --> AwayClub_ID
        /// </returns>
        public List<string[]> SelectShownMatch() 
        {
            string command = $"SELECT * FROM ShownMatch;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<string[]> output = new List<string[]>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    string[] str = new string[4];
                    str[0] = lines.GetInt32(0).ToString();
                    str[1] = lines.GetDateTime(1).ToString();
                    str[2] = lines.GetInt32(2).ToString();
                    str[3] = lines.GetInt32(3).ToString();

                    output.Add(str);
                }

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains all the lines of the SelectScoreHistory table in the database and returns them in list form.
        /// </summary>
        /// <returns>
        /// List<string[3]>
        /// string[0] --> PollMember_ID
        /// string[1] --> ShownMatch_ID
        /// string[2] --> Score
        /// </returns>
        public List<string[]> SelectScoreHistory()
        {
            string command = $"SELECT * FROM ScoreHistory;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<string[]> output = new List<string[]>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    string[] str = new string[3];
                    str[0] = lines.GetInt32(0).ToString();
                    str[1] = lines.GetInt32(1).ToString();
                    str[2] = lines.GetInt32(2).ToString();


                    output.Add(str);
                }

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains all the lines of the Bet table in the database and returns them in list form.
        /// </summary>
        /// <returns>
        /// List<string[5]>
        /// string[0] --> PollMember_ID
        /// string[1] --> ShownMatch_ID
        /// string[2] --> Submission_time
        /// string[3] --> Local_goals
        /// string[4] --> Away_goals
        /// </returns>
        public List<string[]> SelectBet()
        {
            string command = $"SELECT * FROM Bet;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<string[]> output = new List<string[]>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    string[] str = new string[5];
                    str[0] = lines.GetInt32(0).ToString();
                    str[1] = lines.GetInt32(1).ToString();
                    str[2] = lines.GetDateTime(2).ToString();
                    str[3] = lines.GetInt32(3).ToString();
                    str[4] = lines.GetInt32(4).ToString();


                    output.Add(str);
                }

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains all the lines of the MatchResult table in the database and returns them in list form.
        /// </summary>
        /// <returns>
        /// List<string[3]>
        /// string[0] --> ShownMatch_ID
        /// string[1] --> Local_goals
        /// string[2] --> Away_Goals
        /// </returns>
        public List<string[]> SelectMatchResult()
        {
            string command = $"SELECT * FROM ScoreHistory;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<string[]> output = new List<string[]>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    string[] str = new string[3];
                    str[0] = lines.GetInt32(0).ToString();
                    str[1] = lines.GetInt32(1).ToString();
                    str[2] = lines.GetInt32(2).ToString();


                    output.Add(str);
                }

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains all the lines of the Club table in the database and returns them in list form.
        /// </summary>
        /// <returns>
        /// List<string[6]>
        /// string[0] --> Name
        /// string[1] --> Short_name
        /// string[2] --> Club_ID
        /// string[3] --> Championship_ID
        /// string[4] --> Stadium
        /// string[5] --> Locality
        /// </returns>
        public List<string[]> SelectClub()
        {
            string command = $"SELECT * FROM Club;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<string[]> output = new List<string[]>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    string[] str = new string[6];
                    str[0] = lines.GetString(0);
                    str[1] = lines.GetString(1);
                    str[2] = lines.GetInt32(2).ToString();
                    str[3] = lines.GetInt32(3).ToString();
                    str[3] = lines.GetString(4);
                    str[5] = lines.GetString(5);


                    output.Add(str);
                }

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains all the lines of the Championship table in the database and returns them in list form.
        /// </summary>
        /// <returns>
        /// List<string[4]>
        /// string[0] --> Name
        /// string[1] --> Championship_ID
        /// string[2] --> Division
        /// string[3] --> Club_Slots
        /// </returns>
        public List<string[]> SelectChampionship()
        {
            string command = $"SELECT * FROM Championship;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<string[]> output = new List<string[]>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    string[] str = new string[4];
                    str[0] = lines.GetString(0);
                    str[1] = lines.GetInt32(1).ToString();
                    str[2] = lines.GetInt32(2).ToString();
                    str[3] = lines.GetInt32(3).ToString();

                    output.Add(str);
                }

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
#endregion

        //Methods to get just one row from the database
        #region
        /// <summary>
        /// Obtains the data from one row of the PollMember table in the database and returns it in an array.
        /// </summary>
        /// <returns>
        /// string[0] --> PollMember_ID
        /// string[1] --> Name
        /// string[2] --> Surname
        /// string[3] --> Address
        /// string[4] --> Nif
        /// string[5] --> Email
        /// </returns>
        public string[] GetOnePollMember(string pollMemberId)
        {
            string command = $"SELECT * FROM PollMember WHERE PollMember_ID = {pollMemberId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[7];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                output[0] = lines.GetInt32(0).ToString();
                output[1] = lines.GetString(1);
                output[2] = lines.GetString(2);
                output[3] = lines.GetString(3);
                output[4] = lines.GetString(4);
                output[5] = lines.GetString(5);
                output[6] = lines.GetInt32(6).ToString();
                
                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains the data from one row of the ShownMatch table in the database and returns it in an array.
        /// </summary>
        /// <returns>
        /// string[0] --> ShownMatch_ID
        /// string[1] --> Match_dateTime
        /// string[2] --> LocalClub_ID
        /// string[3] --> AwayClub_ID
        /// </returns>
        public string[] GetOneShownMatch(string shownMatchId)
        {
            string command = $"SELECT * FROM ShownMatch WHERE ShownMatch_ID = {shownMatchId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[4];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                output[0] = lines.GetInt32(0).ToString();
                output[1] = lines.GetDateTime(1).ToString();
                output[2] = lines.GetInt32(2).ToString();
                output[3] = lines.GetInt32(3).ToString();

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains the data from one row of the PollMember table in the database and returns it in an array.
        /// </summary>
        /// <returns>
        /// string[0] --> PollMember_ID
        /// string[1] --> ShownMatch_ID
        /// string[2] --> Score
        /// </returns>
        public string[] GetOneScoreHistory(string pollMemberId, string shownMatchId)
        {
            string command = $"SELECT * FROM ScoreHistory WHERE PollMember_ID = {pollMemberId} AND ShownMatch_ID = {shownMatchId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[3];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                output[0] = lines.GetInt32(0).ToString();
                output[1] = lines.GetInt32(1).ToString();
                output[2] = lines.GetInt32(2).ToString();

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains the data from one row of the Bet table in the database and returns it in an array.
        /// </summary>
        /// <returns>
        /// string[0] --> PollMember_ID
        /// string[1] --> ShownMatch_ID
        /// string[2] --> Submission_time
        /// string[3] --> Local_goals
        /// string[4] --> Away_goals
        /// </returns>
        public string[] GetOneBet(string pollMemberId, string shownMatchId)
        {
            string command = $"SELECT * FROM Bet WHERE PollMember_ID = {pollMemberId} AND ShownMatch_ID = {shownMatchId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[5];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
        {
                output[0] = lines.GetInt32(0).ToString();
                output[1] = lines.GetInt32(1).ToString();
                output[2] = lines.GetDateTime(2).ToString();
                output[3] = lines.GetInt32(3).ToString();
                output[4] = lines.GetInt32(4).ToString();

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains the data from one row of the MatchResult table in the database and returns it in an array.
        /// </summary>
        /// <returns>
        /// string[0] --> ShownMatch_ID
        /// string[1] --> Local_goals
        /// string[2] --> Away_Goals
        /// </returns>
        public string[] GetOneMatchResult(string shownMatchId)
        {
            string command = $"SELECT * FROM ScoreHistory WHERE ShownMatch_ID = {shownMatchId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[3];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                output[0] = lines.GetInt32(0).ToString();
                output[1] = lines.GetInt32(1).ToString();
                output[2] = lines.GetInt32(2).ToString();

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains the data from one row of the Club table in the database and returns it in an array.
        /// </summary>
        /// <returns>
        /// string[0] --> Name
        /// string[1] --> Short_name
        /// string[2] --> Club_ID
        /// string[3] --> Championship_ID
        /// string[4] --> Stadium
        /// string[5] --> Locality
        /// </returns>
        public string[] GetOneClub(string clubId)
        {
            string command = $"SELECT * FROM Club WHERE Club_ID = {clubId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[6];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                output[0] = lines.GetString(0);
                output[1] = lines.GetString(1);
                output[2] = lines.GetInt32(2).ToString();
                output[3] = lines.GetInt32(3).ToString();
                output[3] = lines.GetString(4);
                output[5] = lines.GetString(5);

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtains the data from one row of the Championship table in the database and returns it in an array.
        /// </summary>
        /// <returns>
        /// string[0] --> Name
        /// string[1] --> Championship_ID
        /// string[2] --> Division
        /// string[3] --> Club_Slots
        /// </returns>
        public string[] GetOneChampionship(string championshipId)
        {
            string command = $"SELECT * FROM Championship WHERE Championship_ID = {championshipId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[4];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                output[0] = lines.GetString(0);
                output[1] = lines.GetInt32(1).ToString();
                output[2] = lines.GetInt32(2).ToString();
                output[3] = lines.GetInt32(3).ToString();

                lines.Close();
                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

#endregion

        //Mètode per tornar una select d'una sola columna. (legacy)
        #region
        //public List<string> SelectPollMember(int column)
        //{
        //    string command = $"SELECT * FROM PollMember;";

        //    MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

        //    List<string> output = new List<string>();

        //    MySqlDataReader lines = oCommand.ExecuteReader();

        //    try
        //    {
        //        switch (column)
        //        {
        //            case 1:
        //                {
        //                    while (lines.Read())
        //                    {
        //                        string str = "";
        //                        str = lines.GetInt32(0).ToString();
        //                        output.Add(str);
        //                    }
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    while (lines.Read())
        //                    {
        //                        string str = "";
        //                        str = lines.GetString(1);
        //                        output.Add(str);
        //                    }
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    while (lines.Read())
        //                    {
        //                        string str = "";
        //                        str = lines.GetString(3);
        //                        output.Add(str);
        //                    }
        //                    break;
        //                }
        //            case 4:
        //                {
        //                    while (lines.Read())
        //                    {
        //                        string str = "";
        //                        str = lines.GetString(4);
        //                        output.Add(str);
        //                    }
        //                    break;
        //                }
        //            case 5:
        //                {
        //                    while (lines.Read())
        //                    {
        //                        string str = "";
        //                        str = lines.GetString(5);
        //                        output.Add(str);
        //                    }
        //                    break;
        //                }
        //            case 6:
        //                {
        //                    while (lines.Read())
        //                    {
        //                        string str = "";
        //                        str = lines.GetString(6);
        //                        output.Add(str);
        //                    }
        //                    break;
        //                }
        //        }

        //        lines.Close();
        //        return output;
        //    }
        //    catch(Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion

        //Operation Methods
        #region
        public int GetPoints(int pollMemberId, string[] matchResult)
        {
            int score = 0;

            int shownMatchId;

            int finalLocalGoals;
            int finalAwayGoals;

            int betLocalGoals;
            int betAwayGoals;

            try
            {
                shownMatchId = Convert.ToInt32(matchResult[0]);
                finalLocalGoals = Convert.ToInt32(matchResult[1]);
                finalAwayGoals = Convert.ToInt32(matchResult[2]);
            }
            catch
            {
                return -1;
            }

            string command = $"SELECT Local_goals, Away_goals" +
                                $"FROM Bet WHERE PollMember_ID = {pollMemberId} AND ShownMatch_ID = {shownMatchId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            MySqlDataReader lines = oCommand.ExecuteReader();

            betLocalGoals = lines.GetInt32(3);
            betAwayGoals = lines.GetInt32(4);

            while (lines.Read())
            {
                //matchResult[1] = localGoals       matchResult[2] = awayGoals
                if (finalLocalGoals == betLocalGoals && finalAwayGoals == betAwayGoals)
                {
                    score = 5;
                }
                else
                {
                    if (finalLocalGoals == betLocalGoals || finalAwayGoals == betAwayGoals)
                    {
                        score = 4;
                    }
                    else if ((betLocalGoals > betAwayGoals && finalLocalGoals > finalAwayGoals) ||
                        (betLocalGoals < betAwayGoals && finalLocalGoals < finalAwayGoals) ||
                        betLocalGoals == betAwayGoals && finalLocalGoals == finalAwayGoals)
                    {
                        score = 3;
                    }
                    else if (Math.Abs(betLocalGoals - finalLocalGoals) == 1 && Math.Abs(betAwayGoals - finalAwayGoals) == 1)
                    {
                        score = 2;
                    }
                    else
                        score = 1;
                }
            }

            return score;
        }
        #endregion

        // ----- FINAL MIQUEL

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