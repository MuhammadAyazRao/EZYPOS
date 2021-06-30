using Common.Session;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.Helper
{
    public static class DatabaseBackup
    {
        public static bool Backup(string Path)
        {
            try
            {
                string databaseName = ActiveSession.DatabaseName;//dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();    

                //Define a Backup object variable.    
                Backup sqlBackup = new Backup();

                ////Specify the type of backup, the description, the name, and the database to be backed up.    
                sqlBackup.Action = BackupActionType.Database;
                sqlBackup.BackupSetDescription = "BackUp of:" + databaseName + "on" + DateTime.Now.ToShortDateString();
                sqlBackup.BackupSetName = "FullBackUp";
                sqlBackup.Database = databaseName;

                ////Declare a BackupDeviceItem            
                string destinationPath = Path;
                string backupfileName = ActiveSession.DatabaseName + DateTime.Now.ToString("MMddyyyyHHmmss") + ".bak";
                BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath + "\\" + backupfileName, DeviceType.File);
                ////Define Server connection    

                //ServerConnection connection = new ServerConnection(frm.serverName, frm.userName, frm.password);    
                ServerConnection connection = new ServerConnection(ActiveSession.ServerName, ActiveSession.UserName, ActiveSession.Password);
                ////To Avoid TimeOut Exception    
                Server sqlServer = new Server(connection);
                sqlServer.ConnectionContext.StatementTimeout = 60 * 60;
                Database db = sqlServer.Databases[databaseName];

                sqlBackup.Initialize = true;
                sqlBackup.Checksum = true;
                sqlBackup.ContinueAfterError = true;

                ////Add the device to the Backup object.    
                sqlBackup.Devices.Add(deviceItem);
                ////Set the Incremental property to False to specify that this is a full database backup.    
                sqlBackup.Incremental = false;

                sqlBackup.ExpirationDate = DateTime.Now.AddYears(100);
                ////Specify that the log must be truncated after the backup is complete.    
                sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

                sqlBackup.FormatMedia = false;
                ////Run SqlBackup to perform the full database backup on the instance of SQL Server.    
                sqlBackup.SqlBackup(sqlServer);
                ////Remove the backup device from the Backup object.    
                sqlBackup.Devices.Remove(deviceItem);
                return true;
            }
            catch(Exception exp)
            {
                return false;
            }
        }
    }
}
