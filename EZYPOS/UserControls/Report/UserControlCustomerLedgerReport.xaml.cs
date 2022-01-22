using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using System;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using EZYPOS.DTO.ReportsDTO;
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
using System.IO;
using System.Globalization;

namespace EZYPOS.UserControls.Report
{
    /// <summary>
    /// Interaction logic for UserControlCustomerLedgerReport.xaml
    /// </summary>
    public partial class UserControlCustomerLedgerReport : UserControl
    {
        List<CustomerLedgerDTO> myList = new List<CustomerLedgerDTO>();
        Pager<CustomerLedgerDTO> Pager = new Helper.Pager<CustomerLedgerDTO>();
        public UserControlCustomerLedgerReport()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                var CustomerList = DB.Customers.GetAll().Select(x => new { Name = x.Name, Id = x.Id }).ToList();
                CustomerList.Insert(0, new { Name = "All", Id = 0 });
                ddCustomer.ItemsSource = CustomerList;
            }
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            Refresh();
        }


        void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
            {
                List<Customer> Customers = new List<Customer>();
                if (ddCustomer.SelectedItem == null || Convert.ToInt32(ddCustomer.SelectedValue) == 0)
                {
                    Customers = Db.Customers.GetAll().ToList();
                }
                else
                {
                    Customers = Db.Customers.GetAll().Where(x=> x.Id == Convert.ToInt32(ddCustomer.SelectedValue)).ToList();
                }
                myList.Clear();
                foreach (var Customer in Customers)
                {

                    string CustomerName = Db.Customers.Get(Customer.Id).Name;

                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                    var items = Db.CustomerLead.GetAll().Where(X => X.CustomerId == Customer.Id && X.TransactionDate >= Sdate && X.TransactionDate <= Edate).ToList();

                    decimal? TotalDR = 0;
                    decimal? TotalCR = 0;
                    decimal? TotalBalance = 0;
                    foreach (var item in items)
                    {
                        item.Dr = item.Dr == null ? 0 : item.Dr;
                        item.Cr = item.Cr == null ? 0 : item.Cr;

                        TotalDR += item.Dr;
                        TotalCR += item.Cr;
                        TotalBalance = TotalDR - TotalCR;
                        myList.Add(new CustomerLedgerDTO { CustomerName = CustomerName, Date = Convert.ToDateTime(item.TransactionDate), TransactionType = item.TransactionType, Detail = item.TransactionDetail, CR = item.Cr, DR = item.Dr, Balance = TotalBalance });
                    }

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

                        {

                            if (t.Name == "GridCName")
                            {
                                myList.Clear();
                                List<Customer> Customers = new List<Customer>();
                                if (ddCustomer.SelectedItem == null || Convert.ToInt32(ddCustomer.SelectedValue) == 0)
                                {
                                    Customers = Db.Customers.GetAll().ToList();
                                }
                                else
                                {
                                    Customers = Db.Customers.GetAll().Where(x => x.Id == Convert.ToInt32(ddCustomer.SelectedValue)).ToList();
                                }
                                Customers = Customers.Where(x => x.Name.ToUpper().Contains(filter.ToUpper())).ToList();
                                foreach (var Customer in Customers)
                                {

                                    string CustomerName = Db.Customers.Get(Customer.Id).Name;

                                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                                    var items = Db.CustomerLead.GetAll().Where(X => X.CustomerId == Customer.Id && X.TransactionDate >= Sdate && X.TransactionDate <= Edate).ToList();

                                    decimal? TotalDR = 0;
                                    decimal? TotalCR = 0;
                                    decimal? TotalBalance = 0;
                                    foreach (var item in items)
                                    {
                                        item.Dr = item.Dr == null ? 0 : item.Dr;
                                        item.Cr = item.Cr == null ? 0 : item.Cr;

                                        TotalDR += item.Dr;
                                        TotalCR += item.Cr;
                                        TotalBalance = TotalDR - TotalCR;
                                        myList.Add(new CustomerLedgerDTO { CustomerName = CustomerName, Date = Convert.ToDateTime(item.TransactionDate), TransactionType = item.TransactionType, Detail = item.TransactionDetail, CR = item.Cr, DR = item.Dr, Balance = TotalBalance });
                                    }

                                }
                                ResetPaging(myList);


                            }


                        }
                    }
                    
                }
            }

        }


        #region Pagination

        private void ResetPaging(List<CustomerLedgerDTO> ListTopagenate)
        {
            CustomerLedgerGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            CustomerLedgerGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            CustomerLedgerGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            CustomerLedgerGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            CustomerLedgerGrid.ItemsSource = Pager.Last(myList);
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
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.CustomerName, COLB = x.TransactionType, COLC = x.Date.ToString("dd/MM/yyyy"), COLD = x.DR?.ToString(), COLE = x.CR?.ToString(), COLF = x.Balance?.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")) }).ToList();
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "GenericCOL6DataSet";
            rds.Value = RptData;
            string exePath = Directory.GetCurrentDirectory();
            ReportViewer.LocalReport.ReportPath = exePath + @"\RDLC\Generic\GenericCOL6Report.rdlc";
            this.ReportViewer.LocalReport.DataSources.Add(rds);
            this.ReportViewer.LocalReport.EnableExternalImages = true;
            string imagePath = new Uri(exePath + @"\Assets\logo.png").AbsoluteUri;
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ImagePath", imagePath));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportName", "Customer Ledger Report"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderA", "Customer Name"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderB", "Transaction Type"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderC", "Date"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderD", "DR"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderE", "CR"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderF", "Balance"));
            string Dis = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            string PrintDate = "Printed On: " + DateTime.Now.ToString("dd/MM/yyyy");
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportDescription", Dis));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("PrintDate", PrintDate));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderDescription", "House No 36, Street No 3, Liaqt Colony, PAF Road, 49 Tail, Sargodha, Pakistan"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("FooterDescription", "House No 36, Street No 3, Liaqt Colony, PAF Road, 49 Tail, Sargodha, Pakistan"));
            this.ReportViewer.RefreshReport();
            this.ReportViewer.LocalReport.Print();

            
        }
    }
}