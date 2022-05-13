using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace EZYPOS.View
{
    /// <summary>
    /// Interaction logic for ConnectionError.xaml
    /// </summary>
    public partial class ConnectionError : Window
    {
        public ConnectionError()
        {
            InitializeComponent();
        }
        static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                //Console.WriteLine(result);
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            return null;
        }
        public string pin { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    if (lblPin.Content.ToString() == "0")
                    {
                        lblPin.Content = (string)btn.Content;
                        pin = btn.Content.ToString();
                    }
                    else
                    {
                        lblPin.Content += (string)btn.Content;
                        pin += (string)btn.Content;
                    }

                }
            }
            catch (Exception exp)
            {
                EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok");
            }
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((string)lblPin.Content != string.Empty) && (pin != string.Empty))
                {
                    lblPin.Content = lblPin.Content.ToString().Remove(lblPin.Content.ToString().Length - 1);
                    pin = pin.Remove(pin.Length - 1);

                }
            }
            catch (Exception exp)
            { EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok"); }
        }

        private void ClearPin()
        {
            lblPin.Content = "";
            pin = 1.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearPin();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string server = lblPin.Content.ToString();
                string database = ReadSetting("Database");
                ActiveSession.CompleteConnection = ActiveSession.DummyConnection.Replace("<<server>>", server).Replace("<<database>>", database);
                ////await Task.Run(() => SetupExceptionHandling());
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    ActiveSession.Setting = DB.Setting.GetAll().ToList();
                }
                EZYPOS.View.MessageBox.ShowCustom("Connection is Successful with database", "Successful", "OK");

            }
            catch
            {
                EZYPOS.View.MessageBox.ShowCustom("Connection not Successful with database", "Connection Error", "OK");
            }
        }

        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string server = lblPin.Content.ToString();
                string database = ReadSetting("Database");
                ActiveSession.CompleteConnection = ActiveSession.DummyConnection.Replace("<<server>>", server).Replace("<<database>>", database);
                //await Task.Run(() => SetupExceptionHandling());
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    ActiveSession.Setting = DB.Setting.GetAll().ToList();
                }
                this.Close();
                EZYPOS.View.LoginScreen LoginScreen = new EZYPOS.View.LoginScreen();
                LoginScreen.Show();
            }
            catch
            {
                EZYPOS.View.MessageBox.ShowCustom("Connection not Successful with database", "Connection Error", "OK");
            }

        }

        private void DotClick(object sender, RoutedEventArgs e)
        {
            lblPin.Content = lblPin.Content.ToString() + ".";
            pin = pin.ToString() + ".";
        }
    }
}