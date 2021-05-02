﻿using Common.DTO;
using Common.Session;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
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
    /// Interaction logic for UserControlPurchaseTransaction.xaml
    /// </summary>
    public partial class UserControlPurchaseTransaction : UserControl
    {
        public UserControlPurchaseTransaction(PurchaseOrderDTO EditOrder=null)
        {
            InitializeComponent();
            listKitchenLineItems.Width = System.Windows.SystemParameters.PrimaryScreenWidth - 400;
            BusyIndicator.ShowBusy();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                List<SubCategoryDTO> CategoryList = DB.ProductSubcategory.GetAll().Select(x => new SubCategoryDTO { SubcategoryName = x.SubcategoryName, Id = x.Id }).ToList();
                CategoryList.Insert(0, new SubCategoryDTO { Id = 0, SubcategoryName = "ALL" });
                DDCategory.ItemsSource = CategoryList;
            }

            listKitchenLineItems.ItemsSource = GetProducts();
            BusyIndicator.CloseBusy();
            //if (EditOrder != null)
            //{
            //    order.OrderId = EditOrder.OrderId;
            //    Initialize(EditOrder);
            //}
        }
        public void Initialize(Order Odr)
        {
            btnEdit.Visibility = Visibility.Visible;
            btnPay.Visibility = Visibility.Collapsed;
            foreach (var odritem in Odr?.OrdersDetails)
            {
                AddToCart(odritem?.Item.name, (long)odritem?.Item.price, (int)odritem?.Item.id, (int)odritem?.Qty);
            }
        }
        public PurchaseOrderDTO order = new PurchaseOrderDTO();
        private void ActiveSession_DeleliveryChargesCaltulated(object parameter)
        {
            //if (listBoxItemCart.Items.Count != 0)
            {

                order.DeliverCharges = Convert.ToDouble(parameter);
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
                using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                {
                    Label button = (Label)sender;
                    if (button != null)
                    {
                        PurchaseOrderDetail orderDetails = (PurchaseOrderDetail)listBoxItemCart.SelectedItem;

                        if (button.Content.ToString() == "+")
                        {
                           // if (orderDetails.Qty + 1 <= Db.Stock.GetProductQty(orderDetails.Item.id))
                            {
                                orderDetails.Qty = orderDetails.Qty + 1;
                                int INDEX = listBoxItemCart.SelectedIndex;
                                order.OrdersDetails.RemoveAt(INDEX);
                                listBoxItemCart.Items.RemoveAt(INDEX);
                                order.OrdersDetails.Insert(INDEX, orderDetails);
                                listBoxItemCart.Items.Insert(INDEX, orderDetails);
                                listBoxItemCart.SelectedIndex = INDEX;
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
                    PurchaseOrderDetail orderDetails = (PurchaseOrderDetail)listBoxItemCart.SelectedItem;                
                    int INDEX = listBoxItemCart.SelectedIndex;
                    order.OrdersDetails.RemoveAt(INDEX);
                    listBoxItemCart.Items.RemoveAt(INDEX);
                    EditPurchaseItem Edit = new EditPurchaseItem();
                    Edit.StartDate.SelectedDate = orderDetails.StartDate==null?DateTime.Now:orderDetails.StartDate;
                    Edit.EndDate.SelectedDate = orderDetails.ExpiryDate == null ? DateTime.Now : orderDetails.ExpiryDate;
                    Edit.txtQty.Text = orderDetails.Qty.ToString();
                    Edit.txtDiscount.Text = orderDetails.ItemDiscount.ToString();


                    if (Edit.ShowDialog()==true)
                    {
                        //orderDetails.Note = "03/03/2021";
                        orderDetails.StartDate =(DateTime) Edit.StartDate.SelectedDate;
                        orderDetails.ExpiryDate = (DateTime) Edit.EndDate.SelectedDate;
                        orderDetails.Qty = Convert.ToInt16(Edit.txtQty.Text);
                        orderDetails.ItemDiscount = Convert.ToInt16(Edit.txtDiscount.Text);
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
            lblItems.Content = listBoxItemCart.Items.Count;
            lblTotal.Content = order.GetNetTotal();

            //ViewHelper.FindChild<Label>(expander, "lblItems").Content = listBoxItemCart.Items.Count;
            //ViewHelper.FindChild<Label>(expander, "lblDicAmt").Content = order.GetTotalDiscount();
            //ViewHelper.FindChild<Label>(expander, "lblTotal").Content = order.GetNetTotal();
            //ViewHelper.FindChild<Label>(expander, "lblDeliverCharges").Content = order.DeliverCharges;
            //ViewHelper.FindChild<Label>(expander, "lblSerAmt").Content = order.ServiceCharges;

        }

        #endregion
        public void EmptyCart()
        {
            order = new PurchaseOrderDTO();
            btnEdit.Visibility = Visibility.Collapsed;
            btnPay.Visibility = Visibility.Visible;
            listBoxItemCart.Items.Clear();
            CartVisibility();
            UpdateBillSummary();
            ActiveSession.order_Discount_percentage = 0;
        }
        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                if (Db.PurchaseOrder.SaveOrder(order))
                {
                    EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Sucess", "Ok");
                    EmptyCart();
                }
            }           
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


            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                // Delete Order 
                //Delete Order Detail
                // Detele Stock_OrderDetail
                if (Db.PurchaseOrder.DeleteOrder(order.OrderId))
                {
                    if (Db.PurchaseOrder.SaveOrder(order))
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

            //ManualItem Manual = new ManualItem();
            //if (Manual.ShowDialog() == true)
            //{
            //    if (Manual.ManualMenuitem != null)
            //    {
            //        if (order.OrdersDetails == null)
            //            order.OrdersDetails = new List<PurchaseOrderDetail>();

            //        if (order.OrdersDetails == null)
            //            order.OrdersDetails = new List<PurchaseOrderDetail>();

            //        order.OrdersDetails.Insert(0, Manual.ManualMenuitem as PurchaseOrderDetail);
            //        listBoxItemCart.Items.Insert(0, Manual.ManualMenuitem);
            //        listBoxItemCart.SelectedIndex = 0;
            //        CartVisibility();
            //        UpdateBillSummary();
            //    }
            //}
        }

        private void btmSummary_Click(object sender, RoutedEventArgs e)
        {
            //if (order.OrdersDetails != null)
            //{
            //    CartSummary OrderSummary = new CartSummary();
            //    OrderSummary.InvoiceUC.SetFlowDoc(Invoice.GetFlowDocuments(order));
            //    OrderSummary.ShowDialog();
            //}
            //else
            //{
            //    EZYPOS.View.MessageBox.ShowCustom("Cart is Empty", "Empty Cart", "Ok");
            //}

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
                order.OrdersDetails = new List<PurchaseOrderDetail>();

            if (order.OrdersDetails == null)
                order.OrdersDetails = new List<PurchaseOrderDetail>();

            order.OrdersDetails.Insert(0, sender as PurchaseOrderDetail);
            listBoxItemCart.Items.Insert(0, sender);
            listBoxItemCart.SelectedIndex = 0;
            CartVisibility();
            UpdateBillSummary();
        }
        private void Test()
        {
            if (order.OrdersDetails == null)
                order.OrdersDetails = new List<PurchaseOrderDetail>();

            if (order.OrdersDetails == null)
                order.OrdersDetails = new List<PurchaseOrderDetail>();

            order.OrdersDetails.Insert(0, new PurchaseOrderDetail { Qty = 1, Item = new Purchaseitem { name = "Samsung Mobile S4 2019", price = 33 }, ItemDiscount = 10 });
            listBoxItemCart.Items.Insert(0, new PurchaseOrderDetail { Qty = 1, Item = new Purchaseitem { name = "Samsung Mobile S4 2019", price = 33 }, ItemDiscount = 10 });
            listBoxItemCart.SelectedIndex = 0;
            CartVisibility();
            UpdateBillSummary();
        }
        private void AddToCart(string Name, long Price, int ProductId, int Qty = 1, int Discount = 0)
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {

                if (order.OrdersDetails == null)
                    order.OrdersDetails = new List<PurchaseOrderDetail>();


                var CartProduct = order.OrdersDetails.Where(x => x.Item?.id == ProductId).FirstOrDefault();
                if (CartProduct != null)
                {
                   // if (CartProduct.Qty + 1 <= Db.Stock.GetProductQty(ProductId))
                    {
                        CartProduct.Qty = CartProduct.Qty + 1;
                        int INDEX = listBoxItemCart.SelectedIndex;
                        order.OrdersDetails.RemoveAt(INDEX);
                        listBoxItemCart.Items.RemoveAt(INDEX);
                        order.OrdersDetails.Insert(INDEX, CartProduct);
                        listBoxItemCart.Items.Insert(INDEX, CartProduct);
                        listBoxItemCart.SelectedIndex = INDEX;
                    }
                   
                }
                else
                {
                    //if (Db.Stock.GetProductQty(ProductId) >= 1)
                    {
                        order.OrdersDetails.Insert(0, new PurchaseOrderDetail { Qty = Qty, Item = new Purchaseitem { name = Name, price = Price, id = ProductId }, ItemDiscount = Discount });
                        listBoxItemCart.Items.Insert(0, new PurchaseOrderDetail { Qty = Qty, Item = new Purchaseitem { name = Name, price = Price, id = ProductId }, ItemDiscount = Discount });
                        listBoxItemCart.SelectedIndex = 0;
                    }
                   
                }

                CartVisibility();
                UpdateBillSummary();
            }
        }
        public List<ProductDTO> GetProducts(int CategoryId = 0)
        {
            List<ProductDTO> Products = new List<ProductDTO>();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                if (CategoryId != 0)
                {
                    Products = Db.Product.GetAll().Where(x => x.Id == CategoryId).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = "", RetailPrice = X.PurchasePrice }).ToList();
                }
                else
                {
                    Products = Db.Product.GetAll().Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = "", RetailPrice = X.PurchasePrice }).ToList();
                }
            }
            return Products;
        }

        public ProductDTO GetProductsbycode(string code)
        {
            ProductDTO Product = new ProductDTO();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {

                Product = Db.Product.GetAll().Where(x => x.Barcode == code).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = "", RetailPrice = X.RetailPrice }).FirstOrDefault();

            }
            return Product;
        }

        public List<ProductDTO> GetProductsbyName(string Name)
        {
            List<ProductDTO> Products = new List<ProductDTO>();
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {

                Products = Db.Product.GetAll().Where(x => x.ProductName.Contains(Name)).Select(X => new ProductDTO { ProductName = X.ProductName, Id = X.Id, CategoryName = X.Category.Name, Size = "", RetailPrice = X.RetailPrice }).ToList();

            }
            return Products;
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
                    double digit = Convert.ToDouble(popup.pin);
                    if (popup.DiscountType.SelectedIndex == 0)
                    {
                        ActiveSession.order_Discount_percentage = 0;
                        order.Discount = digit;
                    }
                    else if (popup.DiscountType.SelectedIndex == 1)
                    {
                        ActiveSession.order_Discount_percentage = digit;
                        order.Discount = (digit / 100) * order.GetTotal();
                    }
                    UpdateBillSummary();

                }
            }

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            //Invoice inv = new Invoice();
            //inv.DoPrintJob(order);
        }

        private void AddTocart_Click(object sender, RoutedEventArgs e)
        {

            ListBoxItem selectedItem = (ListBoxItem)listKitchenLineItems.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);
            ProductDTO Product = selectedItem.Content as ProductDTO;
            if (Product != null)
            {
                AddToCart(Product.ProductName, Product.RetailPrice, Product.Id);
            }
        }



        private void DDCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusyIndicator.ShowBusy();
            if (DDCategory.SelectedValue != null)
            {
                listKitchenLineItems.ItemsSource = GetProducts(Convert.ToInt16(DDCategory.SelectedValue));
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
                if (IsDigitsOnly(Barcode.Text) && Barcode.Text != "")
                {
                    var item = GetProductsbycode(Barcode.Text);
                    if (item != null)
                    {
                        AddToCart(item.ProductName, item.RetailPrice, item.Id);
                        listKitchenLineItems.ItemsSource = null;
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
                    if (items != null)
                    {
                        listKitchenLineItems.ItemsSource = items;
                    }
                }
            }
        }
    }
}