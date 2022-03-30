using Common;
using Common.DTO;
using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
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
        public decimal CustPay { get; set; }
        public void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                // DDShop.ItemsSource = Db.Shop.GetAll().ToList().Select(x => new { Name = x.Name, Id = x.Id }).ToList(); 
                TransactionDate.SelectedDate = DateTime.Today;

                if (ScreenType == Common.ScreenType.Sale)
                {
                    DDCustomer.ItemsSource = Db.Customers.GetAll().OrderBy(x => x.Name).ToList().Select(x => new { Name = x.Name, Id = x.Id }).ToList();
                    //DDEmployee.ItemsSource = Db.Employee.GetAll().OrderBy(x => x.UserName).ToList().Select(x => new { Name = x.UserName, Id = x.Id }).ToList();
                    DDCustomer.Visibility = Visibility.Visible;
                    DDSupplier.Visibility = Visibility.Collapsed;
                    //txtDeliveryCharge.Visibility = Visibility.Visible;
                }
                else if (ScreenType == Common.ScreenType.Purchase)
                {
                    DDSupplier.ItemsSource = Db.Supplier.GetAll().ToList().Select(x => new { Name = x.Name, Id = x.Id }).ToList();
                    //DDEmployee.ItemsSource = Db.Employee.GetAll().OrderBy(x => x.UserName).ToList().Select(x => new { Name = x.UserName, Id = x.Id }).ToList();
                    DDSupplier.Visibility = Visibility.Visible;
                    DDCustomer.Visibility = Visibility.Collapsed;
                    //txtDeliveryCharge.Visibility = Visibility.Collapsed;
                }
                string WalkingCustomer = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.WalkingCustomer).FirstOrDefault().AppValue;
                string DefaultSupplier = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.DefaultSupplier).FirstOrDefault().AppValue;
                DDCustomer.SelectedValue = Convert.ToInt32(WalkingCustomer);
                DDSupplier.SelectedValue = Convert.ToInt32(DefaultSupplier);
            }
        }
        public CheckOutForm(Order odr)
        {
            InitializeComponent();
            this.Language = System.Windows.Markup.XmlLanguage.GetLanguage(HelperMethods.GetCurrency());
            Order = odr;
            UCNum.OnButtonPressed += UCNum_OnButtonPressed;
            UCSide.onButtonPress += UCSide_onButtonPress;            
            lblTotal.Content = Order.GetNetTotal();
            lblDisc.Content = Order.GetTotalDiscount();
            lblDelivery.Content = Order.DeliverCharges;
        }
        public CheckOutForm(PurchaseOrderDTO odr)
        {
            InitializeComponent();
            this.Language = System.Windows.Markup.XmlLanguage.GetLanguage(HelperMethods.GetCurrency());
            PurchaseOrder = odr;
            UCNum.OnButtonPressed += UCNum_OnButtonPressed;
            UCSide.onButtonPress += UCSide_onButtonPress;
            lblTotal.Content = PurchaseOrder.GetNetTotal();
            lblDisc.Content = PurchaseOrder.GetTotalDiscount();
            lblDelivery.Content = PurchaseOrder.DeliverCharges;
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
            if (ScreenType == Common.ScreenType.Sale)
            {
                if (!string.IsNullOrEmpty(UCNum.pin))
                {
                    CustPay = Convert.ToDecimal(UCNum.pin);
                    lblDue.Content = Order.GetNetTotal() - CustPay;
                }
                else
                {
                    lblDue.Content = Order.GetNetTotal();
                }
            }
            else if (ScreenType == Common.ScreenType.Purchase)
            {
                if (!string.IsNullOrEmpty(UCNum.pin))
                {
                    CustPay = Convert.ToDecimal(UCNum.pin);
                    lblDue.Content = PurchaseOrder.GetNetTotal() - CustPay;
                }
                else
                {
                    lblDue.Content = PurchaseOrder.GetNetTotal();
                }
            }
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ScreenType == Common.ScreenType.Sale)
                {
                    //if (DDCustomer.SelectedValue == null || DDEmployee.SelectedValue == null)
                    //{
                    //    EZYPOS.View.MessageBox.ShowCustom("Please Select Customer & Employee", "Error", "Ok");
                    //    return;
                    //}



                    //if (CustPay < Order.GetNetTotal())
                    //{
                    //    EZYPOS.View.MessageBox.ShowCustom("Please Collect Payment", "Notification", "Ok");
                    //    return;
                    //}
                    //else
                    //{
                        using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                        {
                            if (DDCustomer.SelectedValue != null)
                            {
                                Order.CustId = Convert.ToInt32(DDCustomer.SelectedValue);
                                Order.OrderDate = Convert.ToDateTime(TransactionDate.SelectedDate);
                            }

                            //if (DDEmployee.SelectedValue != null)
                            //{
                            //    Order.EmployeeId = Convert.ToInt32(DDEmployee.SelectedValue);

                            //}
                            this.DialogResult = Db.SaleOrder.SaveOrder(Order);
                        }
                    //}
                }
                else if (ScreenType == Common.ScreenType.Purchase)
                {
                    //if (DDSupplier.SelectedValue == null || DDEmployee.SelectedValue == null)
                    //{
                    //    EZYPOS.View.MessageBox.ShowCustom("Please Select Supplier & Employee", "Error", "Ok");
                    //    return;
                    //}



                    //if (CustPay < PurchaseOrder.GetNetTotal())
                    //{
                    //    EZYPOS.View.MessageBox.ShowCustom("Please Collect Payment", "Notification", "Ok");
                    //    return;
                    //}
                    //else
                    //{
                        using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                        {
                            if (DDSupplier.SelectedValue != null)
                            {
                                PurchaseOrder.SupplierId = Convert.ToInt32(DDSupplier.SelectedValue);
                                PurchaseOrder.OrderDate = Convert.ToDateTime(TransactionDate.SelectedDate);
                            }

                            //if (DDEmployee.SelectedValue != null)
                            //{
                            //    PurchaseOrder.EmployeeId = Convert.ToInt32(DDEmployee.SelectedValue);

                            //}
                            this.DialogResult = Db.PurchaseOrder.SaveOrder(PurchaseOrder);
                        }
                    //}
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
