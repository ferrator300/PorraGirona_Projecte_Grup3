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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PorraGirona_Projecte
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool admin = false;
        private bool authorized = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        public DataBase DataBase
        {
            get => default;
            set
            {
            }
        }

        private void btn_LogIn_Click(object sender, RoutedEventArgs e)
        {

            //TEST
            if (txtBox_User_LogIn.Text == "admin" && txtBox_logIn_passwd.Password.ToString() == "admin") //Comprovació extra per definir si és admin.
            {
                authorized = true;
                admin = true;

                //Classe estàtica per guardar el nif i el pollMemberId de l'usuari actual
                CurrentUser.SetAdmin();
            }
            else
            {
                if (Password.GetPasswordFromId(PollMember.GetIdFromNif(txtBox_User_LogIn.Text)) == txtBox_logIn_passwd.Password.ToString() && txtBox_logIn_passwd.Password.ToString() != "")
                {
                    authorized = true;
                    admin = true;

                    //Classe estàtica per guardar el nif i el pollMemberId de l'usuari actual
                    CurrentUser.SetUser((txtBox_User_LogIn.Text));
                }
            }
            //END TEST

            LeaderBoard ld = new LeaderBoard();
            if (authorized)
            {
                if (admin)
                {
                    ld.Owner = this;
                    this.Hide();
                    ld.ShowDialog();
                }
            }
            else
                MessageBox.Show("ERROR: Credencials incorrectes");
        }

        private void login_close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
