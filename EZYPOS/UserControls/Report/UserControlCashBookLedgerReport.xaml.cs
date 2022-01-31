using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.DTO.ReportsDTO;
using EZYPOS.Helper;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace EZYPOS.UserControls.Report
{
    /// <summary>
    /// Interaction logic for UserControlCashBookLedgerReport.xaml
    /// </summary>
    public partial class UserControlCashBookLedgerReport : UserControl
    {
        List<CashBookLedgerDTO> myList = new List<CashBookLedgerDTO>();
        Pager<CashBookLedgerDTO> Pager = new Helper.Pager<CashBookLedgerDTO>();
        public UserControlCashBookLedgerReport()
        {
            InitializeComponent();
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            Refresh();
            

        }


        void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                var items = Db.CashBookLead.GetAll().Where(x => x.TransactionDate >= Sdate && x.TransactionDate <= Edate).ToList();
                decimal? TotalDR = 0;
                decimal? TotalCR = 0;
                decimal? TotalBalance = 0;
                myList.Clear();
                foreach (var item in items)
                {
                    item.DrAmt = item.DrAmt == null ? 0 : item.DrAmt;
                    item.CrAmt = item.CrAmt == null ? 0 : item.CrAmt;

                    TotalDR += item.DrAmt;
                    TotalCR += item.CrAmt;
                    TotalBalance = TotalDR - TotalCR;
                    myList.Add(new CashBookLedgerDTO {Date = item.TransactionDate, TransactionType = item.TransactionType, Detail = item.TransactionDetail, CR = item.CrAmt, DR = item.DrAmt, Balance = TotalBalance });
                }
                ResetPaging(myList);

            }
        }
        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;

                using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (filter == "")
                    {
                        Refresh();
                    }
                    else
                    {

                        if (t.Name == "GridName")
                        {

                        }
                    }
                    ResetPaging(myList);
                }
            }

        }


        #region Pagination

        private void ResetPaging(List<CashBookLedgerDTO> ListTopagenate)
        {
            CashBookLedgerGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            CashBookLedgerGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            CashBookLedgerGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            CashBookLedgerGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            CashBookLedgerGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }


        #endregion

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            //List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.TransactionType, COLB = x.Date?.ToString("MM/dd/yyyy"), COLC = x.Detail, COLD = x.DR.ToString(), COLE = x.CR.ToString(), COLF = x.Balance?.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")) }).ToList();
            //ReportDataSource rds = new ReportDataSource();
            //rds.Name = "GenericCOL6DataSet";
            //rds.Value = RptData;
            //string exePath = Directory.GetCurrentDirectory();
            //ReportViewer.LocalReport.ReportPath = exePath + @"\RDLC\Generic\GenericCOL6Report.rdlc";
            //this.ReportViewer.LocalReport.DataSources.Add(rds);
            //this.ReportViewer.LocalReport.EnableExternalImages = true;
            //string imagePath = new Uri(exePath + @"\Assets\logo.png").AbsoluteUri;
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ImagePath", imagePath));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportName", "CashBook Ledger Report"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderA", "Transaction Type"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderB", "Date"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderC", "Detail"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderD", "DR"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderE", "CR"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderF", "Balance"));
            //string Dis = "From: " + StartDate.SelectedDate?.ToString("MM/dd/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("MM/dd/yyyy");
            //string PrintDate = "Printed On: " + DateTime.Now.ToString("MM/dd/yyyy");
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportDescription", Dis));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("PrintDate", PrintDate));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderDescription", "House No 36, Street No 3, Liaqt Colony, PAF Road, 49 Tail, Sargodha, Pakistan"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("FooterDescription", "House No 36, Street No 3, Liaqt Colony, PAF Road, 49 Tail, Sargodha, Pakistan"));
            //this.ReportViewer.RefreshReport();
            //this.ReportViewer.LocalReport.Print();

            string Discription = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.TransactionType, COLB = x.Date?.ToString("dd/MM/yyyy"), COLC = x.Detail, COLD = x.DR.ToString(), COLE = x.CR.ToString(), COLF = x.Balance?.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")) }).ToList();
            ReportPrintHelper.PrintCOL6Report(ref ReportViewer, "CashBook Ledger Report", "Transaction Type", "Date", "Detail", "DR", "CR", "Balance", Discription, RptData);

            
        }
    }
}