using Common.Session;
using EZYPOS.Helper;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace EZYPOS.UserControls.Utility
{
    /// <summary>
    /// Interaction logic for UserControlDatabaseBackup.xaml
    /// </summary>
    public partial class UserControlDatabaseBackup : UserControl
    {
        public UserControlDatabaseBackup()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (txtDestination.Text == "" || txtDestination.Text == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select Destination", "Path Error", "ok");
                return;
            }
            if(DatabaseBackup.Backup(txtDestination.Text))
            { 
                EZYPOS.View.MessageBox.ShowCustom("Backup has Completed Successfully", "Successfull", "ok"); 
            }
            else
            {
                EZYPOS.View.MessageBox.ShowCustom("Backup Process failed", "Error", "ok");
            }
           
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Destination_Click(object sender, RoutedEventArgs e)
        {
            var FolderDialog = new FolderBrowserDialog();

            // Show the FolderBrowserDialog.
            DialogResult result = FolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = FolderDialog.SelectedPath;
                txtDestination.Text = folderName;

            }
        }
    }
}
