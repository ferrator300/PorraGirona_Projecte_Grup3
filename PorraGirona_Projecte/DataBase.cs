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
        public List<ShownMatch> SelectShownMatch() 
        {
            string command = $"SELECT * FROM ShownMatch;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<ShownMatch> output = new List<ShownMatch>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    ShownMatch newShownMatch = new ShownMatch();
                    
                    newShownMatch.Id = lines.GetInt32(0);
                    newShownMatch.DateTime = lines.GetDateTime(1);
                    newShownMatch.LocalClub = (Club)lines.GetValue(2);
                    newShownMatch.AwayClub = (Club)lines.GetValue(3);

                    output.Add(newShownMatch);
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
        public List<ScoreHistory> SelectScoreHistory()
        {
            string command = $"SELECT * FROM ScoreHistory;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<ScoreHistory> output = new List<ScoreHistory>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    ScoreHistory newScoreHistory = new ScoreHistory();
                    
                    newScoreHistory.PollMember = (PollMember)lines.GetValue(0);
                    newScoreHistory.ShownMatch = (ShownMatch)lines.GetValue(1);
                    newScoreHistory.Score = lines.GetInt32(2);


                    output.Add(newScoreHistory);
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
        public List<Bet> SelectBet()
        {
            string command = $"SELECT * FROM Bet;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<Bet> output = new List<Bet>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    Bet newBet = new Bet();
                    newBet.PollMember = (PollMember)lines.GetValue(0);
                    newBet.ShownMatch = (ShownMatch)lines.GetValue(1);
                    newBet.SubmissionTime = lines.GetDateTime(2);
                    newBet.LocalGoals = lines.GetInt32(3);
                    newBet.AwayGoals = lines.GetInt32(4);


                    output.Add(newBet);
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
        public List<MatchResult> SelectMatchResult()
        {
            string command = $"SELECT * FROM ScoreHistory;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<MatchResult> output = new List<MatchResult>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    MatchResult newMatchResult = new MatchResult();
                    newMatchResult.ShownMatch = (ShownMatch)lines.GetValue(0);
                    newMatchResult.LocalGoals = lines.GetInt32(1);
                    newMatchResult.AwayGoals = lines.GetInt32(2);


                    output.Add(newMatchResult);
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
        public List<Club> SelectClub()
        {
            string command = $"SELECT * FROM Club;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<Club> output = new List<Club>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    Club newClub = new Club();
                    newClub.Name = lines.GetString(0);
                    newClub.ShortName = lines.GetString(1);
                    newClub.Id = lines.GetInt32(2);
                    newClub.Championship = (Championship)lines.GetValue(3);
                    newClub.Stadium = lines.GetString(4);
                    newClub.Locality = lines.GetString(5);


                    output.Add(newClub);
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
        public List<Championship> SelectChampionship()
        {
            string command = $"SELECT * FROM Championship;";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            List<Championship> output = new List<Championship>();

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                while (lines.Read())
                {
                    Championship newChampionship = new Championship();
                    newChampionship.Name = lines.GetString(0);
                    newChampionship.Id = lines.GetInt32(1);
                    newChampionship.Division = lines.GetInt32(2);
                    newChampionship.ClubSlots = lines.GetInt32(3);

                    output.Add(newChampionship);
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
        public PollMember GetOnePollMember(string pollMemberId)
        {
            string command = $"SELECT * FROM PollMember WHERE PollMember_ID = {pollMemberId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[7];

            MySqlDataReader lines = oCommand.ExecuteReader();


            try
            {
                PollMember newPollMember = new PollMember();

                newPollMember.Id = lines.GetInt32(0);
                newPollMember.Name = lines.GetString(1);
                newPollMember.Surname = lines.GetString(2);
                newPollMember.Address = lines.GetString(3);
                newPollMember.Nif = lines.GetString(4);
                newPollMember.Email = lines.GetString(5);
                newPollMember.GlobalScore = lines.GetInt32(6);
                
                lines.Close();
                return newPollMember;
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
        public ShownMatch GetOneShownMatch(string shownMatchId)
        {
            string command = $"SELECT * FROM ShownMatch WHERE ShownMatch_ID = {shownMatchId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[4];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                ShownMatch newSownMatch = new ShownMatch();
                newSownMatch.Id = lines.GetInt32(0);
                newSownMatch.DateTime = lines.GetDateTime(1);
                newSownMatch.LocalClub =(Club)lines.GetValue(2);
                newSownMatch.AwayClub = (Club)lines.GetValue(3);

                lines.Close();
                return newSownMatch;
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
        public ScoreHistory GetOneScoreHistory(string pollMemberId, string shownMatchId)
        {
            string command = $"SELECT * FROM ScoreHistory WHERE PollMember_ID = {pollMemberId} AND ShownMatch_ID = {shownMatchId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[3];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                ScoreHistory newScoreHistory = new ScoreHistory();
                newScoreHistory.PollMember = (PollMember) lines.GetValue(0);
                newScoreHistory.ShownMatch = (ShownMatch) lines.GetValue(1);
                newScoreHistory.Score = lines.GetInt32(2);

                lines.Close();
                return newScoreHistory;
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
        public Bet GetOneBet(string pollMemberId, string shownMatchId)
        {
            string command = $"SELECT * FROM Bet WHERE PollMember_ID = {pollMemberId} AND ShownMatch_ID = {shownMatchId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[5];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
        {       Bet newBet = new Bet();
                newBet.PollMember = (PollMember) lines.GetValue(0);
                newBet.ShownMatch = (ShownMatch) lines.GetValue(1);
                newBet.SubmissionTime = lines.GetDateTime(2);
                newBet.LocalGoals = lines.GetInt32(3);
                newBet.AwayGoals = lines.GetInt32(4);

                lines.Close();
                return newBet;
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
        public MatchResult GetOneMatchResult(string shownMatchId)
        {
            string command = $"SELECT * FROM ScoreHistory WHERE ShownMatch_ID = {shownMatchId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[3];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                MatchResult newMatchResult = new MatchResult();
                newMatchResult.ShownMatch = (ShownMatch) lines.GetValue(0);
                newMatchResult.LocalGoals = lines.GetInt32(1);
                newMatchResult.AwayGoals = lines.GetInt32(2);

                lines.Close();
                return newMatchResult;
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
        public Club GetOneClub(string clubId)
        {
            string command = $"SELECT * FROM Club WHERE Club_ID = {clubId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[6];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                Club newClub = new Club();
                newClub.Name = lines.GetString(0);
                newClub.ShortName = lines.GetString(1);
                newClub.Id = lines.GetInt32(2);
                newClub.Championship = (Championship) lines.GetValue(3);
                newClub.Stadium = lines.GetString(4);
                newClub.Locality = lines.GetString(5);

                lines.Close();
                return newClub;
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
        public Championship GetOneChampionship(string championshipId)
        {
            string command = $"SELECT * FROM Championship WHERE Championship_ID = {championshipId};";

            MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

            string[] output = new string[4];

            MySqlDataReader lines = oCommand.ExecuteReader();

            try
            {
                Championship newChampionShip = new Championship();
                newChampionShip.Name = lines.GetString(0);
                newChampionShip.Id = lines.GetInt32(1);
                newChampionShip.Division = lines.GetInt32(2);
                newChampionShip.ClubSlots = lines.GetInt32(3);

                lines.Close();
                return newChampionShip;
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

        //Mètodes d'updates a la base de dades
        #region
        public bool ModMember(int id, string name, string surname, string address, string nif, string email)
        {
            string command = $"UPDATE PollMember " +
                    $"SET Name = '{name}', " +
                    $"Surname = '{surname}', " +
                    $"Address = '{address}', " +
                    $"Nif = '{nif}', " +
                    $"Email = '{email}' " +
                $"WHERE PollMember_ID = {id};";

            try
            {
                MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

                oCommand.ExecuteNonQuery();

                //Retornem true si s'ha pogut fer l'update correctament.
                //D'aquesta manera, el formulari xaml sabrà si el penyista s'ha afegit o no.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ModClub(int id, string name, string shortName, int championshipId, string stadium, string locality)
        {
            string command = $"UPDATE Club " +
                    $"SET Name = '{name}', " +
                    $"Short_Name = '{shortName}', " +
                    $"Championship_ID = '{championshipId}', " +
                    $"Stadium = '{stadium}', " +
                    $"Locality = '{locality}' " +
                $"WHERE Club_ID = {id};";

            try
            {
                MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

                oCommand.ExecuteNonQuery();

                //Retornem true si s'ha pogut fer l'update correctament.
                //D'aquesta manera, el formulari xaml sabrà si el penyista s'ha afegit o no.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ModShownMatch(int id, DateTime dateTime, int localClubId, int awayClubId)
        {
            string command = $"UPDATE ShownMatch " +
                    $"SET Match_dateTime = '{dateTime}', " +
                    $"LocalClub_ID = '{localClubId}', " +
                    $"AwayClub_ID = '{awayClubId}' " +
                $"WHERE ShownMatch_ID = {id};";

            try
            {
                MySqlCommand oCommand = new MySqlCommand(command, mdbConnection);

                oCommand.ExecuteNonQuery();

                //Retornem true si s'ha pogut fer l'update correctament.
                //D'aquesta manera, el formulari xaml sabrà si el penyista s'ha afegit o no.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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