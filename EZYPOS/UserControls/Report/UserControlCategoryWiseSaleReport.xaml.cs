using DAL.Repository;
using EZYPOS.DTO.ReportsDTO;
using EZYPOS.DTO;
using EZYPOS.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for UserControlCategoryWiseSaleReport.xaml
    /// </summary>
    public partial class UserControlCategoryWiseSaleReport : UserControl
    {
        List<CategoryWiseSaleDTO> myList = new List<CategoryWiseSaleDTO>();
        Pager<CategoryWiseSaleDTO> Pager = new Helper.Pager<CategoryWiseSaleDTO>();
        public UserControlCategoryWiseSaleReport()
        {
            InitializeComponent();

            Refresh();
        }
        void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                //DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                //DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;

                var items = Db.SaleOrderDetail.GetAll().ToList().GroupBy(x => x.CategoryId).Select(x => new { CategoryId = x.Key, CategoryName = x.First().CatName, OrderCount = x.Count(), Price = x.Sum(v => v.ItemPrice) }).ToList();
                decimal TotalOrders = 0;
                decimal TotalPrice = 0;
                myList.Clear();
                foreach (var item in items)
                {
                    TotalOrders += (decimal)item.OrderCount;
                    TotalPrice += (decimal)item.Price;

                    myList.Add(new CategoryWiseSaleDTO { CategoryName = item.CategoryName, OrderCount = item.OrderCount.ToString(), Price = item.Price?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                }
                myList.Add(new CategoryWiseSaleDTO { CategoryName = "Total", OrderCount = TotalOrders.ToString(), Price = TotalPrice.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
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
                        if (t.Name == "GridCategoryName")
                        {
                            //DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                            //DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;

                            var items = Db.SaleOrderDetail.GetAll().GroupBy(x => x.CategoryId).Select(x => new { CategoryId = x.Key, CategoryName = x.FirstOrDefault().CatName, OrderCount = x.Count(), Price = x.Sum(v => v.ItemPrice) }).ToList();
                            decimal TotalOrders = 0;
                            decimal TotalPrice = 0;
                            myList.Clear();
                            foreach (var item in items)
                            {
                                TotalOrders += (decimal)item.OrderCount;
                                TotalPrice += (decimal)item.Price;

                                myList.Add(new CategoryWiseSaleDTO { CategoryName = item.CategoryName, OrderCount = item.OrderCount.ToString(), Price = item.Price?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                            }
                            myList.Add(new CategoryWiseSaleDTO { CategoryName = "Total", OrderCount = TotalOrders.ToString(), Price = TotalPrice.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                            ResetPaging(myList);
                        }
                    }

                }
            }

        }


        #region Pagination

        private void ResetPaging(List<CategoryWiseSaleDTO> ListTopagenate)
        {
            CategoryWiseSaleGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            CategoryWiseSaleGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            CategoryWiseSaleGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            CategoryWiseSaleGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            CategoryWiseSaleGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.CategoryName, COLB = x.OrderCount, COLC = x.Price, COLD = "", COLE = "", COLF = "" }).ToList();
            string Discription = "";
            ReportPrintHelper.PrintCOL3Report(ref ReportViewer, "Item Wise Sale Report", "Item Name", "Item Qty", "Item Price", Discription, RptData);

        }


        #endregion

        //private void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    Refresh();
        //}
    }
}