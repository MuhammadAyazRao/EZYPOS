using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
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
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            Refresh();
        }


        void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var Customers = Db.Customers.GetAll().ToList();
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
                                var Customers = Db.Customers.GetAll().Where(x => x.Name.ToUpper().Contains(filter.ToUpper())).ToList();
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
    }
}