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
            Refresh();
        }

        void Refresh()
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                listOrderAccepted.Items.Clear();
                foreach (var item in DB.PurchaseOrder.GetMappedOrder(0))
                {
                    listOrderAccepted.Items.Add(new PurchaseOrderDTO { OrderId = item.OrderId, payment_status = item.payment_status, PaymentType = item.PaymentType, OrderCount = (int)item.GetNetTotal(), OrderDate = item.OrderDate }); ;

                }
            }
        }
        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            OnItemResume?.Invoke(listOrderHold.SelectedItem, null);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            switch (tb.Text)
            {
                case "Phone":
                    tb.Text = "";
                    tb.Foreground = Brushes.Black;
                    break;
                case "Postcode":
                    tb.Text = "";
                    tb.Foreground = Brushes.Black;
                    break;
                case "OrderNo":
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
                case "txtPhone":
                    if (txtPhone.Text == "")
                    {
                        tb.Text = "Phone";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtPhostcode":
                    if (txtPhostcode.Text == "")
                    {
                        tb.Text = "Postcode";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtOrderNum":
                    if (txtOrderNum.Text == "")
                    {
                        tb.Text = "OrderNo";
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
            //ListBoxItem selectedItem = (ListBoxItem)listOrderAccepted.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);
            //PurchaseOrderDTO Order = selectedItem.Content as PurchaseOrderDTO;
            //if (Order != null)
            //{
            //    using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            //    {

            //        Order = DB.PurchaseOrder.GetMappedOrder(Order.OrderId).FirstOrDefault();
            //    }
            //    if (Order.OrdersDetails != null)
            //    {
            //        CartSummary OrderSummary = new CartSummary();
            //        OrderSummary.InvoiceUC.SetFlowDoc(Invoice.GetFlowDocuments(Order));
            //        OrderSummary.ShowDialog();
            //    }
            //    else
            //    {
            //        EZYPOS.View.MessageBox.ShowCustom("Order is Empty", "Empty Order", "Ok");
            //    }
            //}
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            //ListBoxItem selectedItem = (ListBoxItem)listOrderAccepted.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);
            //Order Order = selectedItem.Content as Order;
            //if (Order != null)
            //{
            //    using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            //    {

            //        Order = DB.SaleOrder.GetMappedOrder(Order.OrderId).FirstOrDefault();
            //    }
            //    if (Order.OrdersDetails != null)
            //    {
            //        Invoice inv = new Invoice();
            //        inv.DoPrintJob(Order);
            //    }
            //    else
            //    {
            //        EZYPOS.View.MessageBox.ShowCustom("Order is Empty", "Empty Order", "Ok");
            //    }
            //}
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
    }
}
