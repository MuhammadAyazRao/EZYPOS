using Common;
using Common;
using Common.DTO;
using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.Helper.Session;
using EZYPOS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace EZYPOS.UserControls.Transaction
{
    /// <summary>
    /// Interaction logic for UserControlSaleTransaction.xaml
    /// </summary>
    public partial class UserControlSaleTransaction : UserControl
    {
        public UserControlSaleTransaction(Order EditOrder=null)
        {
            InitializeComponent();
            // this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            // this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Language = XmlLanguage.GetLanguage(HelperMethods.GetCurrency());
            listKitchenLineItems.Width = System.Windows.SystemParameters.PrimaryScreenWidth - 400;
            BusyIndicator.ShowBusy();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                //List<DAL.DBMODEL.ProductCategory> CategoryList = DB.ProductCategory.GetAll().Select(x => new DAL.DBMODEL.ProductCategory { Name = x.Name, Id = x.Id }).ToList();
                //DDCategory.ItemsSource = CategoryList;

                var CategoryList = DB.ProductCategory.GetAll().ToList();
                DDCategory.ItemsSource = CategoryList;
            }
            
            listKitchenLineItems.ItemsSource = GetProducts();
            BusyIndicator.CloseBusy();
            if (EditOrder != null)
            {
                order.OrderId = EditOrder.OrderId;
                order.EmployeeId = EditOrder.EmployeeId;
                order.CustId = EditOrder.CustId;
                order.PaymentType = EditOrder.PaymentType;
                order.payment_status = EditOrder.payment_status;
                order.OrderDate = EditOrder.OrderDate;
                order.Discount = EditOrder.Discount;
                order.DeliverCharges = EditOrder.DeliverCharges;
                Initialize(EditOrder);
            }
           

        }

        public void Initialize(Order Odr)
        {
            btnEdit.Visibility = Visibility.Visible;
            btnPay.Visibility = Visibility.Collapsed;
            foreach (var odritem in Odr?.OrdersDetails)
            {
                AddToCart(odritem?.Item.name, (decimal)odritem?.Item.price, (decimal)odritem?.Item.PurchasePrice,odritem.Item.TaxType,odritem.Item.Tax, (int) odritem?.Item.id, (int)odritem?.Qty , odritem.ItemDiscount);
            }
        }
        public Order order = new Order();
        private void ActiveSession_DeleliveryChargesCaltulated(object parameter)
        {
            //if (listBoxItemCart.Items.Count != 0)
            {

                order.DeliverCharges = Convert.ToDecimal(parameter);
                UpdateBillSummary();
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
                    decimal Total = order.GetNetTotal();
                    if (Total >= Convert.ToInt32(MinimumTaxLimit))
                    {
                        TaxPercentage = Convert.ToDecimal(((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.TaxPercentage).FirstOrDefault().AppValue);
                        Tax = TaxPercentage / 100 * Total;
                    }
                }
                else
                {
                    foreach (var item in order?.OrdersDetails)
                    {
                        Tax += item.Item.Tax * item.Qty;
                    }
                }

            }
            taxDTO.Percentage = TaxPercentage;
            taxDTO.Tax = Tax;
            return taxDTO;

        }

        // Delete Cart Items on the basis of selected item within cart list
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                order.OrdersDetails.RemoveAt(listBoxItemCart.SelectedIndex);
                listBoxItemCart.Items.RemoveAt(listBoxItemCart.SelectedIndex);
                //listBoxItemCart.SelectedIndex = listBoxItemCart.Items.Count - 1;
                listBoxItemCart.SelectedIndex = 0;
                if (listBoxItemCart.Items.Count == 0)
                { CartVisibility(); }

                UpdateBillSummary();

            }
            catch (Exception ex)
            {
                EZYPOS.View.MessageBox.ShowCustom("Deleting Item Failed", "Error", "ok");
            }
        }

        //--- Increase or Decrease cart quantity
        private void incdec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    Label button = (Label)sender;
                    if (button != null)
                    {
                        OrderDetail orderDetails = (OrderDetail)listBoxItemCart.SelectedItem;

                        if (button.Content.ToString() == "+")
                        {
                            if (orderDetails.Qty + 1 <= Db.Stock.GetProductQty(orderDetails.Item.id))
                            {
                                orderDetails.Qty = orderDetails.Qty + 1;
                                int INDEX = listBoxItemCart.SelectedIndex;
                                order.OrdersDetails.RemoveAt(INDEX);
                                listBoxItemCart.Items.RemoveAt(INDEX);
                                order.OrdersDetails.Insert(INDEX, orderDetails);
                                listBoxItemCart.Items.Insert(INDEX, orderDetails);
                                listBoxItemCart.SelectedIndex = INDEX;
                            }
                            else
                            {
                                EZYPOS.View.MessageBox.ShowCustom("Available Qty is " + Db.Stock.GetProductQty(orderDetails.Item.id), "QTY Exceeded", "Ok");
                            }

                        }
                        else
                        {
                            if (orderDetails.Qty > 1)
                            {
                                orderDetails.Qty--;
                                int INDEX = listBoxItemCart.SelectedIndex;
                                order.OrdersDetails.RemoveAt(INDEX);
                                listBoxItemCart.Items.RemoveAt(INDEX);
                                order.OrdersDetails.Insert(INDEX, orderDetails);
                                listBoxItemCart.Items.Insert(INDEX, orderDetails);
                                listBoxItemCart.SelectedIndex = INDEX;
                            }
                        }
                        UpdateBillSummary();

                    }
                }
            }
            catch (Exception ex)
            {
                EZYPOS.View.MessageBox.ShowCustom("Changing Item Quantity Failed", "Error", "ok");
            }
        }   //--- end incdec_Click


        private void expander_Collapsed(object sender, RoutedEventArgs e)
        {
            // expander.Margin = new Thickness(0, 0, 0, 61);
            expander.Height = 80;
            listBoxItemCart.Margin = new Thickness() { Bottom = 100, Top = 25 };
        }

        private void expander_Expanded(object sender, RoutedEventArgs e)
        {
            expander.Margin = new Thickness() { Bottom = 61 };
            expander.Height = 197;
            if (listBoxItemCart != null)
                listBoxItemCart.Margin = new Thickness() { Bottom = 251, Top = 25 };
        }


        #region Event for button delete cart items
        private void btnDeleteCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (order.OrdersDetails != null)
                {
                    var status = EZYPOS.View.MessageYesNo.ShowCustom("confirmation", "Want to delete", "yes", "No");
                    if (status)
                    {
                        EmptyCart();
                    }
                }
            }
            catch (Exception ex)
            {
                EZYPOS.View.MessageBox.ShowCustom("Deleting Cart Failed", "Error", "ok");
            }
        }
        #endregion


        //--- Coupon logic 
        private void Button_Coupon(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    jayeatEntities context = new jayeatEntities();
            //    bool isCategory = false;
            //    if (listBoxItemCart.Items.Count != 0)
            //    {
            //        CouponInputUI cop = new CouponInputUI();
            //        if (cop.ShowDialog() == true)
            //        {
            //            if (cop.Coupon.applies_to.ToLower() == "category")
            //            {
            //                var arr = cop.Coupon.categories.Split(',');
            //                List<OrderDetail> _Details = listBoxItemCart.Items.Cast<OrderDetail>().ToList();
            //                foreach (OrderDetail item in _Details)
            //                {
            //                    item i = context.items.Find(item.Item.id);
            //                    sub_categories sub = context.sub_categories.FirstOrDefault(x => x.id == i.sub_cat_id);
            //                    category cat = context.categories.FirstOrDefault(x => x.id == sub.parent_id);

            //                    foreach (string id in arr)
            //                    {
            //                        if (Convert.ToInt32(id) == cat.id)
            //                        {
            //                            item.Coupon = cop.Coupon;
            //                            UpdateBillSummary();
            //                            isCategory = true;
            //                            break;
            //                        }
            //                    }

            //                }

            //                if (!isCategory)
            //                    Views.MessageBox.ShowCustom("Category not exist in the cart", "Discount Error", "Ok");
            //            }
            //            else
            //            {
            //                order.Coupon = cop.Coupon;
            //                UpdateBillSummary();
            //            }
            //        }
            //    }
            //    else
            //        Views.MessageBox.ShowCustom("Must add some items to cart to apply coupon.", "Cart is Empty", "OK");

            //    context.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    Epos.Views.MessageBox.ShowCustom("Adding Coupon Failed", "Error", "ok");
            //}
        }   //--- end coupon logic


        private void bdrAddonItems_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrderDetail od = (OrderDetail)listBoxItemCart.SelectedItem;
        }

        private void btnHold_Click(object sender, RoutedEventArgs e)
        {
            //if (listBoxItemCart.Items.Count != 0)
            //{
            //    order.OrdersDetails = listBoxItemCart.Items.Cast<OrderDetail>().ToList();
            //    uow.orderMasters.Add(Converssion.ObjectToObjectMst(order, (int)OrderStatus.Hold));
            //    int i = 0;
            //    try
            //    {
            //        i = uow.Complete();
            //    }
            //    catch
            //    {
            //        MessageBoxUI.ShowCustom("Error accured while holding cart items. ", "Error", "Ok");
            //    }
            //    if (i != 0)
            //    {
            //        listBoxItemCart.Items.Clear();
            //        UpdateBillSummary();
            //        CartVisibility();
            //    }
            //}
        }


        private void btnNoteEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxItemCart.SelectedItem != null)
                {
                    OrderDetail orderDetails = (OrderDetail)listBoxItemCart.SelectedItem;
                    int INDEX = listBoxItemCart.SelectedIndex;
                    order.OrdersDetails.RemoveAt(INDEX);
                    listBoxItemCart.Items.RemoveAt(INDEX);
                    EditSaleItem Edit = new EditSaleItem();
                    Edit.Price = orderDetails.Item.price.ToString();
                    Edit.Discount = orderDetails.ItemDiscount.ToString();
                    Edit.Qty = orderDetails.Qty.ToString();
                    Edit.Refresh();

                    if (Edit.ShowDialog() == true)
                    {
                        //orderDetails.Note = "03/03/2021";
                        orderDetails.Item.price = Convert.ToDecimal(Edit.txtSalePrice.Text);
                        orderDetails.Qty = Convert.ToInt16(Edit.txtQty.Text);
                        orderDetails.ItemDiscount = Convert.ToDecimal(Edit.txtDiscount.Text);
                    }
                    order.OrdersDetails.Insert(INDEX, orderDetails);
                    listBoxItemCart.Items.Insert(INDEX, orderDetails);
                    listBoxItemCart.SelectedIndex = INDEX;
                    UpdateBillSummary();

                }
            }
            catch (Exception ex)
            {
                EZYPOS.View.MessageBox.ShowCustom("Updating Note Failed", "Error", "ok");
            }
            //try
            //{
            //    if (listBoxItemCart.SelectedItem != null)
            //    {
            //        OrderDetail or = (OrderDetail)listBoxItemCart.SelectedItem;
            //        NoteInput note = new NoteInput(or.Note);
            //        if (note.ShowDialog() == true)
            //        {
            //            or.Note = note.Note;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Epos.Views.MessageBox.ShowCustom("Updating Note Failed", "Error", "ok");
            //}
        }

        //private void btnEditAdonItem_Click(object sender, RoutedEventArgs e)
        //{
        //    OrderDetail or = (OrderDetail)listBoxItemCart.SelectedItem;
        //    List<addon_categories> adonCategories = context.addon_categories.Where(x => x.restaurant_id == ActiveSession.restaurant.id && x.id == or.Item.addon_item_id).ToList();
        //    AddOnWindow adon = new AddOnWindow(or.AdonItems, adonCategories);
        //    if (adon.ShowDialog() == true)
        //    {
        //        or.AdonItems = adon.sadonItem;
        //    }
        //}

        private void btnOpenNoteInput_Click(object sender, RoutedEventArgs e)
        {
            btnNoteEdit_Click(sender, e);
        }

        private void btnAdonDelete_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    addon_item item = (sender as Button).DataContext as addon_item;
            //    OrderDetail od = listBoxItemCart.SelectedItem as OrderDetail;
            //    od.AdonItems.Remove(item);
            //    od.UpdateAdonList();
            //    UpdateBillSummary();
            //}
            //catch (Exception ex)
            //{
            //    Epos.Views.MessageBox.ShowCustom("Deleting Addon Failed", "Error", "ok");
            //}
            ////for (int i = 0; i < od.AdonItems.Count; i++)
            ////{
            ////    if (od.AdonItems[i].id == item.id)
            ////    {
            ////        od.AdonItems[i].Remove(item);

            ////    }
            ////}

        }




        #region Methods
        public void CartVisibility()
        {
            if (listBoxItemCart.Items.Count == 0)
            {
                listBoxItemCart.Visibility = Visibility.Collapsed;
                cartHeader.Visibility = Visibility.Collapsed;
                cartImg.Visibility = Visibility.Visible;
            }
            else
            {
                listBoxItemCart.Visibility = Visibility.Visible;
                cartHeader.Visibility = Visibility.Visible;
                cartImg.Visibility = Visibility.Collapsed;
            }
        }

        public void UpdateBillSummary()
        {
            lblDicAmt.Content = order.GetTotalDiscount();
            //lblItems.Content = listBoxItemCart.Items.Count;
            lblTax.Content = Tax_Taxpercentage().Tax;
            lblTotal.Content = order.GetNetTotal()+ Tax_Taxpercentage().Tax;
            lblDeliveryCharges.Content = order.DeliverCharges;
            //ViewHelper.FindChild<Label>(expander, "lblItems").Content = listBoxItemCart.Items.Count;
            //ViewHelper.FindChild<Label>(expander, "lblDicAmt").Content = order.GetTotalDiscount();
            //ViewHelper.FindChild<Label>(expander, "lblTotal").Content = order.GetNetTotal();
            //ViewHelper.FindChild<Label>(expander, "lblDeliverCharges").Content = order.DeliverCharges;
            //ViewHelper.FindChild<Label>(expander, "lblSerAmt").Content = order.ServiceCharges;

        }

        #endregion
        public void EmptyCart()
        {
            order = new Order();
            btnEdit.Visibility = Visibility.Collapsed;
            btnPay.Visibility = Visibility.Visible;
            listBoxItemCart.Items.Clear();
            CartVisibility();
            UpdateBillSummary();
            ActiveSession.order_Discount_percentage = 0;
        }
        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForm Checkout = new CheckOutForm(order);
            Checkout.ScreenType = Common.ScreenType.Sale;
            Checkout.Refresh();
            if (Checkout.ShowDialog() == true)
            {
                EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Sucess", "Ok");
                var inv_print = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.PrintInvoice).FirstOrDefault().AppValue;
                if (inv_print.ToLower() == "true")
                {
                    if (order.OrdersDetails != null)
                    {
                        int MaxNoPrints = Convert.ToInt32(((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.MaxNoPrints).FirstOrDefault().AppValue);
                        for(int i = 1; i <= MaxNoPrints; i++)
                        {
                            Invoice inv = new Invoice();
                            inv.DoPrintJob(order);
                        }
                    }
                }
                EmptyCart();

            }
            //try
            //{
            //    jayeatEntities context = new jayeatEntities();

            //    if (listBoxItemCart.Items.Count != 0)
            //    {
            //        order.OrdersDetails = listBoxItemCart.Items.Cast<OrderDetail>().ToList();
            //        CheckOutForm paynum = new CheckOutForm(order);

            //        if (order.DeliverCharges != 0)
            //        {
            //            paynum.cbxDelivery.SelectedValue = order.DeliverCharges;
            //        }
            //        //if (!string.IsNullOrEmpty(order.Instrictions))
            //        //{
            //        //    // To show order instructions in comment box uncommnet below line
            //        //    //paynum.txtCont.Text = order.Instrictions;
            //        //}
            //        var val = paynum.eatin.IsEnabled = false;
            //        order odr = null;
            //        if (paynum.ShowDialog() == true)
            //        {
            //            int a = 0;
            //            using (var trans = new TransactionScope())
            //            {
            //                try
            //                {
            //                    if (true)
            //                    {
            //                        odr = Converssion.Add_Order_Api(paynum.ContextOrder, OrderEnums.PaymentStatus.completed, OrderEnums.eatinn_payment_status.completed, 0);
            //                        List<OrderDetail> _Details = paynum.Order.OrdersDetails;

            //                        context.orders.Add(odr);
            //                        context.SaveChanges();

            //                        for (int i = 0; i < _Details.Count; i++)
            //                        {
            //                            order_detail order_Detail = Converssion.Add_to_orderDetail(odr.id, _Details[i].Item.id, _Details[i].Item.name, _Details[i].Note, _Details[i].Qty, _Details[i].Item.price, 0, "Null", i, "cooking", _Details[i].Item);
            //                            context.order_detail.Add(order_Detail);
            //                            if (_Details[i].AdonItems != null)
            //                            {
            //                                for (int y = 0; y < _Details[i].AdonItems.Count; y++)
            //                                {
            //                                    order_detail adon = new order_detail();
            //                                    addon_item item = _Details[i].AdonItems[y];
            //                                    adon = Converssion.Add_to_orderDetail(odr.id, item.id, item.name, "null", item.qty * _Details[i].Qty, item.price, _Details[i].Item.id, y.ToString(), 0, "cooking", null);
            //                                    context.order_detail.Add(adon);
            //                                }
            //                            }
            //                        }

            //                        a = context.SaveChanges();
            //                        trans.Complete();

            //                    }

            //                }
            //                catch (DbEntityValidationException dbEx)
            //                {
            //                    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //                    {
            //                        foreach (var validationError in validationErrors.ValidationErrors)
            //                        {
            //                            Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //                        }
            //                    }
            //                }
            //            }

            //            if (a != 0)
            //            {
            //                OnCheckout?.Invoke(context.orders.Find(odr.id), EventArgs.Empty);
            //                listBoxItemCart.Items.Clear();
            //                order = new Order();
            //                UpdateBillSummary();
            //                CartVisibility();
            //                ActiveSession.ClearCustomerComment(paynum.customer?.bill_phone);
            //                ActiveSession.ClearTempDataForCaller();
            //                ActiveSession.order_Discount_percentage = 0;
            //            }
            //        }
            //    }
            //    //context.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    Epos.Views.MessageBox.ShowCustom("Completing Order Failed", "Error", "ok");
            //}
        }



        private void btnPrttyCash_Click(object sender, RoutedEventArgs e)
        {
            //PettyCashUI petty = new PettyCashUI();
            //petty.ShowDialog();
        }

        private void btnComnt_Click(object sender, RoutedEventArgs e)
        {
            //if (order.OrdersDetails == null)
            //{
            //    Views.MessageBox.ShowCustom("Cart is empty.", "Order Comment", "Ok");
            //    return;
            //}

            //OrderInstruction instruction = new OrderInstruction();
            //if (instruction.ShowDialog().Value)
            //{
            //    order.Instrictions = instruction.OrderComments;
            //}
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                // Delete Order 
                //Delete Order Detail
                // Detele Stock_OrderDetail
                if (Db.SaleOrder.DeleteOrder(order.OrderId))
                {
                    if (Db.SaleOrder.SaveOrder(order))
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Record Updated Successfully", "Sucess", "Ok");
                        EmptyCart();
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        // Discount
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            //try
            //{
            //    PinVerification verify = new PinVerification();
            //    if (verify.ShowDialog() == true)
            //    {
            //        if (listBoxItemCart.Items.Count != 0)
            //        {
            //            Discount dis = new Discount();
            //            if (dis.ShowDialog() == true)
            //            {
            //                if (dis.Discount_Type == 1)
            //                {
            //                    ActiveSession.order_Discount_percentage = 0;
            //                    order.Discount = dis.Discount_amount;
            //                }
            //                else if (dis.Discount_Type == 2)
            //                {
            //                    ActiveSession.order_Discount_percentage = dis.Discount_amount;
            //                    order.Discount = (dis.Discount_amount / 100) * order.GetTotal();
            //                }
            //                UpdateBillSummary();

            //            }
            //        }
            //        else
            //            Views.MessageBox.ShowCustom("Must add some items to cart to apply Discount.", "Cart is Empty", "OK");

            //    }
            //}
            //catch (Exception exp)
            //{ Views.MessageBox.ShowCustom(exp.Message, "Discount Error", "OK"); }
        }


        //Addon Qty addition/Subtraction
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //addon_item item = (sender as Button).DataContext as addon_item;

            //OrderDetail od = listBoxItemCart.SelectedItem as OrderDetail;

            //for (int i = 0; i < od.AdonItems.Count; i++)
            //{

            //    if (od.AdonItems[i].name == item.name)
            //    {
            //        Button button = (Button)sender;
            //        if (button != null)
            //        {

            //            if (button.Content.ToString() == "+")
            //            {

            //                item.qty++;
            //                int index = od.AdonItems.IndexOf(item);
            //                od.AdonItems.Remove(item);
            //                od.AdonItems.Insert(index, item);
            //            }
            //            else
            //            {
            //                if (od.AdonItems[i].qty > 1)
            //                {
            //                    item.qty--;
            //                    int index = od.AdonItems.IndexOf(item);
            //                    od.AdonItems.Remove(item);
            //                    od.AdonItems.Insert(index, item);

            //                }
            //            }
            //            od.UpdateAdonList();
            //            UpdateBillSummary();



            //        }
            //    }
            //}


        }

        private void btnnew_Click(object sender, RoutedEventArgs e)
        {

            ManualItem Manual = new ManualItem();
            if (Manual.ShowDialog() == true)
            {
                if (Manual.ManualMenuitem != null)
                {
                    if (order.OrdersDetails == null)
                        order.OrdersDetails = new List<OrderDetail>();

                    if (order.OrdersDetails == null)
                        order.OrdersDetails = new List<OrderDetail>();

                    order.OrdersDetails.Insert(0, Manual.ManualMenuitem as OrderDetail);
                    listBoxItemCart.Items.Insert(0, Manual.ManualMenuitem);
                    listBoxItemCart.SelectedIndex = 0;
                    CartVisibility();
                    UpdateBillSummary();
                }
            }
        }

        private void btmSummary_Click(object sender, RoutedEventArgs e)
        {
            if (order.OrdersDetails != null)
            {
                CartSummary OrderSummary = new CartSummary();
                var Taxobj = Tax_Taxpercentage();

                order.TaxPercentage = Taxobj.Percentage;
                order.Tax = Taxobj.Tax;
                OrderSummary.InvoiceUC.SetFlowDoc(Invoice.GetFlowDocuments(order));
                OrderSummary.ShowDialog();
            }
            else
            {
                EZYPOS.View.MessageBox.ShowCustom("Cart is Empty", "Empty Cart", "Ok");
            }

        }



        private void itemname_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            //if (listBoxItemCart.SelectedItem != null)
            //{

            //    EditItemName editname = new EditItemName();
            //    if (editname.ShowDialog() == true)
            //    {
            //        var index = listBoxItemCart.SelectedIndex;
            //        OrderDetail or = (OrderDetail)listBoxItemCart.SelectedItem;
            //        order.OrdersDetails.RemoveAt(listBoxItemCart.SelectedIndex);
            //        listBoxItemCart.Items.RemoveAt(listBoxItemCart.SelectedIndex);
            //        item selectedItem = (item)(or.Item);
            //        selectedItem.name = editname.NewName;
            //        order.OrdersDetails.Insert(index, or);
            //        listBoxItemCart.Items.Insert(index, or);
            //    }

            //}

        }

        private void itemqty_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            //if (listBoxItemCart.SelectedItem != null)
            //{

            //    EditItemQty editqty = new EditItemQty();
            //    if (editqty.ShowDialog() == true)
            //    {
            //        var index = listBoxItemCart.SelectedIndex;
            //        OrderDetail or = (OrderDetail)listBoxItemCart.SelectedItem;
            //        or.Qty = Convert.ToInt32(editqty.NewName);
            //        UpdateBillSummary();

            //    }

            //}

        }

        private void AddToCart(object sender)
        {
            if (order.OrdersDetails == null)
                order.OrdersDetails = new List<OrderDetail>();

            if (order.OrdersDetails == null)
                order.OrdersDetails = new List<OrderDetail>();

            order.OrdersDetails.Insert(0, sender as OrderDetail);
            listBoxItemCart.Items.Insert(0, sender);
            listBoxItemCart.SelectedIndex = 0;
            CartVisibility();
            UpdateBillSummary();
        }
        private void Test()
        {
            if (order.OrdersDetails == null)
                order.OrdersDetails = new List<OrderDetail>();

            if (order.OrdersDetails == null)
                order.OrdersDetails = new List<OrderDetail>();

            order.OrdersDetails.Insert(0, new OrderDetail { Qty = 1, Item = new item { name = "Samsung Mobile S4 2019", price = 33 }, ItemDiscount = 10 });
            listBoxItemCart.Items.Insert(0, new OrderDetail { Qty = 1, Item = new item { name = "Samsung Mobile S4 2019", price = 33 }, ItemDiscount = 10 });
            listBoxItemCart.SelectedIndex = 0;
            CartVisibility();
            UpdateBillSummary();
        }
        private void AddToCart(string Name, decimal Price, decimal PurchasePrice, string TaxType, decimal Tax, int ProductId, int Qty = 1, decimal Discount = 0)
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {                

                if (order.OrdersDetails == null)
                    order.OrdersDetails = new List<OrderDetail>();


                var CartProduct = order.OrdersDetails.Where(x => x.Item?.id == ProductId).FirstOrDefault();
                if (CartProduct != null)
                {
                    if (CartProduct.Qty + 1 <= Db.Stock.GetProductQty(ProductId))
                    {
                        CartProduct.Qty = CartProduct.Qty + 1;
                        int INDEX = listBoxItemCart.SelectedIndex;
                        order.OrdersDetails.RemoveAt(INDEX);
                        listBoxItemCart.Items.RemoveAt(INDEX);
                        order.OrdersDetails.Insert(INDEX, CartProduct);
                        listBoxItemCart.Items.Insert(INDEX, CartProduct);
                        listBoxItemCart.SelectedIndex = INDEX;
                    }
                    else
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Available Qty is " + Db.Stock.GetProductQty(ProductId), "QTY Exceeded", "Ok");
                    }
                }
                else
                {
                    if (Db.Stock.GetProductQty(ProductId) >= 1)
                    {
                        order.OrdersDetails.Insert(0, new OrderDetail { Qty = Qty, Item = new item { name = Name, price = Price, PurchasePrice = PurchasePrice, TaxType= TaxType, Tax= Tax, id = ProductId }, ItemDiscount = Discount });
                        listBoxItemCart.Items.Insert(0, new OrderDetail { Qty = Qty, Item = new item { name = Name, price = Price, PurchasePrice = PurchasePrice, TaxType = TaxType, Tax = Tax, id = ProductId }, ItemDiscount = Discount });
                        listBoxItemCart.SelectedIndex = 0;
                    }
                    else
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Available Qty is " + Db.Stock.GetProductQty(ProductId), "QTY Exceeded", "Ok");
                    }
                }

                CartVisibility();
                UpdateBillSummary();
            }
        }
        public List<ProductDTO> GetProducts(int SubCategoryId=0)
        {
            List<ProductDTO> Products = new List<ProductDTO>();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (SubCategoryId != 0)
                {
                    Products = Db.Product.GetAll().Where(x => x.SubcategoryId == SubCategoryId).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = X.Size.ToString(), Unit = X.UnitNavigation.Name, RetailPrice = X.RetailPrice , PurchasePrice = X.PurchasePrice, Tax = X.Tax, TaxType= X.TaxType}).ToList();
                }
                else if (DDCategory.SelectedValue != null && DDCategory.Text.ToLower() != "all")
                {
                    Products = Db.Product.GetAll().Where(x => x.CategoryId == Convert.ToInt32(DDCategory.SelectedValue) ).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size= X.Size.ToString(), Unit = X.UnitNavigation.Name, RetailPrice = X.RetailPrice, PurchasePrice = X.PurchasePrice, Tax = X.Tax, TaxType = X.TaxType }).ToList();
                }
                else
                {
                    Products = Db.Product.GetAll().Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = X.Size.ToString(), Unit = X.UnitNavigation.Name, RetailPrice = X.RetailPrice , PurchasePrice = X.PurchasePrice, Tax = X.Tax, TaxType = X.TaxType }).ToList();
                }
            }
            return Products;
        }

        public List<ProductDTO> GetProductsByCategory(int id)
        {
            List<ProductDTO> Products = new List<ProductDTO>();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                Products = Db.Product.GetAll().Where(x => x.CategoryId == id).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = X.Size.ToString(), Unit = X.UnitNavigation.Name, RetailPrice = X.RetailPrice, PurchasePrice = X.PurchasePrice, Tax = X.Tax, TaxType = X.TaxType }).ToList();
            }
            return Products;
        }

        public ProductDTO GetProductsbycode(string code)
        {
            ProductDTO Product = new ProductDTO();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                
                    Product = Db.Product.GetAll().Where(x => x.Barcode == code).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = X.Size.ToString(), Unit = X.UnitNavigation.Name, RetailPrice = X.RetailPrice , PurchasePrice = X.PurchasePrice, Tax = X.Tax, TaxType = X.TaxType }).FirstOrDefault();
                
            }
            return Product;
        }

        public List<ProductDTO> GetProductsbyName(string Name)
        {
            List<ProductDTO> Products = new List<ProductDTO>();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if(DDCategory.SelectedValue == null || DDCategory.Text.ToLower() == "all")
                {
                    Products = Db.Product.GetAll().Where(x => x.ProductName.Contains(Name)).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = X.Size.ToString(), Unit = X.UnitNavigation.Name, RetailPrice = X.RetailPrice , PurchasePrice = X.PurchasePrice, Tax = X.Tax, TaxType = X.TaxType }).ToList();
                }
                else if (DDSubCategory.SelectedValue == null || DDSubCategory.Text.ToLower() == "all")
                {
                    Products = Db.Product.GetAll().Where(x => x.ProductName.Contains(Name) && x.CategoryId == Convert.ToInt32(DDCategory.SelectedValue)).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = X.Size.ToString(), Unit = X.UnitNavigation.Name, RetailPrice = X.RetailPrice, PurchasePrice = X.PurchasePrice, Tax = X.Tax, TaxType = X.TaxType }).ToList();
                }
                else
                {
                    Products = Db.Product.GetAll().Where(x => x.ProductName.Contains(Name) && x.SubcategoryId == Convert.ToInt32(DDSubCategory.SelectedValue)).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = X.Size.ToString(), Unit = X.UnitNavigation.Name, RetailPrice = X.RetailPrice , PurchasePrice = X.PurchasePrice, Tax = X.Tax, TaxType = X.TaxType }).ToList();
                }

            }
            return Products;
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }

        private void orderDiscount_Click(object sender, RoutedEventArgs e)
        {
            //Pinverification pinverify = new Pinverification();
            //if (pinverify.ShowDialog() == true)
            {
                Discount popup = new Discount();
                if (popup.ShowDialog() == true)
                {
                    decimal digit = Convert.ToDecimal(popup.pin);
                    if (popup.DiscountType.SelectedIndex == 0)
                    {
                        ActiveSession.order_Discount_percentage = 0;
                        order.Discount = digit;
                    }
                    else if (popup.DiscountType.SelectedIndex == 1)
                    {
                        ActiveSession.order_Discount_percentage = Convert.ToDecimal(digit);
                        order.Discount = (digit / 100) * order.GetTotal();
                    }
                    UpdateBillSummary();

                }
            }

        }

        //--- Delivery Charges logic 
        private void DeliveryCharges_Click(object sender, RoutedEventArgs e)
        {
            DeliveryCharges popup = new DeliveryCharges();
            if (popup.ShowDialog() == true)
            {
                decimal digit = Convert.ToDecimal(popup.pin);
                order.DeliverCharges = digit;
                UpdateBillSummary();

            }
        }   //--- end Delivery Charges logic
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Invoice inv = new Invoice();
            inv.DoPrintJob(order);
        }

        private void AddTocart_Click(object sender, RoutedEventArgs e)
        {
            
            ListBoxItem selectedItem = (ListBoxItem)listKitchenLineItems.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);            
            ProductDTO Product = selectedItem.Content as ProductDTO;
            if (Product != null)
            {
              AddToCart(Product.ProductName, (decimal)Product.RetailPrice, (decimal)Product?.PurchasePrice,Product.TaxType,(decimal)Product.Tax, Product.Id);            
            }           
        }

        

        private void DDCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                List<SubCategoryDTO> SubCategoryList = DB.ProductSubcategory.GetAll().Where(x=> x.CategoryId == Convert.ToInt32(DDCategory.SelectedValue)).Select(x => new SubCategoryDTO { SubcategoryName = x.SubcategoryName, Id = x.Id }).ToList();
                SubCategoryList.Insert(0, new SubCategoryDTO { Id = 0, SubcategoryName = "ALL" });
                DDSubCategory.ItemsSource = SubCategoryList;

                BusyIndicator.ShowBusy();
                Barcode.Text = null;
                if (DDCategory.SelectedValue != null)
                {
                    listKitchenLineItems.ItemsSource = GetProductsByCategory(Convert.ToInt16(DDCategory.SelectedValue));
                }
                BusyIndicator.CloseBusy();

            }
        }
        private void DDSubCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusyIndicator.ShowBusy();
            Barcode.Text = null;
            if (DDSubCategory.SelectedValue != null)
            {
                listKitchenLineItems.ItemsSource = GetProducts(Convert.ToInt16(DDSubCategory.SelectedValue));
            }
            BusyIndicator.CloseBusy();
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (IsDigitsOnly(Barcode.Text) && Barcode.Text!="")
                { 
                    var item = GetProductsbycode(Barcode.Text);
                    if (item != null)
                    {
                        AddToCart(item.ProductName, (decimal)item.RetailPrice, (decimal)item?.PurchasePrice,item.TaxType, (decimal)item.Tax, item.Id);
                        //listKitchenLineItems.ItemsSource = null;
                    }
                    else
                    {
                        EZYPOS.View.MessageBox.ShowCustom("No item found against Barcode", "Not found", "Ok");
                        listKitchenLineItems.ItemsSource = GetProducts();
                    }
                    
                }
                else
                {
                    var items = GetProductsbyName(Barcode.Text);
                    if (items!= null)
                    {
                        listKitchenLineItems.ItemsSource = items;
                    }
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlViewOrder());
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DDCategory.SelectedValue = null;
            DDSubCategory.SelectedValue = null;
            Barcode.Text = null;
            listKitchenLineItems.ItemsSource = GetProducts();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Clear_Click(sender, e);
        }

        private void Command_BarcodeFoucus(object sender, ExecutedRoutedEventArgs e)
        {
            Barcode.Focus();
        }

        private void Command_EditItem(object sender, ExecutedRoutedEventArgs e)
        {
            btnNoteEdit_Click(sender, e);
        }
        private void Command_DeleteItem(object sender, ExecutedRoutedEventArgs e)
        {
            Button_Click(sender,e);
        }
        private void Command_IncQty(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    OrderDetail orderDetails = (OrderDetail)listBoxItemCart.SelectedItem;
                    if (orderDetails.Qty + 1 <= Db.Stock.GetProductQty(orderDetails.Item.id))
                    {
                        orderDetails.Qty = orderDetails.Qty + 1;
                        int INDEX = listBoxItemCart.SelectedIndex;
                        order.OrdersDetails.RemoveAt(INDEX);
                        listBoxItemCart.Items.RemoveAt(INDEX);
                        order.OrdersDetails.Insert(INDEX, orderDetails);
                        listBoxItemCart.Items.Insert(INDEX, orderDetails);
                        listBoxItemCart.SelectedIndex = INDEX;
                    }
                    else
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Available Qty is " + Db.Stock.GetProductQty(orderDetails.Item.id), "QTY Exceeded", "Ok");
                    }

                    UpdateBillSummary();

                }
            }
            catch (Exception ex)
            {
                EZYPOS.View.MessageBox.ShowCustom("Changing Item Quantity Failed", "Error", "ok");
            }
        }

        private void Command_DecQty(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    OrderDetail orderDetails = (OrderDetail)listBoxItemCart.SelectedItem;
                    if (orderDetails.Qty > 1)
                    {
                        orderDetails.Qty--;
                        int INDEX = listBoxItemCart.SelectedIndex;
                        order.OrdersDetails.RemoveAt(INDEX);
                        listBoxItemCart.Items.RemoveAt(INDEX);
                        order.OrdersDetails.Insert(INDEX, orderDetails);
                        listBoxItemCart.Items.Insert(INDEX, orderDetails);
                        listBoxItemCart.SelectedIndex = INDEX;
                    }


                    UpdateBillSummary();
                }
            }
            catch (Exception ex)
            {
                EZYPOS.View.MessageBox.ShowCustom("Changing Item Quantity Failed", "Error", "ok");
            }
        }

        private void Command_ViewOrder(object sender, ExecutedRoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlViewOrder());
        }

        private void Command_OrderDiscount(object sender, ExecutedRoutedEventArgs e)
        {
            orderDiscount_Click(sender, e);
        }

        private void Command_DeliveryCharges(object sender, ExecutedRoutedEventArgs e)
        {
            DeliveryCharges_Click(sender,e);
        }

        private void Command_ManualItem(object sender, ExecutedRoutedEventArgs e)
        {
            btnnew_Click(sender, e);
        }

        private void Command_Summary(object sender, ExecutedRoutedEventArgs e)
        {
            btmSummary_Click(sender, e);
        }
        private void Command_Proceed(object sender, ExecutedRoutedEventArgs e)
        {
            if (btnEdit.Visibility == Visibility.Visible)
            {
                btnEdit_Click(sender, e);
            }
            else
            {
                btnPay_Click(sender, e);
            }
        }

        private void Command_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            btnDeleteCart_Click(sender, e);
        }
    }
}
