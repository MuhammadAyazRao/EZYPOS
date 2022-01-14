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
    /// Interaction logic for UserControlProductWiseStockReport.xaml
    /// </summary>
    public partial class UserControlProductWiseStockReport : UserControl
    {
        List<ProductWiseStockReportModel> myList { get; set; }
        Pager<ProductWiseStockReportModel> Pager = new Helper.Pager<ProductWiseStockReportModel>();
        public UserControlProductWiseStockReport()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh(object sender = null)
        {

            myList = new ProductWiseStockReport().GetStockreportData();
            ResetPaging(myList);
           
        }
        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Text)
            {
                case "Search Product":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                

            }
        }

        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "txtSearch":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Search Product";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                

            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        #region Pagination

        private void ResetPaging(List<ProductWiseStockReportModel> ListTopagenate)
        {
            EmployeeGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            EmployeeGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)  //I couldn't get this function to update in place (if the grid showed 20 and I selected 100 it would jump to 200)
        {                                                                                          //So instead I had it call the First function and that does an acceptable job.
                                                                                                   // numberOfRecPerPage = Convert.ToInt32(NumberOfRecords.SelectedItem);
                                                                                                   //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }


        #endregion



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
                        myList = new ProductWiseStockReport().GetStockreportData();
                        ResetPaging(myList);
                    }
                    else
                    {
                        {
                            {

                                if (t.Name == "GridName")
                                {
                                    myList = new ProductWiseStockReport().GetStockreportData(filter);
                                    ResetPaging(myList);
                                }
                                
                            }
                        }
                    }
                }
            }

        }
    }
}
