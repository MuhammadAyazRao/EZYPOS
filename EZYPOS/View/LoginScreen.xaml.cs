﻿using Common.Session;
using DAL.Repository;
using EZYPOS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var EmployeeList = Db.Employee.GetAll().Select(x => new { Name = x.UserName, Id = x.Id }).ToList();
                ddEmployee.ItemsSource = EmployeeList;
            }
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()) )
            {
                
                var SelectedEmployeePin = Db.Employee.GetAll().Where(x=> x.Id == Convert.ToInt32(ddEmployee.SelectedValue)).FirstOrDefault().Password;
                if (SelectedEmployeePin == Password.Password.ToString())
                {
                    EZYPOS.View.SplashScreen Splash = new EZYPOS.View.SplashScreen();
                    Splash.Show();
                    await Task.Run(() => Thread.Sleep(3000));
                    MainWindowNewMenu MainUI = new MainWindowNewMenu();
                    MainUI.Show();
                    Splash.Close();
                    Close();
                    ActiveSession.ActiveUser = Convert.ToInt32(ddEmployee.SelectedValue);
                }
                else
                {
                    EZYPOS.View.MessageBox.ShowCustom("Pin is incorrect", "Error", "Ok");
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
        //Numpad Clicks Start

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    if (Password.Password.ToString() == "0")
                    {
                        Password.Password = (string)btn.Content;
                    }
                    else
                    {
                        Password.Password += (string)btn.Content;
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
                if (Password.Password != string.Empty)
                {
                    Password.Password = Password.Password.Remove(Password.Password.Length - 1);
                }
            }
            catch (Exception exp)
            { EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Password.Password = string.Empty;
        }

        //Numpad clicks End

    }
}
