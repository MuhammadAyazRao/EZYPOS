using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common;
using Common.Session;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.UserControls.Misc;
using EZYPOS.UserControls.Transaction;
using LiveCharts;
using LiveCharts.Wpf;
using static Common.OrderEnums;

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

            //DataContext = this;
            //pie chart
            BarChart();
            NegativeStackedRow();
            PieChart();
            Refresh();
            //listKitchenLineItems.ItemsSource = GetProducts();
        }
        

        private void Refresh(object sender = null)
        {
            List<GeneralReportDTO> myList = new List<GeneralReportDTO>();
            myList.Clear();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                var EndDate = DateTime.Today;
                // Sale 
                List<Common.DTO.Order> SaleOrders = new List<Common.DTO.Order>();
                SaleOrders = DB.SaleOrder.GetMappedOrder().Where(x => x.OrderDate >= StartDate && x.OrderDate <= EndDate && x.OrderStatus != Common.OrderStatus.Deleted.ToString() && x.OrderStatus != Common.OrderStatus.Canceled.ToString()).ToList();

                var CashSaleAmount = SaleOrders.Where(x => x.PaymentType == PaymentType.CASH && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                                   - SaleOrders.Where(x => x.PaymentType == PaymentType.CASH && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var CreditSaleAmount = SaleOrders.Where(x => x.PaymentType == PaymentType.CREDIT && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                                     - SaleOrders.Where(x => x.PaymentType == PaymentType.CREDIT && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
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
                var CashPurchaseAmount = PurchaseOrders.Where(x => x.PaymentType == PaymentType.CASH).Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var CreditPurchaseAmount = PurchaseOrders.Where(x => x.PaymentType == PaymentType.CREDIT).Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var TotalPurchaseAmount = PurchaseOrders.Select(x => new { total = x.OrdersDetails.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);

                //Salaries
                var Salaries = DB.AdvanceSalary.GetAll().Where(x => x.Date >= StartDate && x.Date <= EndDate);
                decimal? TotalSalary = 0;
                foreach (var item in Salaries)
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
                myList.Add(new GeneralReportDTO { SerialNo = "1", Key = "Credit Sale", Value = CreditSaleAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#27AE60")) });
                myList.Add(new GeneralReportDTO { SerialNo = "2", Key = "Cash Sale", Value = CashSaleAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E8449")) });
                myList.Add(new GeneralReportDTO { SerialNo = "3", Key = "Total Sale", Value = TotalSaleAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#145A32")) });
                myList.Add(new GeneralReportDTO { SerialNo = "7", Key = "Profit", Value = Profit?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4A235A")) });
                myList.Add(new GeneralReportDTO { SerialNo = "8", Key = "Loss", Value = Loss?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1B4F72")) });
                myList.Add(new GeneralReportDTO { SerialNo = "4", Key = "Credit Purchase", Value = CreditPurchaseAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0392B")) });
                myList.Add(new GeneralReportDTO { SerialNo = "5", Key = "Cash Purchase", Value = CashPurchaseAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#922B21")) });
                myList.Add(new GeneralReportDTO { SerialNo = "6", Key = "Total Purchase", Value = TotalPurchaseAmount?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#641E16")) });
                myList.Add(new GeneralReportDTO { SerialNo = "9", Key = "Total Salary", Value = TotalSalary?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#839192")) });
                myList.Add(new GeneralReportDTO { SerialNo = "10", Key = "Expense", Value = TotalExpenses?.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())), coloroftile = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A2D9CE")) });
                listKitchenLineItems.ItemsSource = myList;
            }

        }
        public List<ProductDTO> GetProducts(int SubCategoryId = 0)
        {
            List<ProductDTO> Products = new List<ProductDTO>();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                Products = Db.Product.GetAll().Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = X.Size.ToString(), Unit = X.UnitNavigation.Name, RetailPrice = X.RetailPrice, PurchasePrice = X.PurchasePrice, Tax = X.Tax, TaxType = X.TaxType }).ToList();
            }
            return Products;
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
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                //Formation of Dates
                var ThisStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var ThisEndDate = ThisStartDate.AddMonths(1).AddDays(-1);
                //Previous1
                var P1StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
                var P1EndDate = P1StartDate.AddMonths(1).AddDays(-1);
                //Previous2
                var P2StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-2);
                var P2EndDate = P2StartDate.AddMonths(1).AddDays(-1);
                //Previous3
                var P3StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-3);
                var P3EndDate = P3StartDate.AddMonths(1).AddDays(-1);
                //Previous4
                var P4StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-4);
                var P4EndDate = P4StartDate.AddMonths(1).AddDays(-1);
                //Previous5
                var P5StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-5);
                var P5EndDate = P5StartDate.AddMonths(1).AddDays(-1);
                //End Formation of Dates

                //Start Credit and Sale Calculations
                var SaleOrders = DB.SaleOrder.GetMappedOrder().Where(x => x.OrderStatus != Common.OrderStatus.Deleted.ToString() && x.OrderStatus != Common.OrderStatus.Canceled.ToString()).ToList();
                var ThisCash = SaleOrders.Where(x => x.OrderDate >= ThisStartDate && x.OrderDate <= ThisEndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                             - SaleOrders.Where(x => x.OrderDate >= ThisStartDate && x.OrderDate <= ThisEndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var ThisCredit = SaleOrders.Where(x => x.OrderDate >= ThisStartDate && x.OrderDate <= ThisEndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                               - SaleOrders.Where(x => x.OrderDate >= ThisStartDate && x.OrderDate <= ThisEndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                //Previous1
                var P1Cash = SaleOrders.Where(x => x.OrderDate >= P1StartDate && x.OrderDate <= P1EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                           - SaleOrders.Where(x => x.OrderDate >= P1StartDate && x.OrderDate <= P1EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var P1Credit = SaleOrders.Where(x => x.OrderDate >= P1StartDate && x.OrderDate <= P1EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                             - SaleOrders.Where(x => x.OrderDate >= P1StartDate && x.OrderDate <= P1EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                //Previous2
                var P2Cash = SaleOrders.Where(x => x.OrderDate >= P2StartDate && x.OrderDate <= P2EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                           - SaleOrders.Where(x => x.OrderDate >= P2StartDate && x.OrderDate <= P2EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var P2Credit = SaleOrders.Where(x => x.OrderDate >= P2StartDate && x.OrderDate <= P2EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                             - SaleOrders.Where(x => x.OrderDate >= P2StartDate && x.OrderDate <= P2EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                //Previous3
                var P3Cash = SaleOrders.Where(x => x.OrderDate >= P3StartDate && x.OrderDate <= P3EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                           - SaleOrders.Where(x => x.OrderDate >= P3StartDate && x.OrderDate <= P3EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var P3Credit = SaleOrders.Where(x => x.OrderDate >= P3StartDate && x.OrderDate <= P3EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                             - SaleOrders.Where(x => x.OrderDate >= P3StartDate && x.OrderDate <= P3EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                //Previous4
                var P4Cash = SaleOrders.Where(x => x.OrderDate >= P4StartDate && x.OrderDate <= P4EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                           - SaleOrders.Where(x => x.OrderDate >= P4StartDate && x.OrderDate <= P4EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var P4Credit = SaleOrders.Where(x => x.OrderDate >= P4StartDate && x.OrderDate <= P4EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                             - SaleOrders.Where(x => x.OrderDate >= P4StartDate && x.OrderDate <= P4EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                //Previous5
                var P5Cash = SaleOrders.Where(x => x.OrderDate >= P5StartDate && x.OrderDate <= P5EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                           - SaleOrders.Where(x => x.OrderDate >= P5StartDate && x.OrderDate <= P5EndDate && x.PaymentType == PaymentType.CASH && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);
                var P5Credit = SaleOrders.Where(x => x.OrderDate >= P5StartDate && x.OrderDate <= P5EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus != Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total)
                             - SaleOrders.Where(x => x.OrderDate >= P5StartDate && x.OrderDate <= P5EndDate && x.PaymentType == PaymentType.CREDIT && x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Select(x => new { total = x.OrdersDetails?.Sum(v => v.Qty * v.Item?.price) }).Sum(x => x.total);

                SeriesCollection1 = new SeriesCollection
                {
                    new StackedRowSeries
                    {
                        Title = "Cash",
                        Values = new ChartValues<decimal> {Convert.ToDecimal(P5Cash), Convert.ToDecimal(P4Cash), Convert.ToDecimal(P3Cash), Convert.ToDecimal(P2Cash), Convert.ToDecimal(P1Cash), Convert.ToDecimal(ThisCash) }
                    },
                    new StackedRowSeries
                    {
                        Title = "Credit",
                        Values = new ChartValues<decimal> {Convert.ToDecimal(P5Credit), Convert.ToDecimal(P4Credit), Convert.ToDecimal(P3Credit), Convert.ToDecimal(P2Credit), Convert.ToDecimal(P1Credit), Convert.ToDecimal(ThisCredit), }
                    }
                };
                    string thismonth = DateTime.Now.ToString("MMMM");
                    string previous1 = DateTime.Now.AddMonths(-1).ToString("MMMM");
                    string previous2 = DateTime.Now.AddMonths(-2).ToString("MMMM");
                    string previous3 = DateTime.Now.AddMonths(-3).ToString("MMMM");
                    string previous4 = DateTime.Now.AddMonths(-4).ToString("MMMM");
                    string previous5 = DateTime.Now.AddMonths(-5).ToString("MMMM");
                    Labels1 = new[] { previous5, previous4, previous3, previous2, previous1, thismonth };
                    Formatter1 = value => Math.Abs(value).ToString("P");
                    //Formatter1 = value => value.ToString("N");

                    //DataContext = this;
            }

        }
        public void PieChart()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var SaleOrders = Db.SaleOrder.GetAll().ToList();
                int New = SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.New.ToString()).Count();
                int Refunded = SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Refunded.ToString()).Count();
                int Deleted = SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Deleted.ToString()).Count();
                int Canceled = SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Canceled.ToString()).Count();
                int Edited = SaleOrders.Where(x => x.OrderStatus == Common.OrderStatus.Edited.ToString()).Count();
                LiveCharts.SeriesCollection psc = new LiveCharts.SeriesCollection
                {
                    new LiveCharts.Wpf.PieSeries
                    {
                        Values = new LiveCharts.ChartValues<int> {New},
                        Title = "New",
                        DataLabels=true,
                        LabelPoint=PointLabel,
                    },
                    new LiveCharts.Wpf.PieSeries
                    {
                        Values = new LiveCharts.ChartValues<int> {Deleted},
                        Title = "Deleted",
                        DataLabels=true,
                        LabelPoint=PointLabel,
                    },
                    new LiveCharts.Wpf.PieSeries
                    {
                        Values = new LiveCharts.ChartValues<int> {Refunded},
                        Title = "Refunded",
                        DataLabels=true,
                        LabelPoint=PointLabel,
                    },
                    new LiveCharts.Wpf.PieSeries
                    {
                        Values = new LiveCharts.ChartValues<int> {Canceled},
                        Title = "Canceled",
                        DataLabels=true,
                        LabelPoint=PointLabel,
                    },
                    new LiveCharts.Wpf.PieSeries
                    {
                        Values = new LiveCharts.ChartValues<int> {Edited},
                        Title = "Edited",
                        DataLabels=true,
                        LabelPoint=PointLabel,
                    },
                };
                foreach (LiveCharts.Wpf.PieSeries ps in psc)
                {
                    myPieChart.Series.Add(ps);
                }
            }
        }
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollection1 { get; set; }
        public string[] Labels { get; set; }
        public string[] Labels1 { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Func<double, string> Formatter1 { get; set; }


        private void SaleOrder_Click(object sender, RoutedEventArgs e)
        {
            UserControlSaleTransaction SaleItem = new UserControlSaleTransaction();
            ActiveSession.DisplayuserControlMethod(SaleItem);
        }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            UserControlPurchaseTransaction PurchaseItem = new UserControlPurchaseTransaction();
            ActiveSession.DisplayuserControlMethod(PurchaseItem);
        }

        private void ViewSaleOrder_Click(object sender, RoutedEventArgs e)
        {
            UserControlViewOrder OrderScreen = new UserControlViewOrder();
            ActiveSession.DisplayuserControlMethod(OrderScreen);
        }

        private void ViewPurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            UserControlPurchaseOrder PurchaseOrder = new UserControlPurchaseOrder();
            ActiveSession.DisplayuserControlMethod(PurchaseOrder);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            UserControlSettings Settings = new UserControlSettings();
            ActiveSession.DisplayuserControlMethod(Settings);
        }
    }
}
