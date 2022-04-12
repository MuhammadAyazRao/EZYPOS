using DAL.Repository;
using EZYPOS.DTO;
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
    /// Interaction logic for UserControlProductWiseStockReport.xaml
    /// </summary>
    public partial class UserControlProductWiseStockReport : UserControl
    {
        List<ProductWiseStockReportModel> myList { get; set; }
        Pager<ProductWiseStockReportModel> Pager = new Helper.Pager<ProductWiseStockReportModel>();
        public UserControlProductWiseStockReport()
        {
            InitializeComponent();
            using (UnitOfWork UW = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var ProductList = UW.Product.GetAll().Select(x => new { Name = x.ProductName, Id = x.Id }).ToList();
                ProductList.Insert(0, new { Name = "All", Id = 0 });
                ddProduct.ItemsSource = ProductList;
            }
            Refresh();
        }

        private void Refresh(object sender = null)
        {

            //myList = new ProductWiseStockReport().GetStockreportData();
            if(ddProduct.SelectedIndex != 0 && ddProduct.SelectedValue != null)
            {
                using (UnitOfWork UW = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    int id = Convert.ToInt32(ddProduct.SelectedValue);
                    string SelectedProduct = UW.Product.Get(id).ProductName;
                    myList = new ProductWiseStockReport().GetStockreportData(SelectedProduct);
                }
            }
            else
            {
                myList = new ProductWiseStockReport().GetStockreportData();
            }
            ResetPaging(myList);
           
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
                        Refresh();
                        //myList = new ProductWiseStockReport().GetStockreportData();
                        //ResetPaging(myList);
                    }
                    else
                    {
                        {
                            {

                                //if (t.Name == "GridName")
                                //{
                                //    myList = new ProductWiseStockReport().GetStockreportData(filter);
                                //    ResetPaging(myList);
                                //}
                                
                            }
                        }
                    }
                }
            }

        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.ProductName, COLB = x.ProductStock.ToString(), COLC = "", COLD = "", COLE = "", COLF = "" }).ToList();
            string Discription = ""; //"From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL3Report(ref ReportViewer, "Product Wise Stock", "Product Name", "Product Stock", "", Discription, RptData);
        }

        private void ddProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
