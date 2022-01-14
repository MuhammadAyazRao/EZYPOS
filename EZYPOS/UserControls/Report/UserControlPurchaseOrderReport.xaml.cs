using Common.Session;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserControlPurchaseOrderReport.xaml
    /// </summary>
    public partial class UserControlPurchaseOrderReport : UserControl
    {
        List<PurchaseOrderReportDTO> myList = new List<PurchaseOrderReportDTO>();
        Pager<PurchaseOrderReportDTO> Pager = new Helper.Pager<PurchaseOrderReportDTO>();
        public UserControlPurchaseOrderReport()
        {
            InitializeComponent();
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;

            Refresh();

        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                var Items = DB.PurchaseOrder.GetAll().Where(x => x.Date >= Sdate && x.Date <= Edate).ToList();
                string SupplierName = "";
                string EmployeeName = "";
                int? GrandTotal = 0;
                myList.Clear();
                foreach(var item in Items)
                {
                    SupplierName = DB.Supplier.Get(item.SupplierId).Name;
                    EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                    GrandTotal += item.TotalAmount;
                    myList.Add(new PurchaseOrderReportDTO { id= item.Id, Supplier = SupplierName, Employee = EmployeeName, PaymentMode = item.PaymentMode, PaymentStatus = item.PaymentStatus, Date = Convert.ToString(item.Date), TotalAmount = Convert.ToString(item.TotalAmount) });
                }
                myList.Add(new PurchaseOrderReportDTO {Supplier = "-", Employee = "-", PaymentMode = "Total", PaymentStatus = "-", Date = "-", TotalAmount = Convert.ToString(GrandTotal) });
                ResetPaging(myList);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
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
                        if (t.Name == "GridSupplier")
                        {
                            var Items = DB.PurchaseOrder.GetAll().Where(x => x.Date >= Sdate && x.Date <= Edate).ToList();
                            string SupplierName = "";
                            string EmployeeName = "";
                            int? GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                SupplierName = DB.Supplier.Get(item.SupplierId).Name;
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                if(SupplierName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    GrandTotal += item.TotalAmount;
                                    myList.Add(new PurchaseOrderReportDTO { id = item.Id, Supplier = SupplierName, Employee = EmployeeName, PaymentMode = item.PaymentMode, PaymentStatus = item.PaymentStatus, Date = Convert.ToString(item.Date), TotalAmount = Convert.ToString(item.TotalAmount) });
                                }
                                
                            }
                            myList.Add(new PurchaseOrderReportDTO { Supplier = "-", Employee = "-", PaymentMode = "Total", PaymentStatus = "-", Date = "-", TotalAmount = Convert.ToString(GrandTotal) });
                        }
                        if (t.Name == "GridEmployee")
                        {
                            var Items = DB.PurchaseOrder.GetAll().Where(x => x.Date >= Sdate && x.Date <= Edate).ToList();
                            string SupplierName = "";
                            string EmployeeName = "";
                            int? GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                SupplierName = DB.Supplier.Get(item.SupplierId).Name;
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                if (EmployeeName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    GrandTotal += item.TotalAmount;
                                    myList.Add(new PurchaseOrderReportDTO { id = item.Id, Supplier = SupplierName, Employee = EmployeeName, PaymentMode = item.PaymentMode, PaymentStatus = item.PaymentStatus, Date = Convert.ToString(item.Date), TotalAmount = Convert.ToString(item.TotalAmount) });
                                }

                            }
                            myList.Add(new PurchaseOrderReportDTO { Supplier = "-", Employee = "-", PaymentMode = "Total", PaymentStatus = "-", Date = "-", TotalAmount = Convert.ToString(GrandTotal) });
                        }
                        if (t.Name == "GridDate")
                        {

                        }
                        if (t.Name == "GridPaymentStatus")
                        {
                            var Items = DB.PurchaseOrder.GetAll().Where(x => x.Date >= Sdate && x.Date <= Edate).ToList();
                            string SupplierName = "";
                            string EmployeeName = "";
                            int? GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                SupplierName = DB.Supplier.Get(item.SupplierId).Name;
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                if (item.PaymentStatus.ToUpper().Contains(filter.ToUpper()))
                                {
                                    GrandTotal += item.TotalAmount;
                                    myList.Add(new PurchaseOrderReportDTO { id = item.Id, Supplier = SupplierName, Employee = EmployeeName, PaymentMode = item.PaymentMode, PaymentStatus = item.PaymentStatus, Date = Convert.ToString(item.Date), TotalAmount = Convert.ToString(item.TotalAmount) });
                                }

                            }
                            myList.Add(new PurchaseOrderReportDTO { Supplier = "-", Employee = "-", PaymentMode = "Total", PaymentStatus = "-", Date = "-", TotalAmount = Convert.ToString(GrandTotal) });
                        }
                        if (t.Name == "GridPaymentMode")
                        {
                            var Items = DB.PurchaseOrder.GetAll().Where(x => x.Date >= Sdate && x.Date <= Edate).ToList();
                            string SupplierName = "";
                            string EmployeeName = "";
                            int? GrandTotal = 0;
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                SupplierName = DB.Supplier.Get(item.SupplierId).Name;
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                if (item.PaymentMode.ToUpper().Contains(filter.ToUpper()))
                                {
                                    GrandTotal += item.TotalAmount;
                                    myList.Add(new PurchaseOrderReportDTO { id = item.Id, Supplier = SupplierName, Employee = EmployeeName, PaymentMode = item.PaymentMode, PaymentStatus = item.PaymentStatus, Date = Convert.ToString(item.Date), TotalAmount = Convert.ToString(item.TotalAmount) });
                                }

                            }
                            myList.Add(new PurchaseOrderReportDTO { Supplier = "-", Employee = "-", PaymentMode = "Total", PaymentStatus = "-", Date = "-", TotalAmount = Convert.ToString(GrandTotal) });
                        }
                        if (t.Name == "GridTotalAmount")
                        {

                        }
                        ResetPaging(myList);
                    }
                    
                }
            }

        }

        private void btnPuchaseOrderDetail_Click(object sender, RoutedEventArgs e)
        {

            EZYPOS.DTO.PurchaseOrderReportDTO PurchaseOrder = (EZYPOS.DTO.PurchaseOrderReportDTO)PurchaseOrderGrid.SelectedItem;
            WindowPurchaseOrderDetail SaleOrderDetail = new WindowPurchaseOrderDetail(PurchaseOrder);
            SaleOrderDetail.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHome("");
        }

        #region Pagination

        private void ResetPaging(List<PurchaseOrderReportDTO> ListTopagenate)
        {
            PurchaseOrderGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            PurchaseOrderGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrderGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrderGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrderGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }


        #endregion
    }
}