using Common.DTO;
using Common.Session;
using DAL.Repository;
using EZYPOS.Helper;
using EZYPOS.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace EZYPOS.UserControls.Transaction
{
    public delegate void ItemResumeHandler(object sender, EventArgs e);
    /// <summary>
    /// Interaction logic for UserControlViewOrder.xaml
    /// </summary>
    public partial class UserControlViewOrder : UserControl
    {
        public event ItemResumeHandler OnItemResume;
        public event ItemResumeHandler OnItemSelected;
       
        public UserControlViewOrder()
        {
            InitializeComponent();
            this.Language = System.Windows.Markup.XmlLanguage.GetLanguage(HelperMethods.GetCurrency());
            Refresh();
            // Preparing.Add(new Order { OrderId = 1, payment_status = "Paid" ,PaymentType="Cash"});
            //Preparing.Add(new Order { OrderId = 2, payment_status = "Paid", PaymentType = "Credit" });
        }

        void Refresh()
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                ddCustomer.ItemsSource = DB.Customers.GetAll().ToList();
                ddCustomer.SelectedValue = null;
                ddPaymentStatus.SelectedValue = null;
                ddPaymentMode.SelectedValue = null;
                StartDate.SelectedDate = null;
                EndDate.SelectedDate = null;
                txtOrderNum.Text = "";
                listOrderAccepted.Items.Clear();
                foreach (var item in DB.SaleOrder.GetMappedOrder(0))
                {
                    listOrderAccepted.Items.Add(new Order { OrderId = item.OrderId, payment_status = item.payment_status, Instrictions = item.PaymentType, OrderCount = (int) item.GetNetTotal(), OrderDate = item.OrderDate }); ;

                }                
            }           
        }
        //--- methoeds
        //private void VisibilityControlAndStyle(int index)
        //{
        //    if (index != -1)
        //    {
        //        for (int i = 0; i < queueContainer.Children.Count; i++)
        //        {
        //            ListBox lb = queueContainer.Children[i] as ListBox;
        //            if (lb == null)
        //                return;
        //            if (i == index)
        //                lb.Visibility = Visibility.Visible;
        //            else
        //                lb.Visibility = Visibility.Collapsed;
        //        }
        //    }

        //}

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            OnItemResume?.Invoke(listOrderHold.SelectedItem, null);
        }

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
            Order Order = selectedItem.Content as Order;
            if (Order != null)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {

                    Order = DB.SaleOrder.GetMappedOrder(Order.OrderId).FirstOrDefault();
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
            Order Order = selectedItem.Content as Order;
            if (Order != null)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {

                    Order = DB.SaleOrder.GetMappedOrder(Order.OrderId).FirstOrDefault();
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
            Order Order = selectedItem.Content as Order;
            if (Order != null)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {

                    Order = DB.SaleOrder.GetMappedOrder(Order.OrderId).FirstOrDefault();
                }
                if (Order.OrdersDetails != null)
                {

                    ActiveSession.CloseDisplayuserControlMethod(new UserControlSaleTransaction(Order));
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
            Order Order = selectedItem.Content as Order;
            if (Order != null)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (DB.SaleOrder.DeleteOrder(Order.OrderId))
                    { 
                        EZYPOS.View.MessageBox.ShowCustom("Order Deleted Sucessfully", "Deleted Order", "Ok");
                        Refresh();
                    }
                    else
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Order is Empty", "Empty Order", "Ok");
                    }
                }               
            }
            
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                
                int SelectedCustomer = 0;
                if (ddCustomer.SelectedValue != null)
                {
                    SelectedCustomer = Convert.ToInt32(ddCustomer.SelectedValue);
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


                List<Order> Allorders = DB.SaleOrder.GetMappedOrder();
                if(StartDate.SelectedDate != null && EndDate.SelectedDate != null)
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    Allorders = Allorders.Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                }
                
                if (SelectedCustomer != 0)
                {
                    Allorders = Allorders.Where(x => x.CustId == SelectedCustomer).ToList();
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
                    listOrderAccepted.Items.Add(new Order { OrderId = item.OrderId, payment_status = item.payment_status, Instrictions = item.PaymentType, OrderCount =(int)item.GetNetTotal(), OrderDate = item.OrderDate,});

                }

            }

        }
        private void btnShowTodaysOrders_Click(object sender, RoutedEventArgs e)
        {
            ddCustomer.SelectedValue = null;
            ddPaymentMode.SelectedValue = null;
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
            listOrderAccepted.Items.Clear();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                List<Order> Allorders = DB.SaleOrder.GetMappedOrder();
                Allorders = Allorders.Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).ToList();
                foreach (var item in Allorders)
                {
                    listOrderAccepted.Items.Add(new Order { OrderId = item.OrderId, payment_status = item.payment_status, Instrictions = item.PaymentType, OrderCount = (int)item.GetNetTotal(), OrderDate = item.OrderDate,});

                }
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
