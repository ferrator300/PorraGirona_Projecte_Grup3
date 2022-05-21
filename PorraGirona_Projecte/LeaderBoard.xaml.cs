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
            dataGrid_leaderBoard.ItemsSource = pl.GetAll();
            dataGrid_members.ItemsSource = pl.GetAll();
            dataGrid_clubs.ItemsSource = cl.GetAll();
            dataGrid_matchs.ItemsSource = sm.GetAll();
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
        /*
        Guia nomenclatura mètode reinciar camps
        ma --> Member Add
        mm --> Member Mod
        ca --> Club Add
        cm --> Club Mod
        ja --> Jornada Add
        jm --> Jornada Mod
         */
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

        private void RestartFields(string camp)
        {
            if (camp == "ma")
            {
                txtBox_member_adr_add.Text = "";
                txtBox_member_dni_add.Text = "";
                txtBox_member_adr_add.Text = "";
                txtBox_member_email_add.Text = "";
                txtBox_member_name_add.Text = "";
                txtBox_member_surname_add.Text = "";
            }
            else if (camp == "mm")
            {
                //Restablir a les dades de l'element seleccionat
                txtBox_member_adr_mod.Text = "";
                txtBox_member_dni_mod.Text = "";
                txtBox_member_adr_mod.Text = "";
                txtBox_member_email_mod.Text = "";
                txtBox_member_name_mod.Text = "";
                txtBox_member_surname_mod.Text = "";
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
                //Restablir a les dades de l'element seleccionat
                txtBox_club_alias_mod.Text = "";
                txtBox_club_location_mod.Text = "";
                txtBox_club_name_mod.Text = "";
                txtBox_club_stadium_mod.Text = "";
                comboBox_club_champ_mod.SelectedIndex = 0;
            }
            else if (camp == "ja")
            {
                comboBox_match_away_add.Text = "";
                comboBox_match_local_add.Text = "";
                calendar_match_add.Text = "";
            }
            else if (camp == "jm")
            {
                //Restablir a les dades de l'element seleccionat
            }
        }
    }
}
