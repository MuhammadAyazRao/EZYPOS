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
using Microsoft.Reporting.NETCore;
using Microsoft.Reporting.WinForms;
using System.IO;
using DAL.Repository;
using Common.DTO;
using EZYPOS.Helper;

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
            Refresh();

        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                 myList = DB.Stock.GetStockDetail().ToList();
                ResetPaging(myList);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    
                }

                //ResetPaging(myList);

            }
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

                        {

                            if (t.Name == "GridProductName")
                            {
                                
                                List<StockDetailDTO> myList = DB.Stock.GetStockDetail().Where(x=> x.ProductName.ToUpper().Contains(filter.ToUpper())).ToList();
                                ResetPaging(myList);
                                
                            }
                            if (t.Name == "GridAvailableQty")
                            {
                                List<StockDetailDTO> myList = DB.Stock.GetStockDetail().Where(x => x.AvailableQty.ToString().Contains(filter)).ToList();
                                ResetPaging(myList);
                            }
                            if (t.Name == "GridStartDate")
                            {
                                List<StockDetailDTO> myList = DB.Stock.GetStockDetail().Where(x => x.StartDate.ToString().Contains(filter)).ToList();
                                ResetPaging(myList);
                            }
                            if (t.Name == "ExpirationDate")
                            {
                                List<StockDetailDTO> myList = DB.Stock.GetStockDetail().Where(x => x.ExpirationDate.ToString().Contains(filter)).ToList();
                                ResetPaging(myList);
                            }
                            

                        };
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
    }
}