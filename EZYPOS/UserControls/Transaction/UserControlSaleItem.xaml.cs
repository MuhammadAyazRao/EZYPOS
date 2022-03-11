using Common.DTO;
using Common.Session;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.Helper.Session;
using EZYPOS.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EZYPOS.UserControls.Transaction
{
    /// <summary>
    /// Interaction logic for UserControlSaleItem.xaml
    /// </summary>
    public partial class UserControlSaleItem : UserControl
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        


        public UserControlSaleItem()
        {
            AddHotKeys();
            InitializeComponent();
            InitializeClock();


        }
        private void InitializeClock()
        {
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            Clock.Content = d.Hour + " : " + d.Minute + " : " + d.Second;
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
                Label button = (Label)sender;
                if (button != null)
                {
                    OrderDetail orderDetails = (OrderDetail)listBoxItemCart.SelectedItem;

                    if (button.Content.ToString() == "+")
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
                        if (orderDetails.Qty > 1)
                        {
                            orderDetails.Qty--;


                        }
                    }
                    UpdateBillSummary();

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
                        order = new Order();
                        btnEdit.Visibility = Visibility.Collapsed;
                        listBoxItemCart.Items.Clear();
                        CartVisibility();
                        UpdateBillSummary();
                        ActiveSession.order_Discount_percentage = 0;
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
            ViewHelper.FindChild<Label>(expander, "lblItems").Content = listBoxItemCart.Items.Count;
            ViewHelper.FindChild<Label>(expander, "lblDicAmt").Content = order.GetTotalDiscount();
            ViewHelper.FindChild<Label>(expander, "lblTotal").Content = order.GetNetTotal();
            ViewHelper.FindChild<Label>(expander, "lblDeliverCharges").Content = order.DeliverCharges;
            ViewHelper.FindChild<Label>(expander, "lblSerAmt").Content = order.ServiceCharges;

        }

        #endregion

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
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

            //    if (listBoxItemCart.Items.Count != 0)
            //    {
            //        order.OrdersDetails = listBoxItemCart.Items.Cast<OrderDetail>().ToList();
            //        order odr = new order();

            //        int a = 0;
            //        try
            //        {
            //            odr.total = order.GetNetTotal();
            //            odr.discount_amount = order.GetTotalDiscount();
            //            odr.description = order.Instrictions;
            //            odr.id = order.OrderId;
            //            odr.user_id = order.CustId;
            //            odr.delivery_charges = order.DeliverCharges;
            //            odr.delivery_type = order.diverlyType;
            //            odr.Service_Charge = order.ServiceCharges;
            //            odr = Converssion.Add_Order_Api(odr, OrderEnums.PaymentStatus.completed, OrderEnums.eatinn_payment_status.completed, 0);
            //            odr.order_count = order.OrderCount;
            //            List<OrderDetail> _Details = order.OrdersDetails;

            //            using (var db = new jayeatEntities())
            //            {
            //                var result = db.orders.FirstOrDefault(x => x.id == odr.id);

            //                if (result == null)
            //                    return;

            //                db.Entry(result).CurrentValues.SetValues(odr);
            //                db.Database.ExecuteSqlCommand("DELETE FROM `order_detail` WHERE order_id = {0}", odr.id);
            //                db.SaveChanges();

            //                for (int i = 0; i < _Details.Count; i++)
            //                {
            //                    order_detail order_Detail = Converssion.Add_to_orderDetail(odr.id, _Details[i].Item.id, _Details[i].Item.name, _Details[i].Note, _Details[i].Qty, _Details[i].Item.price, 0, "Null", i, "cooking", _Details[i].Item);

            //                    if (_Details[i].subCategoryId != null)
            //                        order_Detail.sub_cat_id = _Details[i].subCategoryId;

            //                    if (_Details[i].subCategory != null)
            //                        order_Detail.sub_cat_name = _Details[i].subCategory;

            //                    db.order_detail.Add(order_Detail);
            //                    if (_Details[i].AdonItems != null)
            //                    {
            //                        for (int y = 0; y < _Details[i].AdonItems.Count; y++)
            //                        {
            //                            order_detail adon = new order_detail();
            //                            addon_item item = _Details[i].AdonItems[y];
            //                            adon = Converssion.Add_to_orderDetail(odr.id, item.id, item.name, "null", item.qty * _Details[i].Qty, item.price, _Details[i].Item.id, y.ToString(), 0, "cooking", null);
            //                            db.order_detail.Add(adon);
            //                        }
            //                    }
            //                }
            //                a = db.SaveChanges();
            //            }
            //        }
            //        catch (DbEntityValidationException dbEx)
            //        {
            //            foreach (var validationErrors in dbEx.EntityValidationErrors)
            //            {
            //                foreach (var validationError in validationErrors.ValidationErrors)
            //                {
            //                    Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //                }
            //            }
            //        }


            //        if (a != 0)
            //        {
            //            using (var db = new jayeatEntities())
            //            {
            //                OnCheckout?.Invoke(db.orders.Find(odr.id), EventArgs.Empty);
            //                listBoxItemCart.Items.Clear();
            //                order = new Order();
            //                UpdateBillSummary();
            //                CartVisibility();
            //                ActiveSession.ClearTempDataForCaller();
            //                ActiveSession.order_Discount_percentage = 0;
            //                btnEdit.Visibility = Visibility.Collapsed;
            //            }
            //        }
            //    }
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

        private void test_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }

        private void orderDiscount_Click(object sender, RoutedEventArgs e)
        {
            Pinverification pinverify = new Pinverification();
            if (pinverify.ShowDialog() == true)
            {
                Discount popup = new Discount();
                if (popup.ShowDialog() == true)
                {
                    decimal digit = Convert.ToDecimal(popup.pin);
                    if (popup.DiscountType.SelectedIndex == 0)
                    {
                        ActiveSession.order_Discount_percentage = 0;
                        //order.Discount = digit;
                    }
                    else if (popup.DiscountType.SelectedIndex == 1)
                    {
                        ActiveSession.order_Discount_percentage = digit;
                        //order.Discount = (digit / 100) * order.GetTotal();
                    }
                    UpdateBillSummary();

                }
            }

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Invoice inv = new Invoice();
            inv.DoPrintJob(order);
        }

        #region ShortCutKeys
        private void My_first_event_handler(object sender, ExecutedRoutedEventArgs e)
        {
            //handler code goes here.
            EZYPOS.View.MessageBox.ShowCustom("Alt+A key pressed","OK","OF");
        }

        private void My_second_event_handler(object sender, RoutedEventArgs e)
        {
            //handler code goes here. 
            EZYPOS.View.MessageBox.ShowCustom("Alt+B key pressed", "OK", "OF");
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EZYPOS.View.MessageBox.ShowCustom("Wndows Key Not Allowed", "Key Not Allowed", "ok");

        }
        private void AddHotKeys()
        {
            try
            {
                RoutedCommand firstSettings = new RoutedCommand();
                firstSettings.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(firstSettings, My_first_event_handler));

                RoutedCommand secondSettings = new RoutedCommand();
                secondSettings.InputGestures.Add(new KeyGesture(Key.B, ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(secondSettings, My_second_event_handler));
            }
            catch (Exception err)
            {
                //handle exception error
            }
        }
        #endregion

        private void PaymentMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
