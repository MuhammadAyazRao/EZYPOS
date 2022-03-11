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
    /// Interaction logic for WindowSaleOrderDetail.xaml
    /// </summary>
    public partial class WindowSaleOrderDetail : Window
    {
        

        public WindowSaleOrderDetail(SaleOrderDTO SaleOrder = null)
        {
            InitializeComponent();
            if (SaleOrder != null)
            {
                InitializePage(SaleOrder);
            }
        }

        private void InitializePage(SaleOrderDTO SaleOrder)
        {

            using (UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
            {
                //Note PurchaseOrderDetailDTO is used in both SaleOrderDetail and PurchaseOrderDetail

                List<PurchaseOrderDetailDTO> SaleOrderDetail = new List<PurchaseOrderDetailDTO>();
                var Items = Db.SaleOrderDetail.GetAll().Where(x => x.OrderId == SaleOrder.id).ToList();
                string ItemName = "";
                decimal? ItemTotal = 0;
                decimal? OrderTotal = 0;
                foreach (var item in Items)
                {
                    ItemName = Db.Product.Get(item.ItemId).ProductName;
                    ItemTotal = item.ItemQty * item.ItemPrice;
                    OrderTotal += ItemTotal;
                    SaleOrderDetail.Add(new PurchaseOrderDetailDTO { ItemName = ItemName, PurchasePrice = Convert.ToString(item.ItemPrice), Qty = Convert.ToString(item.ItemQty), Total = Convert.ToString(ItemTotal) });
                }
                SaleOrderDetail.Add(new PurchaseOrderDetailDTO { ItemName = "-", PurchasePrice = "-", Qty = "Total", Total = Convert.ToString(OrderTotal) });
                SaleOrderDetailGrid.ItemsSource = SaleOrderDetail;

                
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
