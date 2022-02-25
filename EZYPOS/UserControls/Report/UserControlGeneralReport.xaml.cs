using Common;
using Common.Session;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.DTO.ReportsDTO;
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
    /// Interaction logic for UserControlGeneralReport.xaml
    /// </summary>
    public partial class UserControlGeneralReport : UserControl
    {
        List<GeneralReportDTO> myList = new List<GeneralReportDTO>();
        Pager<GeneralReportDTO> Pager = new Helper.Pager<GeneralReportDTO>();

        public UserControlGeneralReport()
        {
            InitializeComponent();
            var Months = Month.GetMonths().Select(x => new { Name = x.Name, Id = x.Id });
            ddMonth.ItemsSource = Months;
            ddYear.ItemsSource = Enumerable.Range(1950, DateTime.UtcNow.Year - 1949).Reverse().ToList();
            ddMonth.SelectedValue = DateTime.Now.Month;
            ddYear.SelectedIndex = 0;

            Refresh();
        }
        private void Refresh(object sender = null)
        {
            myList.Clear();
            ResetPaging(myList);
            if(ddMonth.SelectedItem == null || ddYear.SelectedItem == null)
            {
                return;
            }
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var StartDate = new DateTime(Convert.ToInt32(ddYear.Text), Convert.ToInt32(ddMonth.SelectedValue), 1);
                var EndDate = StartDate.AddMonths(1).AddDays(-1);
                // Sale 
                var SaleOrders = DB.SaleOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate).ToList();
                var CashSaleAmount = SaleOrders.Where(x => x.PaymentType == PaymentType.CASH).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var CreditSaleAmount = SaleOrders.Where(x => x.PaymentType == PaymentType.CREDIT).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var TotalSaleAmount = SaleOrders.Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var TotalCostOfSale = SaleOrders.Select(x => new { total = x.OrdersDetails?.Sum(v => v.Item.PurchasePrice * v.Qty) }).Sum(x => x.total);

                //Profit Loss
                long? Profit = 0;
                long? Loss = 0;
                if(TotalSaleAmount >= TotalCostOfSale)
                {
                    Profit = TotalSaleAmount - TotalCostOfSale;
                }
                else
                {
                    Loss = TotalCostOfSale - TotalSaleAmount;
                }
                // Purchase
                var PurchaseOrders = DB.PurchaseOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate).ToList();
                var CashPurchaseAmount = PurchaseOrders.Where(x => x.PaymentType == PaymentType.CASH).Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var CreditPurchaseAmount = PurchaseOrders.Where(x => x.PaymentType == PaymentType.CREDIT).Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var TotalPurchaseAmount = PurchaseOrders.Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);

                //Salaries
                var Salaries = DB.AdvanceSalary.GetAll().Where(x => x.Date >= StartDate && x.Date <= EndDate);
                long? TotalSalary = 0;
                foreach(var item in Salaries)
                {
                    TotalSalary += item.Amount;
                }

                //Expense
                var items = DB.expt.GetAll().Where(x => x.ExpenceDate >= StartDate && x.ExpenceDate <= EndDate).ToList();
                decimal? TotalExpenses = 0;
                foreach (var item in items)
                {
                    TotalExpenses += item.Amount;
                }

                //Formation of list 
                myList.Add(new GeneralReportDTO { SerialNo = "1", Key = "Credit Sale", Value = CreditSaleAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                myList.Add(new GeneralReportDTO { SerialNo = "2", Key = "Cash Sale", Value = CashSaleAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                myList.Add(new GeneralReportDTO { SerialNo = "3", Key = "Total Sale", Value = TotalSaleAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                myList.Add(new GeneralReportDTO { SerialNo = "4", Key = "Credit Purchase", Value = CreditPurchaseAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                myList.Add(new GeneralReportDTO { SerialNo = "5", Key = "Cash Purchase", Value = CashPurchaseAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                myList.Add(new GeneralReportDTO { SerialNo = "6", Key = "Total Purchase", Value = TotalPurchaseAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                myList.Add(new GeneralReportDTO { SerialNo = "7", Key = "Profit", Value = Profit?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                myList.Add(new GeneralReportDTO { SerialNo = "8", Key = "Loss", Value = Loss?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                myList.Add(new GeneralReportDTO { SerialNo = "9", Key = "Total Salary", Value = TotalSalary?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
                myList.Add(new GeneralReportDTO { SerialNo = "10", Key = "Expense", Value = TotalExpenses?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
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
            string Discription = "For Month: " + ddMonth.Text + ", Year: " + ddYear.Text;
            ReportPrintHelper.PrintCOL3Report(ref ReportViewer, "General Report", "Serial No", "Key", "Value", Discription, RptData);

        }
    }
}
