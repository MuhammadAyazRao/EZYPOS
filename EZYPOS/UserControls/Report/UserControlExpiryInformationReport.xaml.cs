using Common.DTO;
using DAL.Repository;
using EZYPOS.DTO.ReportsDTO;
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
    /// Interaction logic for UserControlExpiryInformationReport.xaml
    /// </summary>
    public partial class UserControlExpiryInformationReport : UserControl
    {
        List<StockDetailDTO> myList = new List<StockDetailDTO>();
        Pager<StockDetailDTO> Pager = new Helper.Pager<StockDetailDTO>();
        public UserControlExpiryInformationReport()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var CategoryList = DB.ProductCategory.GetAll().Select(x=> new { Name = x.Name , Id = x.Id}).ToList();
                CategoryList.Insert(0, new { Name = "All", Id = 0 });
                DDCategory.ItemsSource = CategoryList;
                var monthList = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames.Select((item, index) => new
                {
                    Month = item,
                    Value = index + 1
                });
                DDMonth.ItemsSource = monthList;
            }
            Refresh();

        }
        private void Refresh(object sender = null)
        {
            myList.Clear();
            if (DDMonth.SelectedValue != null)
            {
                var StartDate = DateTime.Today;
                var MidDate = StartDate.AddMonths(Convert.ToInt32(DDMonth.SelectedValue));
                var EndDate = new DateTime(MidDate.Year, MidDate.Month, DateTime.DaysInMonth(MidDate.Year, MidDate.Month));
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (DDCategory.SelectedValue == null || DDCategory.SelectedIndex == 0)
                    {
                        var products = DB.Product.GetAll().ToList();
                        foreach (var product in products)
                        {
                            var stockDetail = DB.Stock.GetStockDetail().Where(x => x.ProductId == product.Id && x.ExpirationDate >= StartDate && x.ExpirationDate <= EndDate).ToList();
                            foreach (var item in stockDetail)
                            {
                                myList.Add(new StockDetailDTO { ProductName = item.ProductName, AvailableQty = item.AvailableQty, StartDate = item.StartDate, ExpirationDate = item.ExpirationDate });
                            }
                        }
                    }
                    else
                    {
                        var products = DB.Product.GetAll().Where(x => x.CategoryId == Convert.ToInt32(DDCategory.SelectedValue)).ToList();
                        foreach (var product in products)
                        {
                            var stockDetail = DB.Stock.GetStockDetail().Where(x => x.ProductId == product.Id && x.ExpirationDate >= StartDate && x.ExpirationDate <= EndDate).ToList();
                            foreach (var item in stockDetail)
                            {
                                myList.Add(new StockDetailDTO { ProductName = item.ProductName, AvailableQty = item.AvailableQty, StartDate = item.StartDate, ExpirationDate = item.ExpirationDate });
                            }
                        }
                    }
                    ResetPaging(myList);
                }

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
            string Category = "All";
            if (DDCategory.SelectedValue != null || DDCategory.SelectedIndex != 0)
            {
                Category = DDCategory.Text;
            }
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.ProductName, COLB = x.AvailableQty.ToString(), COLC = x.StartDate.ToString("dd/MM/yyyy"), COLD = x.ExpirationDate.ToString("dd/MM/yyyy"), COLE = "", COLF = "" }).ToList();
            string Discription = "Stock Expiring Within Next " + DDMonth.SelectedValue + " Months:   Category = " + Category + ":"; //"From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL4Report(ref ReportViewer, "Expiry Information Report", "Product Name", "Available Quantity", "Start Date", "Expiry Date", Discription, RptData);

        }

    }
}