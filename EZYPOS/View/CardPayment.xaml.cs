using Common;
using Common.DTO;
using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using Stripe;
using Stripe.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Common.OrderEnums;

namespace EZYPOS.View
{
    /// <summary>
    /// Interaction logic for CardPayment.xaml
    /// </summary>
    public partial class CardPayment : Window
    {
        Order Order { get; set; } // active order
        //public Epos.order ContextOrder { get; set; }
        public CardPayment()
        {
            InitializeComponent();
        }
        int Amount { get; set; }

        public CardPayment(decimal amount)
        {
            InitializeComponent();
            Amount = Convert.ToInt32(amount);

        }

        public CardPayment(decimal amount, Order Order1)
        {
            InitializeComponent();
            Amount = Convert.ToInt32(amount);
            Amount = Amount * 100;
            Order = Order1;

            Reader collectPayment = CollectPayment();
            txtStatus.Text = "Payment is :" + collectPayment.Action.Status.ToUpper() + ", Please Swipe your Card in terminal.";
        }
        public CardPayment(Order order)
        {
            InitializeComponent();
            Amount = Convert.ToInt32(order.GetNetTotal());
            Amount = Amount * 100;
            Order = order;

            Reader collectPayment = CollectPayment();
            txtStatus.Text = "Payment is :" + collectPayment.Action.Status.ToUpper() + ", Please Swipe the Card";
        }
        #region Stripe Terminal Work
        public Reader GetReaderState()
        {
            StripeConfiguration.ApiKey = "sk_test_pcw8sFas7RNEdD2x2ddMur7X";

            var service = new ReaderService();
            return service.Get("tmr_E97ghAprrQsrhV");
        }
        public PaymentIntent CreatePaymentIntent()
        {
            StripeConfiguration.ApiKey = "sk_test_pcw8sFas7RNEdD2x2ddMur7X";
            var options = new PaymentIntentCreateOptions
            {
                Currency = "gbp",
                PaymentMethodTypes = new List<string> { "card_present" },
                CaptureMethod = "manual",
                Amount = Amount,
            };
            var service = new PaymentIntentService();
            return service.Create(options);
        }
        public Reader CollectPayment()
        {

            StripeConfiguration.ApiKey = "sk_test_pcw8sFas7RNEdD2x2ddMur7X";
            string paymentIntentId = CreatePaymentIntent().Id;
            var options = new ReaderProcessPaymentIntentOptions { PaymentIntent = paymentIntentId };
            var service = new ReaderService();
            return service.ProcessPaymentIntent("tmr_E97ghAprrQsrhV", options);
        }
        public Reader SimulatePayment()
        {
            StripeConfiguration.ApiKey = "sk_test_pcw8sFas7RNEdD2x2ddMur7X";

            var service = new Stripe.TestHelpers.Terminal.ReaderService();
            return service.PresentPaymentMethod("tmr_E97ghAprrQsrhV");
        }
        #endregion

        private void btnProceedClick(object sender, RoutedEventArgs e)
        {
            Reader simulatePayment = SimulatePayment();
            if (simulatePayment.Action.Status != "succeeded")
            {
                txtStatus.Text = "Payment is :" + simulatePayment.Action.Status.ToUpper() + ", There may be some problem, Please Ask the Customer to Swipe the Card Again";
            }
            else
            {
                using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    string WalkingCustomer = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.WalkingCustomer).FirstOrDefault().AppValue;
                    Order.CustId = Convert.ToInt32(WalkingCustomer);
                    Order.OrderDate = DateTime.Today;
                    Order.PaymentType = Common.OrderEnums.PaymentType.CARD;
                    var Taxobj = Tax_Taxpercentage();
                    Order.Tax = Taxobj.Tax;
                    Order.TaxPercentage = Taxobj.Percentage;
                    Order.OrderStatus = Common.OrderStatus.New.ToString();
                    this.DialogResult = Db.SaleOrder.SaveOrder(Order);
                    //DialogResult = true;
                    //ActiveSession.MerchantResponce = simulatePayment.ToString();
                    //ActiveSession.MerchantRefundResponce = simulatePayment.Action.ProcessPaymentIntent.PaymentIntentId;
                    Close();
                }
            }
        }

        private void btnbillCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
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


    }
}
