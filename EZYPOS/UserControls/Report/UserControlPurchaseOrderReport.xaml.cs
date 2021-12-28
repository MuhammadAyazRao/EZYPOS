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
        List<PurchaseOrderReportDTO> myList { get; set; }
        Pager<PurchaseOrderReportDTO> Pager = new Helper.Pager<PurchaseOrderReportDTO>();
        public UserControlPurchaseOrderReport()
        {
            InitializeComponent();
            Refresh();

        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.PurchaseOrder.GetAll().Select(x => new PurchaseOrderReportDTO
                {
                    id = x.Id,
                    SupplierId = x.Supplier.Name,
                    Date = x.Date,
                    PaymentStatus = x.PaymentStatus,
                    PaymentMode = x.PaymentMode,
                    TotalAmount = x.TotalAmount,
                }).ToList();

                ResetPaging(myList);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    myList = DB.PurchaseOrder.GetAll().Select(x => new PurchaseOrderReportDTO
                    {
                        id = x.Id,
                        SupplierId = x.Supplier.Name,
                        Date = x.Date,
                        PaymentStatus = x.PaymentStatus,
                        PaymentMode = x.PaymentMode,
                        TotalAmount = x.TotalAmount,
                    }).ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    myList = DB.PurchaseOrder.GetAll().Where(x => x.Date >= Sdate && x.Date <= Edate).Select(x => new PurchaseOrderReportDTO
                    {
                        id = x.Id,
                        SupplierId = x.Supplier.Name,
                        Date = x.Date,
                        PaymentStatus = x.PaymentStatus,
                        PaymentMode = x.PaymentMode,
                        TotalAmount = x.TotalAmount,
                    }).ToList();
                }

                ResetPaging(myList);

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
                        myList = DB.PurchaseOrder.GetAll().Select(x => new PurchaseOrderReportDTO
                        {
                            id = x.Id,
                            SupplierId = x.Supplier.Name,
                            Date = x.Date,
                            PaymentStatus = x.PaymentStatus,
                            PaymentMode = x.PaymentMode,
                            TotalAmount = x.TotalAmount,
                        }).ToList();

                    }
                    else
                    {

                        {

                            if (t.Name == "GridSName")
                            {
                                myList = DB.PurchaseOrder.GetAll().Where(x => x.Supplier.Name.ToUpper().Contains(filter.ToUpper())).Select(x => new PurchaseOrderReportDTO
                                {
                                    id = x.Id,
                                    SupplierId = x.Supplier.Name,
                                    Date = x.Date,
                                    PaymentStatus = x.PaymentStatus,
                                    PaymentMode = x.PaymentMode,
                                    TotalAmount = x.TotalAmount,
                                }).ToList(); ;
                            }
                            if (t.Name == "GridDate")
                            {
                                myList = DB.PurchaseOrder.GetAll().Where(x => x.Date.ToString().Contains(filter)).Select(x => new PurchaseOrderReportDTO
                                {
                                    id = x.Id,
                                    SupplierId = x.Supplier.Name,
                                    Date = x.Date,
                                    PaymentStatus = x.PaymentStatus,
                                    PaymentMode = x.PaymentMode,
                                    TotalAmount = x.TotalAmount,
                                }).ToList(); ;


                            }
                            if (t.Name == "GridPaymentStatus")
                            {
                                myList = DB.PurchaseOrder.GetAll().Where(x => x.PaymentStatus.ToUpper().Contains(filter.ToUpper())).Select(x => new PurchaseOrderReportDTO
                                {
                                    id = x.Id,
                                    SupplierId = x.Supplier.Name,
                                    Date = x.Date,
                                    PaymentStatus = x.PaymentStatus,
                                    PaymentMode = x.PaymentMode,
                                    TotalAmount = x.TotalAmount,
                                }).ToList(); ;


                            }
                            if (t.Name == "GridPaymentMode")
                            {
                                myList = DB.PurchaseOrder.GetAll().Where(x => x.PaymentMode.ToString().ToUpper().StartsWith(filter.ToUpper())).Select(x => new PurchaseOrderReportDTO
                                {
                                    id = x.Id,
                                    SupplierId = x.Supplier.Name,
                                    Date = x.Date,
                                    PaymentStatus = x.PaymentStatus,
                                    PaymentMode = x.PaymentMode,
                                    TotalAmount = x.TotalAmount,
                                }).ToList(); ;


                            }
                            if (t.Name == "GridTotalAmount")
                            {
                                myList = DB.PurchaseOrder.GetAll().Where(x => x.TotalAmount.ToString().Contains(filter)).Select(x => new PurchaseOrderReportDTO
                                {
                                    id = x.Id,
                                    SupplierId = x.Supplier.Name,
                                    Date = x.Date,
                                    PaymentStatus = x.PaymentStatus,
                                    PaymentMode = x.PaymentMode,
                                    TotalAmount = x.TotalAmount,
                                }).ToList(); ;

                            }

                        };
                    }
                    ResetPaging(myList);
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