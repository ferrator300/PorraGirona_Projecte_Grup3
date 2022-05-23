using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PorraGirona_Projecte
{
    /// <summary>
    /// Lógica de interacción para LeaderBoard.xaml
    /// </summary>
    public partial class LeaderBoard : Window
    {
        public LeaderBoard()
        {
            InitializeComponent();
            RefreshData();

            //Mostrem com apartat principal la llista de puntuacions
            ChangeTab("LLISTA PUNTUACIONS");
            dataGrid_leaderBoard.Visibility = Visibility.Visible;
            dataGrid_leaderBoard.IsEnabled = true;

        }

        /// <summary>
        /// Enllaçem les dades de la base de dades per mostrar la informació pertinent a cada apartat
        /// </summary>
        //REFRESH DATA
        private void RefreshData()
        {
            PollMember pl = new PollMember();
            Club cl = new Club();
            ShownMatch sm = new ShownMatch();
            MatchResult mr = new MatchResult();
            Championship ch = new Championship();

            dataGrid_leaderBoard.ItemsSource = pl.GetAll();
            dataGrid_members.ItemsSource = pl.GetAll();
            dataGrid_clubs.ItemsSource = cl.GetAll();
            dataGrid_matchs.ItemsSource = sm.GetAll();

            comboBox_id_mod.ItemsSource = pl.GetAll();
            comboBox_club_name_mod.ItemsSource = cl.GetAll();
            comboBox_club_champ_add.ItemsSource = ch.GetAll();
            comboBox_club_champ_mod.ItemsSource = ch.GetAll();
            comboBox_leaderboard_jornada.ItemsSource = sm.GetAll();
            comboBox_match_away_add.ItemsSource = cl.GetAll();
            comboBox_match_away_mod.ItemsSource = cl.GetAll();
            comboBox_match_local_add.ItemsSource = cl.GetAll();
            comboBox_match_local_mod.ItemsSource= cl.GetAll();

            comboBox_club_name_mod.ItemsSource = cl.GetAll();
            comboBox_club_champ_mod.ItemsSource = ch.GetAll();

            
        }

        //LEADERBOARD
        private void btn_leaderBoard_Click(object sender, RoutedEventArgs e)
        {
            ChangeTab("LLISTA PUNTUACIONS");
            dataGrid_leaderBoard.Visibility = Visibility.Visible;
            dataGrid_leaderBoard.IsEnabled = true; 
        }

        //MEMBERS
        private void btn_members_Click(object sender, RoutedEventArgs e)
        {
            ChangeTab("MEMBRES");
            tab_members.Visibility = Visibility.Visible;
            tab_members.IsEnabled = true;
        }

        //CLUBS
        private void btn_clubs_Click(object sender, RoutedEventArgs e)
        {
            ChangeTab("EQUIPS");
            tab_clubs.Visibility = Visibility.Visible;
            tab_clubs.IsEnabled = true;
        }

        //MATCHES
        private void btn_matches_Click(object sender, RoutedEventArgs e)
        {
            ChangeTab("JORNADES");
            tab_matchs.Visibility = Visibility.Visible;
            tab_matchs.IsEnabled = true;
        }

        //LOGOUT
        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Owner = this;
            this.Hide();
            mw.ShowDialog();
        }

        /// <summary>
        /// Mètode per canviar entre apartats de l'aplicació, amaga tots els panells i els deshabilita.
        /// S'ha d'habilitar individualment cada panell quan es necessiti.
        /// </summary>
        /// <param name="title"></param>
        private void ChangeTab(string title)
        {
            //Canviem el titol per el entrat per paràmetre
            lable_title.Content = title;

            //Amagem els panells de cada apartat
            dataGrid_leaderBoard.Visibility = Visibility.Hidden;
            tab_members.Visibility = Visibility.Hidden;
            tab_clubs.Visibility = Visibility.Hidden;
            tab_matchs.Visibility = Visibility.Hidden;
            tab_poll.Visibility = Visibility.Hidden;

            //Deshabilitem els panells de cada apartat
            dataGrid_leaderBoard.IsEnabled = false;
            tab_members.IsEnabled = false;
            tab_clubs.IsEnabled = false;
            tab_matchs.IsEnabled = false;
            tab_poll.IsEnabled = false;

            //Definim per defecte la pestanya de Llista de cada apartat cada cop que hi accedim
            tab_list_clubs.IsSelected = true;
            tab_list_match.IsSelected = true;
            tab_list_member.IsSelected = true;
        }

        //BOTÓ AFEGIR MEMBRE
        private void btn_add_member_Click(object sender, RoutedEventArgs e)
        {
            PollMember pl = new PollMember();
            try
            {
                //Agafem els txtBox de l'apartat Afegir Membre
                //Inserim un nou membre amb els contigunts de cada txtBox a la base de dades 
                pl.AddOne(
                    txtBox_member_name_add.Text,        //Nom
                    txtBox_member_surname_add.Text,     //Cognom
                    txtBox_member_adr_add.Text,         //Adreça 
                    txtBox_member_dni_add.Text,         //Dni
                    txtBox_member_email_add.Text        //Email
                    );
                RefreshData();
                RestartFields("ma");
                MessageBox.Show("MEMBRE AFEGIT CORRECTAMENT");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Camp buit o no vàlid\n{ex.Message}");
            }
        }
        //BOTÓ MOD MEMBRE
        private void btn_mod_member_Click(object sender, RoutedEventArgs e)
        {
            PollMember pm = new PollMember();
            try
            {
                pm.ModOne(((PollMember)comboBox_id_mod.SelectedItem).Id, 
                    txtBox_member_name_add.Text, txtBox_member_surname_mod.Text,
                    txtBox_member_adr_mod.Text, txtBox_member_dni_mod.Text, txtBox_member_email_mod.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Camp buit o no vàlid\n{ex.Message}");
            }
        }
        //BOTÓ DELETE MEMBRE
        private void btn_membre_delete_Click(object sender, RoutedEventArgs e)
        {
            PollMember pm = new PollMember();
            try
            {
                //Agafem el valor del comboBox sleccionat
                //Borrem el membre seleccionat de la base de dades
                pm.RemoveOne(((PollMember)comboBox_id_mod.SelectedItem).Id);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Camp buit o no vàlid\n{ex.Message}");
            }
        }

        //BOTÓ AFEGIR CLUB
        private void btn_add_club_Click(object sender, RoutedEventArgs e)
        {
            Club cl = new Club();
            Championship championship = new Championship();
            int id;
            try
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //Buscar la Id del Championship seleccionat en el comboBox
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!

                // ## SOLUCIONAT

                //Agafem els txtBox de l'apartat Afegir Club
                //Inserim un nou club amb els contigunts de cada txtBox a la base de dades 
                cl.AddOne(
                    txtBox_club_name_add.Text,                                  //Nom 
                    txtBox_club_alias_add.Text,                                 //Alias
                    ((Championship)comboBox_club_champ_add.SelectedItem).Id,    //Id Campionat
                    txtBox_club_stadium_add.Text,                               //Estadi
                    txtBox_club_location_add.Text                               //Localització
                    );
                RefreshData();
                RestartFields("ca");
                MessageBox.Show("CLUB AFEGIT CORRECTAMENT");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Camp buit o no vàlid\n{ex.Message}");
            }
        }
        //BOTÓ MOD CLUB
        private void btn_mod_club_Click(object sender, RoutedEventArgs e)
        {
            Club cl = new Club();
            Championship ch = new Championship();
            try
            {
                cl.ModOne(Convert.ToInt32(txtBox_club_id_mod.Text), ((Club)comboBox_club_name_mod.SelectedItem).Name,
                    txtBox_club_alias_mod.Text, ((Championship)comboBox_club_champ_mod.SelectedItem).Id,
                    txtBox_club_stadium_mod.Text, txtBox_club_location_mod.Text);

                MessageBox.Show("Equip modificat correctament.");
                RestartFields("cm");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Camp buit o no vàlid\n{ex.Message}");
            }
        }
        //BOTÓ DELETE CLUB
        private void btn_delete_club_Click(object sender, RoutedEventArgs e)
        {
            Club cl = new Club();
            try
            {
                //Agafem el valor del comboBox sleccionat
                //Borrem el club seleccionat de la base de dades
                cl.RemoveOne(((Club)comboBox_club_name_mod.SelectedItem).Id);
                //comboBox_club_name_mod.Text = "";
                RestartFields("cm");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Camp buit o no vàlid\n{ex.Message}");

                //NullReferenceException
            }
        }

        //BOTÒ AFEGIR JORNADA
        private void btn_add_match_Click(object sender, RoutedEventArgs e)
        {
            ShownMatch sm = new ShownMatch();
            Club local = new Club();
            Club away = new Club();

            try
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //Buscar id club local a partir del nom en ComboBox
                //Buscar id club visitant a partir del nom en ComboBox
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!

                // ## SOLUCIONAT

                //Agafem els txtBox de l'apartat Afegir Jornada
                //Inserim una nova jornada amb els contigunts de cada txtBox a la base de dades 
                sm.AddOne(
                    DateTime.Parse(calendar_match_add.Text),          //Data Jornada
                    ((Club)comboBox_match_local_add.SelectedItem).Id, //Id local
                    ((Club)comboBox_match_away_add.SelectedItem).Id   //ID visitant
                    );
                RefreshData();
                RestartFields("ja");
                MessageBox.Show("JORNADA AFEGIDA CORRECTAMENT");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Camp buit o no vàlid\n{ex.Message}");
            }
        }
        //BOTÓ MOD JORNADA
        private void btn_mod_match_Click(object sender, RoutedEventArgs e)
        {   
            ShownMatch sm = new ShownMatch();
            try
            {
                //Falta un comboBox per poder triar la jornada. 
                //Si no, s'haurà de fer un mètode de select que busqui a partir d'equip local, equip visitant i data.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Camp buit o no vàlid\n{ex.Message}");
            }
        }
        //BOTÓ DELETE JORNADA
        private void btn_delete_match_Click(object sender, RoutedEventArgs e)
        {
            ShownMatch sm = new ShownMatch();
            try
            {
                //Falta un comboBox per poder triar la jornada. 
                //Si no, s'haurà de fer un mètode de select que busqui a partir d'equip local, equip visitant i data.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Camp buit o no vàlid\n{ex.Message}");
            }
        }

        //Mètode que s'aplica al tancar l'aplicació
        private void app_close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        //BOTÓ APOSTAR
        private void btn_poll_click(object sender, RoutedEventArgs e)
        {
            ChangeTab("APOSTAR");
            tab_poll.Visibility = Visibility.Visible;
            tab_poll.IsEnabled = true;
        }

        //BOTONS REINICIAR CAMPS
        private void btn_restart_club_mod_Click(object sender, RoutedEventArgs e)
        {
            RestartFields("cm");
        }
        private void btn_restart_club_add_Click(object sender, RoutedEventArgs e)
        {
            RestartFields("ca");
        }
        private void btn_restart_member_add_Click(object sender, RoutedEventArgs e)
        {
            RestartFields("ma");
        }
        private void btn_restart_member_mod_Click(object sender, RoutedEventArgs e)
        {
            RestartFields("mm");
        }
        private void btn_restart_match_add_Click(object sender, RoutedEventArgs e)
        {
            RestartFields("ja");
        }
        private void btn_restart_match_mod_Click(object sender, RoutedEventArgs e)
        {
            RestartFields("jm");
        }

        /// <summary>
        ///Guia nomenclatura mètode reinciar camps
        ///<br>ma --> Member Add</br>
        ///<br>mm --> Member Mod</br>
        ///<br>ca --> Club Add</br>
        ///<br>cm --> Club Mod</br>
        ///<br>ja --> Jornada Add</br>
        ///<br>jm --> Jornada Mod</br>
        /// </summary>
        /// <param name="camp">nomenclatura anterior</param>
        private void RestartFields(string camp)
        {
            if (camp == "ma")
            {
                txtBox_member_adr_add.Text = "";
                txtBox_member_dni_add.Text = "";
                txtBox_member_email_add.Text = "";
                txtBox_member_name_add.Text = "";
                txtBox_member_surname_add.Text = "";
            }
            else if (camp == "mm")
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //Restablir a les dades de l'element seleccionat
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!

                txtBox_member_adr_mod.Text = "";
                txtBox_member_dni_mod.Text = "";
                txtBox_member_email_mod.Text = "";
                txtBox_member_name_mod.Text = "";
                txtBox_member_surname_mod.Text = "";

                RestoreMember();
            }
            else if (camp == "ca")
            {
                txtBox_club_alias_add.Text = "";
                txtBox_club_location_add.Text = "";
                txtBox_club_name_add.Text = "";
                txtBox_club_stadium_add.Text = "";
                comboBox_club_champ_add.SelectedIndex = 0;
            }
            else if (camp == "cm")
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //Restablir a les dades de l'element seleccionat
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!

                txtBox_club_alias_mod.Text = "";
                txtBox_club_location_mod.Text = "";
                txtBox_club_id_mod.Text = "";
                txtBox_club_stadium_mod.Text = "";
                comboBox_club_champ_mod.SelectedIndex = -1;
            }
            else if (camp == "ja")
            {
                comboBox_match_away_add.Text = "";
                comboBox_match_local_add.Text = "";
                calendar_match_add.Text = "";
            }
            else if (camp == "jm")
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //Restablir a les dades de l'element seleccionat
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }

        private void comboBox_club_mod_change(object sender, SelectionChangedEventArgs e)
        {
            RestoreClub();
        }

        private void comboBox_id_member_mod(object sender, SelectionChangedEventArgs e)
        {
            RestoreMember();
        }

        private void RestoreMember()
        {
            PollMember pl = new PollMember();
            pl = pl.GetOne(((PollMember)comboBox_id_mod.SelectedItem).Id);
            txtBox_member_adr_mod.Text = pl.Address;
            txtBox_member_dni_mod.Text = pl.Nif;
            txtBox_member_adr_mod.Text = pl.Address;
            txtBox_member_email_mod.Text = pl.Email;
            txtBox_member_name_mod.Text = pl.Name;
            txtBox_member_surname_mod.Text = pl.Surname;
        }
        private void RestoreClub()
        {
            Club cl = new Club();
            cl = cl.GetOne(((Club)comboBox_club_name_mod.SelectedItem).Id);
            txtBox_club_alias_mod.Text = cl.ShortName;
            txtBox_club_location_mod.Text = cl.Locality;
            comboBox_club_name_mod.SelectedItem = cl.Name;
            txtBox_club_id_mod.Text = cl.Id.ToString();
            txtBox_club_stadium_mod.Text = cl.Stadium;
            comboBox_club_champ_mod.SelectedItem = cl.Championship; //NO VA! Cal buscar com fer un canvi de camp en un combobox sense saber-ne l'índex.
        }
    }
}
