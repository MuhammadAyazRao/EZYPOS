using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
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
    /// Interaction logic for WindowPurchaseOrderDetail.xaml
    /// </summary>
    public partial class WindowPurchaseOrderDetail : Window
    {
        public WindowPurchaseOrderDetail(PurchaseOrderReportDTO PurchaseOrder = null)
        {
            InitializeComponent();
            if (PurchaseOrder != null)
            {
                InitializePage(PurchaseOrder);
            }
        }

        private void InitializePage(PurchaseOrderReportDTO PurchaseOrder)
        {

            using (UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
            {
                List<PurchaseOrderDetailDTO> PurchaseOrderDetail = new List<PurchaseOrderDetailDTO>();
                var Items = Db.PurchaseOrderDetail.GetAll().Where(x => x.PurchaseOrderId == PurchaseOrder.id).ToList();
                string ItemName = "";
                decimal? OrderTotal = 0;
                foreach(var item in Items)
                {
                    ItemName = Db.Product.Get(item.ProductId).ProductName;
                    OrderTotal += item.Total;
                    PurchaseOrderDetail.Add(new PurchaseOrderDetailDTO { ItemName = ItemName, PurchasePrice = Convert.ToString(item.PurchasePrice), Qty = Convert.ToString(item.Qty), Total = Convert.ToString(item.Total) });
                }
                PurchaseOrderDetail.Add(new PurchaseOrderDetailDTO { ItemName = "-", PurchasePrice = "-", Qty = "Total", Total = Convert.ToString(OrderTotal) });
                SaleOrderDetailGrid.ItemsSource = PurchaseOrderDetail;
            }

        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
