using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.View;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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

        static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
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

        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            // SetupExceptionHandling();
            EZYPOS.View.SplashScreen Splash = new EZYPOS.View.SplashScreen();
            Splash.Show();
            await Task.Run(() => Thread.Sleep(3000));
            try
            {
                string server = ReadSetting("Server");
                string database = ReadSetting("Database");
                ActiveSession.CompleteConnection = ActiveSession.DummyConnection.Replace("<<server>>", server).Replace("<<database>>", database);
                EPOSDBContext context = new EPOSDBContext();
                context.Database.GetService<IRelationalDatabaseCreator>().Exists(); 
                await Task.Run(() => SetupExceptionHandling());
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    ActiveSession.Setting = DB.Setting.GetAll().ToList();
                }
                EZYPOS.View.LoginScreen LoginScreen = new EZYPOS.View.LoginScreen();
                LoginScreen.Show();
                Splash.Close();
            }
            catch
            {
                EZYPOS.View.MessageBox.ShowCustom("Connection not Successful with database, Plz Provide Server IP", "Connection Error", "OK");
                ConnectionError popup = new ConnectionError();
                popup.Show();
            }
            
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
