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
    /// Interaction logic for UserControlSupplierBalanceReport.xaml
    /// </summary>
    public partial class UserControlSupplierBalanceReport : UserControl
    {
        List<SupplierBalanceDTO> myList = new List<SupplierBalanceDTO>();
        Pager<SupplierBalanceDTO> Pager = new Helper.Pager<SupplierBalanceDTO>();
        public UserControlSupplierBalanceReport()
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

                var items = Db.SupplierLead.GetAll().Where(X => X.TransactionDate >= Sdate && X.TransactionDate <= Edate).GroupBy(x => x.SuplierId).Select(x => new { SuppId = x.Key, TotalDr = x.Sum(v => v.Dr), TotalCr = x.Sum(v => v.Cr), Balance = x.Sum(v => v.Dr) - x.Sum(v => v.Cr) }).ToList();
                decimal Balance = 0;
                myList.Clear();
                foreach (var item in items)
                {
                    Balance += (decimal)item.Balance;


                    myList.Add(new SupplierBalanceDTO { SupplierName = Db.Supplier.Get((int)item.SuppId).Name, CR = item.TotalCr.ToString(), DR = item.TotalDr?.ToString(), Balance = item.Balance?.ToString() });
                }
                myList.Add(new SupplierBalanceDTO { SupplierName = "Total", Date = DateTime.Now.ToString("dd/MM/yyyy"), TransactionType = "", Detail = "Total Credit Balance in Market", CR = "", DR = "", Balance = Balance.ToString() });
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
                        if (t.Name == "GridSupplierName")
                        {
                            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;

                            var items = Db.SupplierLead.GetAll().Where(X => X.TransactionDate >= Sdate && X.TransactionDate <= Edate).GroupBy(x => x.SuplierId).Select(x => new { SuppId = x.Key, TotalDr = x.Sum(v => v.Dr), TotalCr = x.Sum(v => v.Cr), Balance = x.Sum(v => v.Dr) - x.Sum(v => v.Cr) }).ToList();
                            decimal Balance = 0;
                            string supplierName = "";
                            myList.Clear();
                            foreach (var item in items)
                            {
                                supplierName = Db.Supplier.Get((int)item.SuppId).Name;
                                if (supplierName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    Balance += (decimal)item.Balance;
                                    myList.Add(new SupplierBalanceDTO { SupplierName = Db.Supplier.Get((int)item.SuppId).Name, CR = item.TotalCr.ToString(), DR = item.TotalDr?.ToString(), Balance = item.Balance?.ToString() });
                                }

                            }
                            myList.Add(new SupplierBalanceDTO { SupplierName = "Total", Date = DateTime.Now.ToString("dd/MM/yyyy"), TransactionType = "", Detail = "Total Credit Balance in Market", CR = "", DR = "", Balance = Balance.ToString() });
                            ResetPaging(myList);
                        }
                        
                    }

                }
            }

        }


        #region Pagination

        private void ResetPaging(List<SupplierBalanceDTO> ListTopagenate)
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
    }
}