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
        }

        //LEADERBOARD
        private void btn_leaderBoard_Click(object sender, RoutedEventArgs e)
        {
            ChangeTab("LLISTA PUNTUACIONS");
            dataGrid_leaderBoard.Visibility = Visibility.Visible;
        }

        //MEMBERS
        private void btn_members_Click(object sender, RoutedEventArgs e)
        {
            ChangeTab("MEMBRES");
            tab_members.Visibility = Visibility.Visible;
        }

        //CLUBS
        private void btn_clubs_Click(object sender, RoutedEventArgs e)
        {
            ChangeTab("EQUIPS");
        }

        //MATCHES
        private void btn_matches_Click(object sender, RoutedEventArgs e)
        {
            ChangeTab("JORNADES");
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

        private void ChangeTab(string title)
        {
            lable_title.Content = title;
            dataGrid_leaderBoard.Visibility = Visibility.Hidden;
            tab_members.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_add_member_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
