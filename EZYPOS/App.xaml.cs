using DAL.Repository;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace EZYPOS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        protected override async void OnStartup(StartupEventArgs e)
        {
            // SetupExceptionHandling();
            await Task.Run(() => SetupExceptionHandling());
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
            }

            EZYPOS.View.SplashScreen Splash = new EZYPOS.View.SplashScreen();
            Splash.Show();
            await Task.Run(() => Thread.Sleep(3000));
           
            EZYPOS.View.LoginScreen LoginScreen = new EZYPOS.View.LoginScreen();
            LoginScreen.Show();
            Splash.Close();
        }

        private void SetupExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                LogUnhandledException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            DispatcherUnhandledException += (s, e) =>
            {
                LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");
                e.Handled = true;
            };

            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
                e.SetObserved();
            };
        }
        private void LogUnhandledException(Exception exception, string source)
        {
            string message = $"Unhandled exception ({source})";
            try
            {
                System.Reflection.AssemblyName assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
                message = string.Format("Unhandled exception in {0} v{1}", assemblyName.Name, assemblyName.Version);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Exception in LogUnhandledException");
            }
            finally
            {
                View.MessageBox.ShowCustom(exception.Message, "Error", "ok");
                _logger.Error(exception, message);
            }
        }


    }
   


}
