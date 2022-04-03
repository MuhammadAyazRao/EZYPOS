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
    /// Interaction logic for UserControlSupplierLedgerReport.xaml
    /// </summary>
    public partial class UserControlSupplierLedgerReport : UserControl
    {
        List<SupplierLedgerDTO> myList = new List<SupplierLedgerDTO>();
        Pager<SupplierLedgerDTO> Pager = new Helper.Pager<SupplierLedgerDTO>();
        public UserControlSupplierLedgerReport()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                var SupplierList = DB.Supplier.GetAll().Select(x => new { Name = x.Name, Id = x.Id }).ToList();
                SupplierList.Insert(0, new { Name = "All", Id = 0 });
                ddSupplier.ItemsSource = SupplierList;
            }
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            Refresh();
        }

        public string GetCurrency()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                return Db.Setting.GetAll().Where(x => x.AppKey == SettingKey.Currency).FirstOrDefault().AppValue;
            }
        }
        void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                List<Supplier> Suppliers = new List<Supplier>();
                if (ddSupplier.SelectedItem == null || Convert.ToInt32(ddSupplier.SelectedValue) == 0)
                {
                    Suppliers = Db.Supplier.GetAll().ToList();
                }
                else
                {
                    Suppliers = Db.Supplier.GetAll().Where(x => x.Id == Convert.ToInt32(ddSupplier.SelectedValue)).ToList();
                }
                myList.Clear();
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
                        myList.Add(new SupplierLedgerDTO { SupplierName = SupplierName, Date = item.TransactionDate?.ToString("dd/MM/yyyy"), TransactionType = item.TransactionType, Detail = item.TransactionDet, CR = item.Cr.ToString(), DR = item.Dr.ToString(), Balance = TotalBalance?.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
                    }

                }
                ResetPaging(myList);
            }
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
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
                        if (t.Name == "GridSName")
                        {
                            List<Supplier> Suppliers = new List<Supplier>();
                            if (ddSupplier.SelectedItem == null || Convert.ToInt32(ddSupplier.SelectedValue) == 0)
                            {
                                Suppliers = Db.Supplier.GetAll().ToList();
                            }
                            else
                            {
                                Suppliers = Db.Supplier.GetAll().Where(x => x.Id == Convert.ToInt32(ddSupplier.SelectedValue)).ToList();
                            }
                            Suppliers = Suppliers.Where(x => x.Name.ToUpper().Contains(filter.ToUpper())).ToList();
                            myList.Clear();
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
                                    myList.Add(new SupplierLedgerDTO { SupplierName = SupplierName, Date = item.TransactionDate?.ToString("dd/MM/yyyy"), TransactionType = item.TransactionType, Detail = item.TransactionDet, CR = item.Cr.ToString(), DR = item.Dr.ToString(), Balance = TotalBalance?.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
                                }

                            }
                        }
                        ResetPaging(myList);
                    }
                    
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

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.SupplierName, COLB = x.Date, COLC = x.TransactionType, COLD = x.DR, COLE = x.CR, COLF = x.Balance }).ToList();
            string Discription = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL6Report(ref ReportViewer, "Supplier Ledger Report", "Supplier Name", "Date", "Transaction Type", "DR", "CR", "Balance", Discription, RptData);

        }

        private void ddSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}