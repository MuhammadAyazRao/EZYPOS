using Common;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.DTO.ReportsDTO;
using EZYPOS.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UserControlPOSWiseSaleReport.xaml
    /// </summary>
    public partial class UserControlPOSWiseSaleReport : UserControl
    {
        List<SaleOrderDTO> myList = new List<SaleOrderDTO>();
        Pager<SaleOrderDTO> Pager = new Helper.Pager<SaleOrderDTO>();
        public UserControlPOSWiseSaleReport()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                var POSList = DB.POS.GetAll().Select(x => new { Name = x.Name, Id = x.Id }).ToList();
                POSList.Insert(0, new { Name = "All", Id = 0 });
                ddPOS.ItemsSource = POSList;
            }
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            Refresh();

        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var Items = GetSaleOrders();
                string CustomerName = "";
                string EmployeeName = "";
                decimal GrandTotal = 0;
                myList.Clear();
                foreach (var item in Items)
                {
                    if(item.OrderStatus == OrderStatus.Refunded.ToString())
                    {
                        GrandTotal -= item.Total;
                    }
                    else
                    {
                        GrandTotal += item.Total;
                    }
                    CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                    EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                    myList.Add(new SaleOrderDTO { id = item.Id, POS= item.Posid, Customer = CustomerName, Employee = EmployeeName, Date = item.OrderDate?.ToString("dd/MM/yyyy"), PaymentMode = item.PaymentMode, TotalAmount = item.Total.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), OrderStatus = item.OrderStatus });
                }
                myList.Add(new SaleOrderDTO { POS= "-", Customer = "-", Employee = "-", Date = "-", PaymentMode = "Total", TotalAmount = GrandTotal.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), OrderStatus = "" });
                ResetPaging(myList);
            }
        }
        public List<SaleOrder> GetSaleOrders()
        {
            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
            List<SaleOrder> SaleOrders = new List<SaleOrder>();
            using (UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
            {
                if (ddPOS.SelectedItem == null || Convert.ToInt32(ddPOS.SelectedValue) == 0)
                {
                    SaleOrders = Db.SaleOrder.GetAll().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate && x.OrderStatus != OrderStatus.Deleted.ToString()  && x.OrderStatus != OrderStatus.Canceled.ToString()).ToList();
                }
                else
                {
                    SaleOrders = Db.SaleOrder.GetAll().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate && x.Posid == ddPOS.Text && x.OrderStatus != OrderStatus.Deleted.ToString() && x.OrderStatus != OrderStatus.Canceled.ToString()).ToList();
                }
                return SaleOrders;
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
                        if (t.Name == "GridOrderNumber")
                        {
                            var Items = GetSaleOrders();
                            Items = Items.Where(x => x.Id == Convert.ToInt32(filter)).ToList();
                            string CustomerName = "";
                            string EmployeeName = "";
                            decimal GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                if (item.OrderStatus == OrderStatus.Refunded.ToString())
                                {
                                    GrandTotal -= item.Total;
                                }
                                else
                                {
                                    GrandTotal += item.Total;
                                }
                                CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                myList.Add(new SaleOrderDTO { id = item.Id, Customer = CustomerName, Employee = EmployeeName, Date = item.OrderDate?.ToString("dd/MM/yyyy"), PaymentMode = item.PaymentMode, TotalAmount = item.Total.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), OrderStatus = item.OrderStatus });
                            }
                            myList.Add(new SaleOrderDTO { Customer = "-", Employee = "-", Date = "-", PaymentMode = "Total", TotalAmount = GrandTotal.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), OrderStatus = "" });
                            ResetPaging(myList);
                        }
                        if (t.Name == "GridCName")
                        {
                            var Items = GetSaleOrders();
                            string CustomerName = "";
                            string EmployeeName = "";
                            decimal GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                                if (CustomerName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                    if (item.OrderStatus == OrderStatus.Refunded.ToString())
                                    {
                                        GrandTotal -= item.Total;
                                    }
                                    else
                                    {
                                        GrandTotal += item.Total;
                                    }
                                    myList.Add(new SaleOrderDTO { id = item.Id, POS= item.Posid, Customer = CustomerName, Employee = EmployeeName, Date = item.OrderDate?.ToString("dd/MM/yyyy"), PaymentMode = item.PaymentMode, TotalAmount = item.Total.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), OrderStatus = item.OrderStatus });
                                }

                            }
                            myList.Add(new SaleOrderDTO { POS = "-", Customer = "-", Employee = "-", Date = "-", PaymentMode = "Total", TotalAmount = GrandTotal.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), OrderStatus = "" });
                            ResetPaging(myList);
                        }
                        //if (t.Name == "GridEmployee")
                        //{
                        //    var Items = GetSaleOrders();
                        //    string CustomerName = "";
                        //    string EmployeeName = "";
                        //    long GrandTotal = 0;
                        //    myList.Clear();
                        //    foreach (var item in Items)
                        //    {
                        //        CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                        //        EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                        //        if (EmployeeName.ToUpper().Contains(filter.ToUpper()))
                        //        {
                        //            GrandTotal += item.Total;
                        //            myList.Add(new SaleOrderDTO { id = item.Id, Customer = CustomerName, Employee = EmployeeName, Date = Convert.ToString(item.OrderDate), PaymentMode = item.PaymentMode, TotalAmount = Convert.ToString(item.Total) });
                        //        }
                        //    }
                        //    myList.Add(new SaleOrderDTO { Customer = "-", Employee = "-", Date = "Total", PaymentMode = "-", TotalAmount = Convert.ToString(GrandTotal) });
                        //    ResetPaging(myList);
                        //}
                        if (t.Name == "GridOrderDate")
                        {

                        }
                        if (t.Name == "GridOrderAmount")
                        {

                        }
                        if (t.Name == "GridPaymentMode")
                        {
                            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;

                            var Items = GetSaleOrders();
                            string CustomerName = "";
                            string EmployeeName = "";
                            string PaymentMode = "";
                            decimal GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                PaymentMode = item.PaymentMode;
                                if (PaymentMode.ToUpper().Contains(filter.ToUpper()))
                                {
                                    if (item.OrderStatus == OrderStatus.Refunded.ToString())
                                    {
                                        GrandTotal -= item.Total;
                                    }
                                    else
                                    {
                                        GrandTotal += item.Total;
                                    }
                                    myList.Add(new SaleOrderDTO { id = item.Id, POS= item.Posid, Customer = CustomerName, Employee = EmployeeName, Date = item.OrderDate?.ToString("dd/MM/yyyy"), PaymentMode = item.PaymentMode, TotalAmount = item.Total.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), OrderStatus = item.OrderStatus });
                                }
                            }
                            myList.Add(new SaleOrderDTO { POS = "-", Customer = "-", Employee = "-", Date = "-", PaymentMode = "Total", TotalAmount = GrandTotal.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), OrderStatus = "" });
                            ResetPaging(myList);
                        }
                    }
                    ResetPaging(myList);
                }
            }

        }


        #region Pagination

        private void ResetPaging(List<SaleOrderDTO> ListTopagenate)
        {
            SaleOrderGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            SaleOrderGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            SaleOrderGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            SaleOrderGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            SaleOrderGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }


        #endregion
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TodayOrder_Click(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            Refresh();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.id.ToString(),COLB = x.POS, COLC = x.Customer, COLD = x.Date, COLE = x.PaymentMode, COLF = x.TotalAmount,}).ToList();
            string Discription = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL6Report(ref ReportViewer, "POS Wise Sale Report", "Order Number", "POS", "Customer Name", "Date", "Transaction Type", "Amount", Discription, RptData);
        }
    }
}