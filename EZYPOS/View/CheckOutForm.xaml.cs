using Common;
using Common.DTO;
using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using System;
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
        public decimal? RewardPoints { get; set; }
        public decimal rewardPointsDiscount { get; set; }
        public void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                // DDShop.ItemsSource = Db.Shop.GetAll().ToList().Select(x => new { Name = x.Name, Id = x.Id }).ToList(); 
                TransactionDate.SelectedDate = DateTime.Today;

                if (ScreenType == Common.ScreenType.Sale)
                {
                    DDCustomer.ItemsSource = Db.Customers.GetAll().OrderBy(x => x.Name).ToList().Select(x => new { Name = x.Name, PhoneNumber = x.PhoneNo, Id = x.Id }).ToList();
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
            SetLabels();
        }
        public void SetLabels()
        {
            var Taxobj = Tax_Taxpercentage();
            lblTotal.Content = Order.GetNetTotal() + Taxobj.Tax;
            lblDisc.Content = Order.GetTotalDiscount();
            lblDelivery.Content = Order.DeliverCharges;
            lblRewardPoints.Content = Order.GetTotalRewardPoints();
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
        private TaxDTO Tax_Taxpercentage() 
        {
            TaxDTO taxDTO = new TaxDTO();   
            decimal Tax = 0;
            decimal TaxPercentage = 0;
            var AllowTax = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.AllowTax).FirstOrDefault().AppValue;
            if (AllowTax.ToLower() == "true")
            {
                var ItemBaseTax = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.ItemBaseTax).FirstOrDefault().AppValue;
                if (ItemBaseTax.ToLower() != "true")
                {
                    var MinimumTaxLimit = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.MinimumTaxLimit).FirstOrDefault().AppValue;
                    decimal Total = Order.GetNetTotal();
                    if (Total >= Convert.ToInt32(MinimumTaxLimit))
                    {
                        TaxPercentage = Convert.ToDecimal(((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.TaxPercentage).FirstOrDefault().AppValue);
                        Tax = TaxPercentage / 100 * Total;
                    }
                }
                else
                {
                    foreach (var item in Order?.OrdersDetails)
                    {
                        Tax += item.Item.Tax * item.Qty;
                    }
                }

            }
            taxDTO.Percentage = TaxPercentage;
            taxDTO.Tax = Tax;
            return taxDTO;

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
                        var Taxobj = Tax_Taxpercentage();
                        Order.Tax = Taxobj.Tax;
                        Order.TaxPercentage = Taxobj.Percentage;
                        Order.OrderStatus = OrderStatus.New.ToString();
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
            if(Order.RewardRedeemed == true)
            {
                Order.Discount = Order.Discount - rewardPointsDiscount;
                SetLabels();
                Order.RewardRedeemed = false;
            }
            this.DialogResult = false;
            this.Close();

        }

        private void DDCustomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                string searchText = DDCustomer.Text + e.Text.ToLower();

                // Get the original list of customers
                var customerList = Db.Customers.GetAll()
                    .OrderBy(x => x.Name)
                    .ToList();

                // Apply the filter based on the search text
                var filteredList = customerList
                    .Where(x => x.Name.ToLower().Contains(searchText) || x.PhoneNo.Contains(searchText))
                    .Select(x => new { Name = x.Name, Id = x.Id })
                    .ToList();

                // Update the ComboBox items source
                DDCustomer.ItemsSource = filteredList;
            }
        }

        private void DDCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string WalkingCustomer = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.WalkingCustomer).FirstOrDefault().AppValue;
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var selectedCustomer = Db.Customers.Get(Convert.ToInt32(DDCustomer.SelectedValue));
                if(Convert.ToInt32(WalkingCustomer) == selectedCustomer.Id)
                {
                    lblTotalRewardPoints.Content = "";
                    btnRedeem.Visibility = Visibility.Collapsed;
                }
                else
                {
                    RewardPoints = selectedCustomer.RewardPoints + Convert.ToDecimal(Order.GetTotalRewardPoints());
                    if (selectedCustomer != null)
                    {
                        if (RewardPoints > 0)
                        {
                            btnRedeem.Visibility = Visibility.Visible;
                            lblTotalRewardPoints.Content = "Selected Customer's Total Reward Points Are " + RewardPoints.ToString();
                        }
                        else
                        {
                            btnRedeem.Visibility = Visibility.Collapsed;
                            lblTotalRewardPoints.Content = "Selected Customer's Total Reward Points Are " + RewardPoints.ToString();
                        }
                    }
                }
            }
        }

        private void btnRedeem_Click(object sender, RoutedEventArgs e)
        {
            string rewardPointsValue = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.RewardPointsValue).FirstOrDefault().AppValue;
            rewardPointsDiscount = Convert.ToDecimal(RewardPoints / Convert.ToDecimal(rewardPointsValue));
            var status = EZYPOS.View.MessageYesNo.ShowCustom("confirmation", "Total Discount will be "+ rewardPointsDiscount.ToString("C", CultureInfo.CreateSpecificCulture(HelperMethods.GetCurrency())) +"", "Proceed", "No");
            if (status)
            {
                Order.Discount = Order.Discount + rewardPointsDiscount;
                SetLabels();
                Order.RewardRedeemed = true;
                lblTotalRewardPoints.Content = "Reward Points Are Redeemed !";
                btnRedeem.Visibility = Visibility.Collapsed;
            }
            
        }
    }
}
