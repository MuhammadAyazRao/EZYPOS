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
using Common.DTO;
using Common.Session;
using DAL.Repository;
using EZYPOS.View;
using System.Text.RegularExpressions;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EZYPOS.UserControls.Transaction
{
   
    /// <summary>
    /// Interaction logic for UserControlPurchaseOrder.xaml
    /// </summary>
    public partial class UserControlPurchaseOrder : UserControl
    {
        public event ItemResumeHandler OnItemResume;
        public event ItemResumeHandler OnItemSelected;
        public UserControlPurchaseOrder()
        {
            InitializeComponent();
            this.Language = System.Windows.Markup.XmlLanguage.GetLanguage(HelperMethods.GetCurrency());
            Refresh();
        }

        void Refresh()
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                ddSupplier.ItemsSource = DB.Supplier.GetAll().ToList();
                ddSupplier.SelectedValue = null;
                ddPaymentStatus.SelectedValue = null;
                ddPaymentMode.SelectedValue = null;
                txtOrderNum.Text = "";
                listOrderAccepted.Items.Clear();
                foreach (var item in DB.PurchaseOrder.GetMappedOrder())
                {
                    listOrderAccepted.Items.Add(new PurchaseOrderDTO { OrderId = item.OrderId, payment_status = item.payment_status, diverlyType = item.PaymentType, OrderCount = item.GetNetTotal(), OrderDate = item.OrderDate }); ;

                }
            }
        }
        //private void btnResume_Click(object sender, RoutedEventArgs e)
        //{
        //    OnItemResume?.Invoke(listOrderHold.SelectedItem, null);
        //}

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            switch (tb.Text)
            {
               
                case "Order No":
                    tb.Text = "";
                    tb.Foreground = Brushes.Black;
                    break;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            switch (tb.Name)
            {
                
                case "txtOrderNum":
                    if (txtOrderNum.Text == "")
                    {
                        tb.Text = "Order No";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
            }
        }

        private void txtPhone_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void listOrderAccepted_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listOrderAccepted.SelectedItem != null)
                OnItemSelected?.Invoke(listOrderAccepted.SelectedItem, null);
        }

        private void txtOrderNum_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewOrder_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)listOrderAccepted.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);
            PurchaseOrderDTO Order = selectedItem.Content as PurchaseOrderDTO;
            if (Order != null)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {

                    Order = DB.PurchaseOrder.GetMappedOrder(Order.OrderId).FirstOrDefault();
                }
                if (Order.OrdersDetails != null)
                {
                    CartSummary OrderSummary = new CartSummary();
                    OrderSummary.InvoiceUC.SetFlowDoc(Invoice.GetFlowDocuments(Order));
                    OrderSummary.ShowDialog();
                }
                else
                {
                    EZYPOS.View.MessageBox.ShowCustom("Order is Empty", "Empty Order", "Ok");
                }
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)listOrderAccepted.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);
            PurchaseOrderDTO Order = selectedItem.Content as PurchaseOrderDTO;
            if (Order != null)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {

                    Order = DB.PurchaseOrder.GetMappedOrder(Order.OrderId).FirstOrDefault();
                }
                if (Order.OrdersDetails != null)
                {
                    Invoice inv = new Invoice();
                    inv.DoPrintJob(Order);
                }
                else
                {
                    EZYPOS.View.MessageBox.ShowCustom("Order is Empty", "Empty Order", "Ok");
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)listOrderAccepted.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);
            PurchaseOrderDTO Order = selectedItem.Content as PurchaseOrderDTO;
            if (Order != null)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {

                    Order = DB.PurchaseOrder.GetMappedOrder(Order.OrderId).FirstOrDefault();
                }
                if (Order.OrdersDetails != null)
                {

                    ActiveSession.CloseDisplayuserControlMethod(new UserControlPurchaseTransaction(Order));
                }
                else
                {
                    EZYPOS.View.MessageBox.ShowCustom("Order is Empty", "Empty Order", "Ok");
                }
            }
            Refresh();


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)listOrderAccepted.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);
            PurchaseOrderDTO Order = selectedItem.Content as PurchaseOrderDTO;
            if (Order != null)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (DB.PurchaseOrder.DeleteOrder(Order.OrderId))
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Order Deleted Sucessfully", "Deleted Order", "Ok");
                        Refresh();
                    }
                    else
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Can not delete.", "failed detetion", "Ok");
                    }
                }
            }

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                
                int SelectedSupplier = 0;
                if (ddSupplier.SelectedValue != null)
                {
                    SelectedSupplier = Convert.ToInt32(ddSupplier.SelectedValue);
                }
                string SelectedPaymentStatus = "";
                if (ddPaymentStatus.SelectedValue != null)
                {
                    SelectedPaymentStatus = Convert.ToString(ddPaymentStatus.Text);
                    SelectedPaymentStatus = SelectedPaymentStatus.ToUpper();
                }

                string SelectedPaymentMode = "";
                if (ddPaymentMode.SelectedValue != null)
                {
                    SelectedPaymentMode = Convert.ToString(ddPaymentMode.Text);
                    SelectedPaymentMode = SelectedPaymentMode.ToUpper();
                }
                listOrderAccepted.Items.Clear();
                List<PurchaseOrderDTO> Allorders = DB.PurchaseOrder.GetMappedOrder();
                if (StartDate.SelectedDate != null && EndDate.SelectedDate != null)
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                    Allorders = Allorders.Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                }
                if (SelectedSupplier != 0)
                {
                    Allorders = Allorders.Where(x => x.SupplierId == SelectedSupplier).ToList();
                }
                if (SelectedPaymentStatus != "ALL" && SelectedPaymentStatus != "")
                {
                    Allorders = Allorders.Where(x => x.payment_status.ToUpper() == SelectedPaymentStatus).ToList();
                }
                if (SelectedPaymentMode != "ALL" && SelectedPaymentMode != "")
                {
                    Allorders = Allorders.Where(x => x.PaymentType == SelectedPaymentMode).ToList();
                }

                if (txtOrderNum.Text != "" && txtOrderNum.Text != "Order No")
                {
                    int ordernum = Convert.ToInt32(txtOrderNum.Text);
                    Allorders = Allorders.Where(x => x.OrderId == ordernum).ToList();
                }

                foreach (var item in Allorders)
                {
                    listOrderAccepted.Items.Add(new PurchaseOrderDTO { OrderId = item.OrderId, payment_status = item.payment_status, diverlyType = item.PaymentType, OrderCount = (int)item.GetNetTotal(), OrderDate = item.OrderDate, }); ;

                }

            }

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void btnShowTodaysOrders_Click(object sender, RoutedEventArgs e)
        {
            ddSupplier.SelectedValue = null;
            ddPaymentStatus.SelectedValue = null;
            ddPaymentMode.SelectedValue = null;
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
            listOrderAccepted.Items.Clear();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                List<PurchaseOrderDTO> Allorders = DB.PurchaseOrder.GetMappedOrder();
                Allorders = Allorders.Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                foreach (var item in Allorders)
                {
                    listOrderAccepted.Items.Add(new PurchaseOrderDTO { OrderId = item.OrderId, payment_status = item.payment_status, diverlyType = item.PaymentType, OrderCount = (int)item.GetNetTotal(), OrderDate = item.OrderDate,}); ;

                }
            }
        }
    }
}
