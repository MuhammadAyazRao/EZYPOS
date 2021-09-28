using Common;
using Common.DTO;
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

namespace EZYPOS.View
{
    /// <summary>
    /// Interaction logic for CheckOutForm.xaml
    /// </summary>
    public partial class CheckOutForm : Window
    {
        Order Order { get; set; }
        PurchaseOrderDTO PurchaseOrder { get; set; }
        public string ScreenType { get; set; }
        public double CustPay { get; set; }
        public CheckOutForm(Order odr)
        {
            InitializeComponent();
            Order = odr;
            UCNum.OnButtonPressed += UCNum_OnButtonPressed;
            UCSide.onButtonPress += UCSide_onButtonPress;            
            lblTotal.Content = Order.GetNetTotal();
            lblDisc.Content = Order.GetTotalDiscount();
        }
        public CheckOutForm(PurchaseOrderDTO odr)
        {
            InitializeComponent();
            PurchaseOrder = odr;
            UCNum.OnButtonPressed += UCNum_OnButtonPressed;
            UCSide.onButtonPress += UCSide_onButtonPress;
            lblTotal.Content = Order.GetNetTotal();
            lblDisc.Content = Order.GetTotalDiscount();
        }
        private void UCSide_onButtonPress(object sender, EventArgs e)
        {
            UCNum.lblPin.Content = sender as string;
            UCNum.lblPin.Content = string.IsNullOrEmpty(UCNum.lblPin.Content.ToString()) || string.IsNullOrWhiteSpace(UCNum.lblPin.Content.ToString()) ? 0 : Convert.ToInt32(UCNum.lblPin.Content.ToString());
            UCNum.pin = sender as string;
            UCNum_OnButtonPressed(sender, e);
        }
        private void SetPaymentode()
        {
            if (Order != null)
            {
                if (PaymentVia.SelectedIndex == 0)
                {
                    Order.PaymentType = OrderEnums.PaymentType.CASH;
                }
                else if (PaymentVia.SelectedIndex == 1)
                {
                    Order.PaymentType = OrderEnums.PaymentType.CREDIT;
                }
            }

            if (PurchaseOrder != null)
            {
                if (PaymentVia.SelectedIndex == 0)
                {
                    PurchaseOrder.PaymentType = OrderEnums.PaymentType.CASH;
                }
                else if (PaymentVia.SelectedIndex == 1)
                {
                    PurchaseOrder.PaymentType = OrderEnums.PaymentType.CREDIT;
                }
            }
        }
        private void PaymentVia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetPaymentode();
        }
        private void UCNum_OnButtonPressed(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UCNum.pin))
            {
                CustPay = Convert.ToDouble(UCNum.pin);
                lblDue.Content = Order.GetNetTotal() - CustPay;
            }
            else
            {
                lblDue.Content = Order.GetNetTotal();
            }
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ScreenType == Common.ScreenType.Sale)
                {
                    if (CustPay < Order.GetNetTotal())
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Please Collect Payment", "Notification", "Ok");
                        return;
                    }
                    else
                    {
                        using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                        {

                            this.DialogResult = Db.SaleOrder.SaveOrder(Order);
                        }
                    }
                }
                else if (ScreenType == Common.ScreenType.Purchase)
                {
                    if (CustPay < PurchaseOrder.GetNetTotal())
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Please Collect Payment", "Notification", "Ok");
                        return;
                    }
                    else
                    {
                        using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                        {

                            this.DialogResult = Db.PurchaseOrder.SaveOrder(PurchaseOrder);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = false;
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }
    }
}
