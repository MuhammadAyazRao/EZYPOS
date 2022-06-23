using Common;
using DAL.DBMODEL;
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
    /// Interaction logic for UserControlCustomerBalanceReport.xaml
    /// </summary>
    public partial class UserControlCustomerBalanceReport : UserControl
    {
        List<CustomerBalanceDTO> myList = new List<CustomerBalanceDTO>();
        Pager<CustomerBalanceDTO> Pager = new Helper.Pager<CustomerBalanceDTO>();
        public UserControlCustomerBalanceReport()
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
                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;

                var items = Db.CustomerLead.GetAll().Where(X => X.TransactionDate >= Sdate && X.TransactionDate <= Edate).GroupBy(x => x.CustomerId).Select(x => new { CustId = x.Key, TotalDr = x.Sum(v => v.Dr), TotalCr = x.Sum(v => v.Cr), Balance = x.Sum(v => v.Dr) - x.Sum(v => v.Cr) }).ToList();
                decimal Balance = 0;
                string CustomerName = "";
                myList.Clear();
                foreach (var item in items)
                {
                    Balance += (decimal)item.Balance;
                    CustomerName = Db.Customers.Get((int)item.CustId).Name;

                    myList.Add(new CustomerBalanceDTO { CustomerName = CustomerName, CR = item.TotalCr.ToString() , DR = item.TotalDr?.ToString(), Balance = item.Balance?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                }
                myList.Add(new CustomerBalanceDTO { CustomerName = "", Date = DateTime.Now.ToString("dd/MM/yyyy"), TransactionType = "", Detail = "Total Credit Balance in Market", CR = "Total", DR = "", Balance = Balance.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
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
                        if (t.Name == "GridCustomerName")
                        {
                            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;

                            var items = Db.CustomerLead.GetAll().Where(X => X.TransactionDate >= Sdate && X.TransactionDate <= Edate).GroupBy(x => x.CustomerId).Select(x => new { CustId = x.Key, TotalDr = x.Sum(v => v.Dr), TotalCr = x.Sum(v => v.Cr), Balance = x.Sum(v => v.Dr) - x.Sum(v => v.Cr) }).ToList();
                            decimal Balance = 0;
                            string customerName = "";
                            myList.Clear();
                            foreach (var item in items)
                            {
                                customerName = Db.Customers.Get((int)item.CustId).Name;
                                if (customerName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    Balance += (decimal)item.Balance;
                                    myList.Add(new CustomerBalanceDTO { CustomerName = customerName, CR = item.TotalCr.ToString(), DR = item.TotalDr?.ToString(), Balance = item.Balance?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                                }

                            }
                            myList.Add(new CustomerBalanceDTO { CustomerName = "", Date = DateTime.Now.ToString("dd/MM/yyyy"), TransactionType = "", Detail = "Total Credit Balance in Market", CR = "Total", DR = "", Balance = Balance.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                            ResetPaging(myList);
                        }
                    }

                }
            }

        }


        #region Pagination

        private void ResetPaging(List<CustomerBalanceDTO> ListTopagenate)
        {
            CustomerBalanceGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            CustomerBalanceGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            CustomerBalanceGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            CustomerBalanceGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            CustomerBalanceGrid.ItemsSource = Pager.Last(myList);
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
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.CustomerName, COLB = x.DR, COLC = x.CR, COLD = x.Balance, COLE = "", COLF = "" }).ToList();
            string Discription = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL4Report(ref ReportViewer, "Customer Balance Report", "Customer Name", "DR", "CR", "Balance", Discription, RptData);

        }
    }
}