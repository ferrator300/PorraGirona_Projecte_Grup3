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
        }

        //REFRESH DATA

        private void RefreshData()
        {
            PollMember pl = new PollMember();
            dataGrid_leaderBoard.ItemsSource = pl.GetPollMembers();
            dataGrid_members.ItemsSource = pl.GetPollMembers();
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
            lable_title.Content = title;
            dataGrid_leaderBoard.Visibility = Visibility.Hidden;
            tab_members.Visibility = Visibility.Hidden;
            tab_clubs.Visibility = Visibility.Hidden;
            tab_matchs.Visibility = Visibility.Hidden;

            

            dataGrid_leaderBoard.IsEnabled = false;
            tab_members.IsEnabled = false;
            tab_clubs.IsEnabled = false;
            tab_matchs.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //BOTÓ AFEGIR MEMBRE
        private void btn_add_member_Click(object sender, RoutedEventArgs e)
        {

        }

        private void app_close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void tab_clubs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //BOTÓ APOSTAR
        private void btn_poll_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
