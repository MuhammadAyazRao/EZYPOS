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
            Save.IsEnabled = false;
            Restore.IsEnabled = false;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (txtDestination.Text == "" || txtDestination.Text == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select Destination", "Path Error", "ok");
                return;
            }
            if(DatabaseBackup.Backlupnew(txtDestination.Text))
            { 
                EZYPOS.View.MessageBox.ShowCustom("Backup has Completed Successfully", "Successfull", "ok"); 
            }
            else
            {
                EZYPOS.View.MessageBox.ShowCustom("Backup Process failed", "Error", "ok");
            }
           
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
                Save.IsEnabled = true;

            }
        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            if (txtResDestination.Text == "" || txtResDestination.Text == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select Destination", "Path Error", "ok");
                return;
            }
            if (DatabaseBackup.Restore(txtResDestination.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Restoration has Completed Successfully", "Successfull", "ok");
            }
            else
            {
                EZYPOS.View.MessageBox.ShowCustom("Restoration Process failed", "Error", "ok");
            }
           
        }

        private void ResDestination_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtResDestination.Text = dlg.FileName;
                Restore.IsEnabled = true;
            }
        }
    }
}
