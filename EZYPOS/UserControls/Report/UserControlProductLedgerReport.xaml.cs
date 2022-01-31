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
    /// Interaction logic for UserControlProductLedgerReport.xaml
    /// </summary>
    public partial class UserControlProductLedgerReport : UserControl
    {
        List<ProductLedgerDTO> myList = new List<ProductLedgerDTO>();
        Pager<ProductLedgerDTO> Pager = new Helper.Pager<ProductLedgerDTO>();
        public UserControlProductLedgerReport()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                var ProductList = DB.Product.GetAll().Select(x => new { Name = x.ProductName, Id = x.Id }).ToList();
                ProductList.Insert(0, new { Name = "All", Id = 0 });
                ddProduct.ItemsSource = ProductList;
            }
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            Refresh();
        }


        void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                String ProductName = "";
                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                List<StockLead> items = new List<StockLead>();
                if (ddProduct.SelectedValue == null || ddProduct.SelectedIndex == 0)
                {
                    items = Db.StockLeader.GetAll().Where((x => x.TransactionDate >= Sdate && x.TransactionDate <= Edate)).ToList();
                }
                else
                {
                    items = Db.StockLeader.GetAll().Where((x => x.TransactionDate >= Sdate && x.TransactionDate <= Edate && x.ProductId == Convert.ToInt32(ddProduct.SelectedValue))).ToList();
                }
                myList.Clear();
                foreach (var item in items)
                {
                    item.DrQty = item.DrQty == null ? 0 : item.DrQty;
                    item.CrQty = item.CrQty == null ? 0 : item.CrQty;
                    ProductName = Db.Product.Get(item.ProductId).ProductName;
                    myList.Add(new ProductLedgerDTO { TransactionDate = item.TransactionDate, TransactionType = item.TransactionType, TransactionDetail = item.TransactionDetail, ProductN = ProductName, DR = item.DrQty, CR = item.CrQty });
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
                        if (t.Name == "GridPName")
                        {
                            String ProductName = "";
                            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                            List<StockLead> items = new List<StockLead>();
                            if (ddProduct.SelectedValue == null || ddProduct.SelectedIndex == 0)
                            {
                                items = Db.StockLeader.GetAll().Where((x => x.TransactionDate >= Sdate && x.TransactionDate <= Edate)).ToList();
                            }
                            else
                            {
                                items = Db.StockLeader.GetAll().Where((x => x.TransactionDate >= Sdate && x.TransactionDate <= Edate && x.ProductId == Convert.ToInt32(ddProduct.SelectedValue))).ToList();
                            }
                            myList.Clear();
                            foreach (var item in items)
                            {
                                item.DrQty = item.DrQty == null ? 0 : item.DrQty;
                                item.CrQty = item.CrQty == null ? 0 : item.CrQty;
                                ProductName = Db.Product.Get(item.ProductId).ProductName;
                                if (ProductName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    myList.Add(new ProductLedgerDTO { TransactionDate = item.TransactionDate, TransactionType = item.TransactionType, TransactionDetail = item.TransactionDetail, ProductN = ProductName, DR = item.DrQty, CR = item.CrQty });
                                }
                            }
                            ResetPaging(myList);
                        }
                            
                    }
                    
                }
            }

        }


        #region Pagination

        private void ResetPaging(List<ProductLedgerDTO> ListTopagenate)
        {
            ProductLedgerGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            ProductLedgerGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            ProductLedgerGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            ProductLedgerGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            ProductLedgerGrid.ItemsSource = Pager.Last(myList);
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
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.ProductN, COLB = x.TransactionType, COLC = x.TransactionDate?.ToString("dd/MM/yyyy"), COLD = x.DR?.ToString(), COLE = x.CR?.ToString(), COLF="" }).ToList();
            string Discription = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL5Report(ref ReportViewer, "Product Ledger Report", "Product Name", "Transaction Type", "Date", "DR", "CR", Discription, RptData);
        }
    }
}