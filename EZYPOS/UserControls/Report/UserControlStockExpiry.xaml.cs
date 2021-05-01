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
using System.Threading;
using Report;
using Microsoft.Reporting.NETCore;
using Microsoft.Reporting.WinForms;
using System.IO;
using DAL.Repository;

namespace EZYPOS.UserControls.Report
{
    /// <summary>
    /// Interaction logic for UserControlStockExpiry.xaml
    /// </summary>
    public partial class UserControlStockExpiry : UserControl
    {
        public UserControlStockExpiry()
        {
            InitializeComponent();
            setreport();
        }
        void setreport()
        {
            string exePath = Directory.GetCurrentDirectory();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                var items = Db.Stock.GetStockDetail().ToList();
                Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
                rds.Name = "ProductStockExpiry";
                rds.Value = items;
                reportViewer.LocalReport.ReportPath = exePath + @"\RDLC\Product\ProductStockExpiryReport.rdlc";
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(rds);
                reportViewer.RefreshReport();

            }

        }
    }
}
