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
using Microsoft.Reporting.WinForms;
using System.IO;
using DAL.Repository;
using Common.DTO;
using EZYPOS.Helper;
using EZYPOS.DTO.ReportsDTO;

namespace EZYPOS.UserControls.Report
{
    /// <summary>
    /// Interaction logic for UserControlStockExpiry.xaml
    /// </summary>
    public partial class UserControlStockExpiry : UserControl
    {
        List<StockDetailDTO> myList { get; set; }
        Pager<StockDetailDTO> Pager = new Helper.Pager<StockDetailDTO>();
        public UserControlStockExpiry()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var ProductList = DB.Product.GetAll().Select(x => new { Name = x.ProductName, Id = x.Id }).ToList();
                ProductList.Insert(0, new { Name = "All", Id = 0 });
                ddProduct.ItemsSource = ProductList;
            }
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            Refresh();

        }
        private void Refresh(object sender = null)
        {
            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if(ddProduct.SelectedValue == null || ddProduct.SelectedIndex == 0)
                {
                    myList = DB.Stock.GetStockDetail().Where(x => x.StartDate >= Sdate && x.StartDate <= Edate).ToList();
                }
                else
                {
                    myList = DB.Stock.GetStockDetail().Where(x => x.StartDate >= Sdate && x.StartDate <= Edate && x.ProductId == Convert.ToInt32(ddProduct.SelectedValue)).ToList();
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

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (filter == "")
                    {
                        Refresh();

                    }
                    else
                    {
                        DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                        DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                        if (ddProduct.SelectedValue == null || ddProduct.SelectedIndex == 0)
                        {
                            myList = DB.Stock.GetStockDetail().Where(x => x.StartDate >= Sdate && x.StartDate <= Edate).ToList();
                        }
                        else
                        {
                            myList = DB.Stock.GetStockDetail().Where(x => x.StartDate >= Sdate && x.StartDate <= Edate && x.ProductId == Convert.ToInt32(ddProduct.SelectedValue)).ToList();
                        }
                        if (t.Name == "GridProductName")
                        {
                            myList = myList.Where(x => x.ProductName.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridAvailableQty")
                        {
                            myList = myList.Where(x => x.AvailableQty.ToString().Contains(filter)).ToList();
                        }
                        if (t.Name == "GridStartDate")
                        {
                            myList = myList.Where(x => x.StartDate.ToString().Contains(filter)).ToList();
                        }
                        if (t.Name == "ExpirationDate")
                        {
                            myList = myList.Where(x => x.ExpirationDate.ToString().Contains(filter)).ToList();
                        }
                        ResetPaging(myList);
                    }
                    
                }
            }

        }


        #region Pagination

        private void ResetPaging(List<StockDetailDTO> ListTopagenate)
        {
            StockExpiryGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            StockExpiryGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            StockExpiryGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            StockExpiryGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            StockExpiryGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }


        #endregion

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.ProductName, COLB = x.AvailableQty.ToString(), COLC = x.StartDate.ToString("dd/MM/yyyy"), COLD = x.ExpirationDate.ToString("dd/MM/yyyy"), COLE = "", COLF = "" }).ToList();
            string Discription = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL4Report(ref ReportViewer, "Stock Expiry Report", "Product Name", "Available Quantity", "Start Date", "Expiry Date", Discription, RptData);

        }

        private void ddProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}