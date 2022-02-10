using Common;
using Common.Session;
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
    /// Interaction logic for UserControlSaleOrderReport.xaml
    /// </summary>

    
    public partial class UserControlSaleOrderReport : UserControl
    {
        List<SaleOrderDTO> myList = new List<SaleOrderDTO>();
        Pager<SaleOrderDTO> Pager = new Helper.Pager<SaleOrderDTO>();
        public UserControlSaleOrderReport()
        {
            InitializeComponent();
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
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;

                var Items = DB.SaleOrder.GetAll().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                string CustomerName = "";
                string EmployeeName = "";
                long GrandTotal = 0;
                myList.Clear();
                foreach(var item in Items)
                {
                    GrandTotal += item.Total;
                    CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                    EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                    myList.Add(new SaleOrderDTO { id = item.Id, Customer = CustomerName, Employee = EmployeeName, Date = item.OrderDate?.ToString("dd/MM/yyyy"), PaymentMode = item.PaymentMode, TotalAmount = item.Total.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
                }
                myList.Add(new SaleOrderDTO { Customer = "-", Employee = "-", Date = "", PaymentMode = "Total", TotalAmount = GrandTotal.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
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
                        if (t.Name == "GridCName")
                        {
                            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;

                            var Items = DB.SaleOrder.GetAll().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                            string CustomerName = "";
                            string EmployeeName = "";
                            long GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                                if (CustomerName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                    GrandTotal += item.Total;
                                    myList.Add(new SaleOrderDTO { id = item.Id, Customer = CustomerName, Employee = EmployeeName, Date = item.OrderDate?.ToString("dd/MM/yyyy"), PaymentMode = item.PaymentMode, TotalAmount = item.Total.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
                                }
                                
                            }
                            myList.Add(new SaleOrderDTO { Customer = "-", Employee = "-", Date = "", PaymentMode = "Total", TotalAmount = GrandTotal.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
                            ResetPaging(myList);
                        }
                        if (t.Name == "GridEmployee")
                        {
                            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;

                            var Items = DB.SaleOrder.GetAll().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                            string CustomerName = "";
                            string EmployeeName = "";
                            long GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                if (EmployeeName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    GrandTotal += item.Total;
                                    myList.Add(new SaleOrderDTO { id = item.Id, Customer = CustomerName, Employee = EmployeeName, Date = item.OrderDate?.ToString("dd/MM/yyyy"), PaymentMode = item.PaymentMode, TotalAmount = item.Total.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
                                }
                            }
                            myList.Add(new SaleOrderDTO { Customer = "-", Employee = "-", Date = "", PaymentMode = "Total", TotalAmount = GrandTotal.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
                            ResetPaging(myList);
                        }
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

                            var Items = DB.SaleOrder.GetAll().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                            string CustomerName = "";
                            string EmployeeName = "";
                            string PaymentMode = "";
                            long GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                PaymentMode = item.PaymentMode;
                                if (PaymentMode.ToUpper().Contains(filter.ToUpper()))
                                {
                                    GrandTotal += item.Total;
                                    myList.Add(new SaleOrderDTO { id = item.Id, Customer = CustomerName, Employee = EmployeeName, Date = item.OrderDate?.ToString("dd/MM/yyyy"), PaymentMode = item.PaymentMode, TotalAmount = item.Total.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
                                }
                            }
                            myList.Add(new SaleOrderDTO { Customer = "-", Employee = "-", Date = "-", PaymentMode = "Total", TotalAmount = GrandTotal.ToString("C", CultureInfo.CreateSpecificCulture(GetCurrency())) });
                            ResetPaging(myList);
                        }
                    }
                    ResetPaging(myList);
                }
            }

        }

        private void btnSaleOrderDetail_Click(object sender, RoutedEventArgs e)
        {

            EZYPOS.DTO.SaleOrderDTO SaleOrder = (EZYPOS.DTO.SaleOrderDTO)SaleOrderGrid.SelectedItem;
            WindowSaleOrderDetail SaleOrderDetail = new WindowSaleOrderDetail(SaleOrder);
            SaleOrderDetail.Show();
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

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.Customer, COLB = x.Employee, COLC = x.Date, COLD = x.PaymentMode, COLE = x.TotalAmount, COLF = "" }).ToList();
            string Discription = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL5Report(ref ReportViewer, "Sale Order Report", "Customer Name", "Employee Name", "Date", "Payment Mode", "Amount", Discription, RptData);

        }
    }
}