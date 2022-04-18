using Common.DTO;
using Common.Session;
using DAL.Repository;
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
using System.Windows.Shapes;

namespace EZYPOS.UserControls.Report
{
    /// <summary>
    /// Interaction logic for WindowExpiryInformationAlert.xaml
    /// </summary>
    public partial class WindowExpiryInformationAlert : Window
    {
        List<StockDetailDTO> myList = new List<StockDetailDTO>();

        public WindowExpiryInformationAlert()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {
            myList.Clear();
            var StartDate = DateTime.Today;
            int ExpiryAlertMonths = Convert.ToInt32(((List<DAL.DBMODEL.Setting>)ActiveSession.Setting).Where(x => x.AppKey == Common.SettingKey.ExpiryAlertMonths).FirstOrDefault().AppValue);
            var MidDate = StartDate.AddMonths(Convert.ToInt32(ExpiryAlertMonths));
            var EndDate = new DateTime(MidDate.Year, MidDate.Month, DateTime.DaysInMonth(MidDate.Year, MidDate.Month));
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var products = DB.Product.GetAll().ToList();
                foreach (var product in products)
                {
                    var stockDetail = DB.Stock.GetStockDetail().Where(x => x.ProductId == product.Id && x.ExpirationDate >= StartDate && x.ExpirationDate <= EndDate).ToList();
                    foreach (var item in stockDetail)
                    {
                        myList.Add(new StockDetailDTO { ProductName = item.ProductName, AvailableQty = item.AvailableQty, StartDate = item.StartDate, ExpirationDate = item.ExpirationDate });
                    }
                }
                ExpiryAlertGrid.ItemsSource = myList;
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.ProductName, COLB = x.AvailableQty.ToString(), COLC = x.StartDate.ToString("dd/MM/yyyy"), COLD = x.ExpirationDate.ToString("dd/MM/yyyy"), COLE = "", COLF = "" }).ToList();
            int ExpiryAlertMonths = Convert.ToInt32(((List<DAL.DBMODEL.Setting>)ActiveSession.Setting).Where(x => x.AppKey == Common.SettingKey.ExpiryAlertMonths).FirstOrDefault().AppValue);
            string Discription = "Stock Expiring Within Next " + ExpiryAlertMonths + " Months:"; //"From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL4Report(ref ReportViewer, "Expiry Information Alert", "Product Name", "Available Quantity", "Start Date", "Expiry Date", Discription, RptData);
        }
    }
}
