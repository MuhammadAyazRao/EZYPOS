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
using DAL.Repository;
using LiveCharts;
using LiveCharts.Wpf;

namespace EZYPOS.View
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
            

            //pie chart
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;
            //pie chart
            BarChart();
            NegativeStackedRow();
        }
        public void BarChart()
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                //Current Year
                {
                    var StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                    var EndDate = DateTime.Today;
                    // Sales
                    var SaleOrders = DB.SaleOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate && x.OrderStatus != Common.OrderStatus.Deleted.ToString() && x.OrderStatus != Common.OrderStatus.Canceled.ToString()).ToList();
                    var TotalSaleAmount = SaleOrders.Where(x => x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                                        - SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                    var TotalCostOfSale = SaleOrders.Where(x => x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Item.PurchasePrice * v.Qty) }).Sum(x => x.total)
                                        - SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Item.PurchasePrice * v.Qty) }).Sum(x => x.total);
                    //Profit Loss
                    decimal? Profit = 0;
                    decimal? Loss = 0;
                    if (TotalSaleAmount >= TotalCostOfSale)
                    {
                        Profit = TotalSaleAmount - TotalCostOfSale;
                    }
                    else
                    {
                        Loss = TotalCostOfSale - TotalSaleAmount;
                    }
                    // Purchase
                    var PurchaseOrders = DB.PurchaseOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate).ToList();
                    var TotalPurchaseAmount = PurchaseOrders.Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                    //Expense
                    var items = DB.expt.GetAll().Where(x => x.ExpenceDate >= StartDate && x.ExpenceDate <= EndDate).ToList();
                    decimal? TotalExpenses = 0;
                    foreach (var item in items)
                    {
                        TotalExpenses += item.Amount;
                    }

                    SeriesCollection = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = DateTime.Now.Year.ToString(),
                            Values = new ChartValues<decimal> { Convert.ToDecimal(TotalSaleAmount), Convert.ToDecimal(TotalPurchaseAmount), Convert.ToDecimal(Profit),  Convert.ToDecimal(Loss), Convert.ToDecimal(TotalExpenses) }
                        }
                    };
                }

                //Previous Year
                {
                    var StartDate = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1);
                    var EndDate = DateTime.Today.AddYears(-1);
                    // Sales
                    var SaleOrders = DB.SaleOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate && x.OrderStatus != Common.OrderStatus.Deleted.ToString() && x.OrderStatus != Common.OrderStatus.Canceled.ToString()).ToList();
                    var TotalSaleAmount = SaleOrders.Where(x => x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                                        - SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                    var TotalCostOfSale = SaleOrders.Where(x => x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Item.PurchasePrice * v.Qty) }).Sum(x => x.total)
                                        - SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Item.PurchasePrice * v.Qty) }).Sum(x => x.total);
                    //Profit Loss
                    decimal? Profit = 0;
                    decimal? Loss = 0;
                    if (TotalSaleAmount >= TotalCostOfSale)
                    {
                        Profit = TotalSaleAmount - TotalCostOfSale;
                    }
                    else
                    {
                        Loss = TotalCostOfSale - TotalSaleAmount;
                    }
                    // Purchase
                    var PurchaseOrders = DB.PurchaseOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate).ToList();
                    var TotalPurchaseAmount = PurchaseOrders.Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                    //Expense
                    var items = DB.expt.GetAll().Where(x => x.ExpenceDate >= StartDate && x.ExpenceDate <= EndDate).ToList();
                    decimal? TotalExpenses = 0;
                    foreach (var item in items)
                    {
                        TotalExpenses += item.Amount;
                    }
                    SeriesCollection.Add(new ColumnSeries
                    {
                        Title = DateTime.Now.AddYears(-1).Year.ToString(),
                        Values = new ChartValues<decimal> { Convert.ToDecimal(TotalSaleAmount), Convert.ToDecimal(TotalPurchaseAmount), Convert.ToDecimal(Profit), Convert.ToDecimal(Loss), Convert.ToDecimal(TotalExpenses) }
                    });
                    //SeriesCollection[1].Values.Add(48);
                }


                Labels = new[] { "Sales", "Purchase", "Profit", "Loss" , "Expense" };
                Formatter = value => value.ToString("N");
                DataContext = this;
            }
            
        }

        //private void Refresh(object sender = null)
        //{
        //    myList.Clear();
        //    ResetPaging(myList);
        //    if (ddMonth.SelectedItem == null || ddYear.SelectedItem == null)
        //    {
        //        return;
        //    }
        //    using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
        //    {
        //        var StartDate = new DateTime(Convert.ToInt32(ddYear.Text), Convert.ToInt32(ddMonth.SelectedValue), 1);
        //        var EndDate = StartDate.AddYears(-1).AddMonths(1).AddDays(-1);
        //        // Sale 
        //        List<Common.DTO.Order> SaleOrders = new List<Common.DTO.Order>();
        //        if (ddPOS.SelectedValue == null || Convert.ToInt32(ddPOS.SelectedValue) == 0)
        //        {
        //            SaleOrders = DB.SaleOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate && x.OrderStatus != Common.OrderStatus.Deleted.ToString() && x.OrderStatus != Common.OrderStatus.Canceled.ToString()).ToList();
        //        }
        //        else
        //        {
        //            SaleOrders = DB.SaleOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate && x.OrderStatus != Common.OrderStatus.Deleted.ToString() && x.OrderStatus != Common.OrderStatus.Canceled.ToString() && x.POS == ddPOS.Text).ToList();
        //        }
        //        var CashSaleAmount = SaleOrders.Where(x => x.PaymentType == PaymentType.CASH && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
        //                           - SaleOrders.Where(x => x.PaymentType == PaymentType.CASH && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
        //        var CreditSaleAmount = SaleOrders.Where(x => x.PaymentType == PaymentType.CREDIT && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
        //                             - SaleOrders.Where(x => x.PaymentType == PaymentType.CREDIT && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
        //        var TotalSaleAmount = SaleOrders.Where(x => x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
        //                            - SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
        //        var TotalCostOfSale = SaleOrders.Where(x => x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Item.PurchasePrice * v.Qty) }).Sum(x => x.total)
        //                            - SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Item.PurchasePrice * v.Qty) }).Sum(x => x.total);

        //        //Profit Loss
        //        decimal? Profit = 0;
        //        decimal? Loss = 0;
        //        if (TotalSaleAmount >= TotalCostOfSale)
        //        {
        //            Profit = TotalSaleAmount - TotalCostOfSale;
        //        }
        //        else
        //        {
        //            Loss = TotalCostOfSale - TotalSaleAmount;
        //        }
        //        // Purchase
        //        var PurchaseOrders = DB.PurchaseOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate).ToList();
        //        var CashPurchaseAmount = PurchaseOrders.Where(x => x.PaymentType == PaymentType.CASH).Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
        //        var CreditPurchaseAmount = PurchaseOrders.Where(x => x.PaymentType == PaymentType.CREDIT).Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
        //        var TotalPurchaseAmount = PurchaseOrders.Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);

        //        //Salaries
        //        var Salaries = DB.AdvanceSalary.GetAll().Where(x => x.Date >= StartDate && x.Date <= EndDate);
        //        decimal? TotalSalary = 0;
        //        foreach (var item in Salaries)
        //        {
        //            TotalSalary += item.Amount;
        //        }

        //        //Expense
        //        var items = DB.expt.GetAll().Where(x => x.ExpenceDate >= StartDate && x.ExpenceDate <= EndDate).ToList();
        //        decimal? TotalExpenses = 0;
        //        foreach (var item in items)
        //        {
        //            TotalExpenses += item.Amount;
        //        }

        //        //Formation of list 
        //        myList.Add(new GeneralReportDTO { SerialNo = "1", Key = "Credit Sale", Value = CreditSaleAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        myList.Add(new GeneralReportDTO { SerialNo = "2", Key = "Cash Sale", Value = CashSaleAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        myList.Add(new GeneralReportDTO { SerialNo = "3", Key = "Total Sale", Value = TotalSaleAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        myList.Add(new GeneralReportDTO { SerialNo = "4", Key = "Credit Purchase", Value = CreditPurchaseAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        myList.Add(new GeneralReportDTO { SerialNo = "5", Key = "Cash Purchase", Value = CashPurchaseAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        myList.Add(new GeneralReportDTO { SerialNo = "6", Key = "Total Purchase", Value = TotalPurchaseAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        myList.Add(new GeneralReportDTO { SerialNo = "7", Key = "Profit", Value = Profit?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        myList.Add(new GeneralReportDTO { SerialNo = "8", Key = "Loss", Value = Loss?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        myList.Add(new GeneralReportDTO { SerialNo = "9", Key = "Total Salary", Value = TotalSalary?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        myList.Add(new GeneralReportDTO { SerialNo = "10", Key = "Expense", Value = TotalExpenses?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) });
        //        ResetPaging(myList);
        //    }

        //}




        //pie chart 
        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        //pie chart

        public void NegativeStackedRow()
        {
            SeriesCollection1 = new SeriesCollection
            {
                new StackedRowSeries
                {
                    Title = "Male",
                    Values = new ChartValues<double> {.5, .7, .8, .8, .6, .2, .6}
                },
                new StackedRowSeries
                {
                    Title = "Female",
                    Values = new ChartValues<double> {-.5, -.7, -.8, -.8, -.6, -.2, -.6}
                }
            };

            Labels1 = new[] { "0-20", "20-35", "35-45", "45-55", "55-65", "65-70", ">70" };
            Formatter1 = value => Math.Abs(value).ToString("P");

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollection1 { get; set; }
        public string[] Labels { get; set; }
        public string[] Labels1 { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Func<double, string> Formatter1 { get; set; }

    }
}
