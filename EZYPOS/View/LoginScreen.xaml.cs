using Common.Session;
using DAL.Repository;
using EZYPOS;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EZYPOS.View
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()) )
            {
                var LoginData = Db.Employee.GetAll().Where(x => x.LoginName == txtUser.Text && x.Password == Password.Password.ToString()).FirstOrDefault();
                if (LoginData != null)
                {
                    EZYPOS.View.SplashScreen Splash = new EZYPOS.View.SplashScreen();
                    Splash.Show();
                    await Task.Run(() => Thread.Sleep(3000));
                    MainWindowNewMenu MainUI = new MainWindowNewMenu();
                    MainUI.Show();
                    Splash.Close();
                    Close();
                    ActiveSession.ActiveUser = LoginData.Id;
                }
                else
                {
                    EZYPOS.View.MessageBox.ShowCustom("User Name Or Password is incorrect", "Error", "Ok");
                }
                
            }
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }



        private void txtPas_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                btnLogin_Click(null, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnLogin_Click(null, null);
        }
               
    }
}
