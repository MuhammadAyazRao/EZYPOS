﻿using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserControlEmployeeWiseSaleReport.xaml
    /// </summary>
    public partial class UserControlEmployeeWiseSaleReport : UserControl
    {
        List<SaleOrderDTO> myList = new List<SaleOrderDTO>();
        Pager<SaleOrderDTO> Pager = new Helper.Pager<SaleOrderDTO>();
        public UserControlEmployeeWiseSaleReport()
        {
            InitializeComponent();
            using(UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                var EmployeeList = DB.Employee.GetAll().Select(x => new { Name = x.UserName, Id = x.Id }).ToList();
                EmployeeList.Insert(0, new { Name = "All", Id = 0 });
                ddEmployee.ItemsSource = EmployeeList;
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
                long GrandTotal = 0;
                myList.Clear();
                foreach (var item in Items)
                {
                    GrandTotal += item.Total;
                    CustomerName = DB.Customers.Get(Convert.ToInt32(item.CustomerId)).Name;
                    EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                    myList.Add(new SaleOrderDTO { id = item.Id, Customer = CustomerName, Employee = EmployeeName, Date = Convert.ToString(item.OrderDate), PaymentMode = item.PaymentMode, TotalAmount = Convert.ToString(item.Total) });
                }
                myList.Add(new SaleOrderDTO { Customer = "-", Employee = "-", Date = "-", PaymentMode = "Total", TotalAmount = Convert.ToString(GrandTotal) });
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
                if (ddEmployee.SelectedItem == null || Convert.ToInt32(ddEmployee.SelectedValue) == 0)
                {
                    SaleOrders = Db.SaleOrder.GetAll().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                }
                else 
                {
                    SaleOrders = Db.SaleOrder.GetAll().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate && x.EmployeeId == Convert.ToInt32(ddEmployee.SelectedValue)).ToList();
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
                        if (t.Name == "GridCName")
                        {
                            var Items = GetSaleOrders();
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
                                    myList.Add(new SaleOrderDTO { id = item.Id, Customer = CustomerName, Employee = EmployeeName, Date = Convert.ToString(item.OrderDate), PaymentMode = item.PaymentMode, TotalAmount = Convert.ToString(item.Total) });
                                }

                            }
                            myList.Add(new SaleOrderDTO { Customer = "-", Employee = "-", Date = "-", PaymentMode = "Total", TotalAmount = Convert.ToString(GrandTotal) });
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
                                    myList.Add(new SaleOrderDTO { id = item.Id, Customer = CustomerName, Employee = EmployeeName, Date = Convert.ToString(item.OrderDate), PaymentMode = item.PaymentMode, TotalAmount = Convert.ToString(item.Total) });
                                }
                            }
                            myList.Add(new SaleOrderDTO { Customer = "-", Employee = "-", Date = "-", PaymentMode = "Total", TotalAmount = Convert.ToString(GrandTotal) });
                            ResetPaging(myList);
                        }
                    }
                    ResetPaging(myList);
                }
            }

        }

        //private void btnSaleOrderDetail_Click(object sender, RoutedEventArgs e)
        //{

        //    EZYPOS.DTO.SaleOrderDTO SaleOrder = (EZYPOS.DTO.SaleOrderDTO)SaleOrderGrid.SelectedItem;
        //    WindowSaleOrderDetail SaleOrderDetail = new WindowSaleOrderDetail(SaleOrder);
        //    SaleOrderDetail.Show();
        //}


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
    }
}