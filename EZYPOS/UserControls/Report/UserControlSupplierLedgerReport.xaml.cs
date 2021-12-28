using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserControlSupplierLedgerReport.xaml
    /// </summary>
    public partial class UserControlSupplierLedgerReport : UserControl
    {
        List<SupplierLedgerDTO> myList { get; set; }
        Pager<SupplierLedgerDTO> Pager = new Helper.Pager<SupplierLedgerDTO>();
        public UserControlSupplierLedgerReport()
        {
            InitializeComponent();
            Refresh();
        }
       

        void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var Suppliers = Db.Supplier.GetAll().ToList();
                List<SupplierLedgerDTO> myList = new List<SupplierLedgerDTO>();
                foreach (var Supplier in Suppliers)
                {
                    string SupplierName = Db.Supplier.Get(Supplier.Id).Name;
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    var items = Db.SupplierLead.GetAll().Where(X => X.SuplierId == Supplier.Id).ToList();

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
                        SupplierLedgerDTO data = new SupplierLedgerDTO();
                        myList.Add(new SupplierLedgerDTO { SupplierName = SupplierName, Date = Convert.ToDateTime(item.TransactionDate), TransactionType = item.TransactionType, Detail = item.TransactionDet, CR = item.Cr, DR = item.Dr, Balance = TotalBalance });
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

                            if (t.Name == "GridSName")
                            {
                                
                                var Suppliers = Db.Supplier.GetAll().Where(x=> x.Name.ToUpper().Contains(filter.ToUpper())).ToList();
                                List<SupplierLedgerDTO> myList = new List<SupplierLedgerDTO>();
                                foreach (var Supplier in Suppliers)
                                {

                                    string SupplierName = Db.Supplier.Get(Supplier.Id).Name;
                                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                                    var items = Db.SupplierLead.GetAll().Where(X => X.SuplierId == Supplier.Id).ToList();

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
                                        SupplierLedgerDTO data = new SupplierLedgerDTO();
                                        myList.Add(new SupplierLedgerDTO { SupplierName = SupplierName, Date = Convert.ToDateTime(item.TransactionDate), TransactionType = item.TransactionType, Detail = item.TransactionDet, CR = item.Cr, DR = item.Dr, Balance = TotalBalance });
                                    }

                                }

                                ResetPaging(myList);

                                
                            }
                            

                        };
                    }
                    ResetPaging(myList);
                }
            }

        }


        #region Pagination

        private void ResetPaging(List<SupplierLedgerDTO> ListTopagenate)
        {
            SupplierLedgerGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            SupplierLedgerGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            SupplierLedgerGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            SupplierLedgerGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            SupplierLedgerGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }


        #endregion

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Directory.GetCurrentDirectory();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var Suppliers = Db.Supplier.GetAll().ToList();
                List<SupplierLedgerDTO> myList = new List<SupplierLedgerDTO>();
                foreach (var Supplier in Suppliers)
                {

                    string SupplierName = Db.Supplier.Get(Supplier.Id).Name;

                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                    var items = Db.SupplierLead.GetAll().Where(X => X.SuplierId == Supplier.Id && X.TransactionDate >= Sdate && X.TransactionDate <= Edate).ToList();

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
                        SupplierLedgerDTO data = new SupplierLedgerDTO();
                        myList.Add(new SupplierLedgerDTO { SupplierName = SupplierName, Date = Convert.ToDateTime(item.TransactionDate), TransactionType = item.TransactionType, Detail = item.TransactionDet, CR = item.Cr, DR = item.Dr, Balance = TotalBalance });
                    }

                }

                ResetPaging(myList);

            }
        }
    }
}