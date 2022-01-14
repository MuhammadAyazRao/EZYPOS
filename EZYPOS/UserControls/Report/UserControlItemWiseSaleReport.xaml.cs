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
    /// Interaction logic for UserControlItemWiseSaleReport.xaml
    /// </summary>
    public partial class UserControlItemWiseSaleReport : UserControl
    {
        List<ItemWiseSaleDTO> myList = new List<ItemWiseSaleDTO>();
        Pager<ItemWiseSaleDTO> Pager = new Helper.Pager<ItemWiseSaleDTO>();
        public UserControlItemWiseSaleReport()
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

                var items = Db.SaleOrderDetail.GetAll().GroupBy(x => x.ItemId).Select(x => new { ItemId = x.Key, ItemQty = x.Sum(v => v.ItemQty), ItemPrice = x.Sum(v => v.ItemPrice)}).ToList();
                decimal TotalQty = 0;
                decimal TotalPrice = 0;
                myList.Clear();
                foreach (var item in items)
                {
                    TotalQty += (decimal)item.ItemQty;
                    TotalPrice += (decimal)item.ItemPrice;

                    myList.Add(new ItemWiseSaleDTO { ItemName = Db.Product.Get((int)item.ItemId).ProductName, ItemQty = item.ItemQty.ToString(), ItemPrice = item.ItemPrice?.ToString()});
                }
                myList.Add(new ItemWiseSaleDTO { ItemName = "Total", ItemQty = TotalQty.ToString(), ItemPrice = TotalPrice.ToString() });
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
                        if (t.Name == "GridItemName")
                        {
                            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;

                            var items = Db.SaleOrderDetail.GetAll().GroupBy(x => x.ItemId).Select(x => new { ItemId = x.Key, ItemQty = x.Sum(v => v.ItemQty), ItemPrice = x.Sum(v => v.ItemPrice) }).ToList();
                            decimal TotalQty = 0;
                            decimal TotalPrice = 0;
                            string itemName = "";
                            myList.Clear();
                            foreach (var item in items)
                            {
                                itemName = Db.Product.Get((int)item.ItemId).ProductName;
                                if (itemName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    TotalQty += (decimal)item.ItemQty;
                                    TotalPrice += (decimal)item.ItemPrice;
                                    myList.Add(new ItemWiseSaleDTO { ItemName = itemName, ItemQty = item.ItemQty.ToString(), ItemPrice = item.ItemPrice?.ToString() });
                                }
                            }
                            myList.Add(new ItemWiseSaleDTO { ItemName = "Total", ItemQty = TotalQty.ToString(), ItemPrice = TotalPrice.ToString() });
                            ResetPaging(myList);
                        }
                    }

                }
            }

        }


        #region Pagination

        private void ResetPaging(List<ItemWiseSaleDTO> ListTopagenate)
        {
            ItemWiseSaleGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            ItemWiseSaleGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            ItemWiseSaleGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            ItemWiseSaleGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            ItemWiseSaleGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }


        #endregion

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}