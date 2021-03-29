﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ChromeTabs;

namespace EZYPOS
{
    /// <summary>
    /// Interaction logic for MainWindowNewMenu.xaml
    /// </summary>
    public partial class MainWindowNewMenu : Window
    {
        public MainWindowNewMenu()
        {
            InitializeComponent();
            MenuItem mnuDeleteInvoice = new MenuItem();

            mnuDeleteInvoice.Header = "Test Dynamic";

            mnuDeleteInvoice.Height = 50;

            mnuDeleteInvoice.Click += MenuItem_Click;
           // mnuDeleteInvoice.Tag = "EZYPOS.UserControls.UserControlAddCustomer";
            mnuDeleteInvoice.Tag = "EZYPOS.UserControls.UserControlListCustomer";
            VSOnline.Items.Add(mnuDeleteInvoice);
        }

        private void EditStatusCm_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                ContextMenu cm = mi.CommandParameter as ContextMenu;
                if (cm != null)
                {
                    Grid g = cm.PlacementTarget as Grid;
                    if (g != null)
                    {
                        Console.WriteLine(g.Background); // Will print red
                    }
                }
            }
        }

        private void LoadUserControl(string controlName)
        {
            Type ucType = null;
            UserControl uc = null;

            // Create a Type from controlName parameter
            ucType = Type.GetType(controlName);
            if (ucType == null)
            {
                MessageBox.Show("The Control: " + controlName + " does not exist.");
            }
            else
            {
                // Close current user control in content area
                //CloseUserControl();

                // Create an instance of this control
                uc = (UserControl)Activator.CreateInstance(ucType);
                if (uc != null)
                {
                    // Display control in content area
                    DisplayUserControl(uc);
                }
            }
        }

        public void DisplayUserControl(UserControl uc)
        {
            // Add new user control to content area
            // contentArea.Children.Add(uc);
            this.chrometabs.AddTab(this.GenerateNewItem(uc), true);
        }

       
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = (MenuItem)sender;
            string cmd = string.Empty;

            // The Tag property contains a command or the name of a user control to load
            if (mnu.Tag != null)
            {
                cmd = mnu.Tag.ToString();
                if (cmd.Contains("."))
                {
                    // Display a user control
                    LoadUserControl(cmd);
                }
                else
                {
                    // Process special commands
                   // ProcessMenuCommands(cmd);
                }
            }
        }
        private int newTabNumber;

        private void HandleAddTab(object sender, RoutedEventArgs e)
        {
            this.chrometabs.AddTab(this.GenerateNewItem(), false);
        }
        private object GenerateNewItem(UserControl UC=null)
        {
            object itemToAdd = null;
            string ItemName = "Nil";

            //object itemToAdd = new UserControl1();
            if (UC == null)
            { itemToAdd = new Button { Content = "Moo " + this.newTabNumber }; }
            else
            {
                itemToAdd = UC;
                ItemName = ((UserControl)itemToAdd).Name;
                
            }
            Interlocked.Increment(ref this.newTabNumber);
            //if (this.title.Text.Length > 0)
            {
                itemToAdd = new ChromeTabs.ChromeTabItem
                {
                    Header = ItemName,
                    Content = itemToAdd
                };
            }
            return itemToAdd;
        }
    }
}