using Common.Session;
using DAL.Repository;
using EZYPOS.DTO.ReportsDTO;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.UserControls.Define.Crud;
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
using static Common.OrderEnums;

namespace EZYPOS.UserControls.Report
{
    /// <summary>
    /// Interaction logic for UserControlDailyOrderReport.xaml
    /// </summary>
    public partial class UserControlDailyOrderReport : UserControl
    {
        List<GeneralReportDTO> myList = new List<GeneralReportDTO>();
        Pager<GeneralReportDTO> Pager = new Helper.Pager<GeneralReportDTO>();

        public UserControlDailyOrderReport()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
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
            myList.Clear();
            ResetPaging(myList);

            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                // Sale 
                List<Common.DTO.Order> SaleOrders = new List<Common.DTO.Order>();
                if (ddPOS.SelectedValue == null || Convert.ToInt32(ddPOS.SelectedValue) == 0)
                {
                    SaleOrders = DB.SaleOrder.GetMappedOrder().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate && x.OrderStatus != Common.OrderStatus.Deleted.ToString() && x.OrderStatus != Common.OrderStatus.Canceled.ToString()).ToList();
                }
                else
                {
                    SaleOrders = DB.SaleOrder.GetMappedOrder().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate && x.OrderStatus != Common.OrderStatus.Deleted.ToString() && x.OrderStatus != Common.OrderStatus.Canceled.ToString() && x.POS == ddPOS.Text).ToList();
                }
                var CashSaleOrders = SaleOrders.Where(x => x.PaymentType == PaymentType.CASH && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Count();
                var CreditSaleOrders = SaleOrders.Where(x => x.PaymentType == PaymentType.CREDIT && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Count();
                var TotalSaleOrders = SaleOrders.Where(x => x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Count();

                
                // Purchase
                var PurchaseOrders = DB.PurchaseOrder.GetMappedOrder().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                var CashPurchaseOrders = PurchaseOrders.Where(x => x.PaymentType == PaymentType.CASH).Count();
                var CreditPurchaseOrders = PurchaseOrders.Where(x => x.PaymentType == PaymentType.CREDIT).Count();
                var TotalPurchaseOrders = PurchaseOrders.Count();


                //Formation of list 
                myList.Add(new GeneralReportDTO { SerialNo = "1", Key = "Credit Sale Orders", Value = CreditSaleOrders.ToString() });
                myList.Add(new GeneralReportDTO { SerialNo = "2", Key = "Cash Sale Orders", Value = CashSaleOrders.ToString() });
                myList.Add(new GeneralReportDTO { SerialNo = "3", Key = "Total Sale Orders", Value = TotalSaleOrders.ToString() });
                myList.Add(new GeneralReportDTO { SerialNo = "4", Key = "Credit Purchase Orders", Value = CreditPurchaseOrders.ToString() });
                myList.Add(new GeneralReportDTO { SerialNo = "5", Key = "Cash Purchase Orders", Value = CashPurchaseOrders.ToString() });
                myList.Add(new GeneralReportDTO { SerialNo = "6", Key = "Total Purchase Orders", Value = TotalPurchaseOrders.ToString() });
                ResetPaging(myList);
            }

        }

        private void ResetPaging(List<GeneralReportDTO> ListTopagenate)
        {
            DG_Etransaction.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ExpenseTransactionDTO exp = (ExpenseTransactionDTO)DG_Etransaction.SelectedItem;
            ActiveSession.DisplayuserControlMethod(new UserControlExpenseTransactionCrud(exp));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.DisplayuserControlMethod(new UserControlExpenseTransactionCrud());
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
                        if (t.Name == "GridEtype")
                        {
                        }
                    }
                }
            }

        }

        private void btnBackwards_Click(object sender, RoutedEventArgs e)
        {
            DG_Etransaction.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            DG_Etransaction.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            DG_Etransaction.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            DG_Etransaction.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.SerialNo, COLB = x.Key, COLC = x.Value, COLD = "", COLE = "", COLF = "" }).ToList();
            string Discription = "From " + StartDate.Text + ", To " + EndDate.Text;
            ReportPrintHelper.PrintCOL3Report(ref ReportViewer, "Daily Order Report", "Serial No", "Key", "Value", Discription, RptData);

        }


    }
}
