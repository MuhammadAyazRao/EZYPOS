using Common.Session;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EZYPOS.UserControls.Report
{
    /// <summary>
    /// Interaction logic for UserControlSaleOrderReport.xaml
    /// </summary>

    
    public partial class UserControlSaleOrderReport : UserControl
    {
        List<SaleOrderDTO> myList { get; set; }
        Pager<SaleOrderDTO> Pager = new Helper.Pager<SaleOrderDTO>();
        public UserControlSaleOrderReport()
        {
            InitializeComponent();
            Refresh();

        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.SaleOrder.GetAll().Select(x => new SaleOrderDTO
                {
                    id = x.Id,
                    restaurant_id = x.RestaurantId,
                    user_id = x.User.UserName,
                    order_count = x.OrderCount,
                    total = x.Total,
                    date = x.Date,
                    order_date = x.OrderDate,
                    description = x.Description,
                    coupon = x.Coupon,
                    coupon_value = x.CouponValue,
                    coupon_type = x.CouponType,
                    coupon_applies_to = x.CouponAppliesTo,
                    coupon_categories = x.CouponCategories,
                    discount_amount = x.DiscountAmount,
                    discount_desc = x.DiscountDesc,
                    payment_mode = x.PaymentMode,
                    payment_status = x.PaymentStatus,
                    addby = x.Addby,
                    addon = x.Addon,
                    customer_id = x.Customer.Name,
                    customer_phone = x.CustomerPhone,
                    is_updated = x.IsUpdated,
                    is_deleted = x.IsDeleted,
                    Cash_Amount = x.CashAmount,
                    Online_Amount = x.OnlineAmount,
                    Is_Printed = x.IsPrinted,
                    Service_Charge = x.ServiceCharge,
                }).ToList();

                ResetPaging(myList);
            }
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    myList = DB.SaleOrder.GetAll().Select(x => new SaleOrderDTO
                    {
                        id = x.Id,
                        restaurant_id = x.RestaurantId,
                        user_id = x.User.UserName,
                        order_count = x.OrderCount,
                        total = x.Total,
                        date = x.Date,
                        order_date = x.OrderDate,
                        description = x.Description,
                        coupon = x.Coupon,
                        coupon_value = x.CouponValue,
                        coupon_type = x.CouponType,
                        coupon_applies_to = x.CouponAppliesTo,
                        coupon_categories = x.CouponCategories,
                        discount_amount = x.DiscountAmount,
                        discount_desc = x.DiscountDesc,
                        payment_mode = x.PaymentMode,
                        payment_status = x.PaymentStatus,
                        addby = x.Addby,
                        addon = x.Addon,
                        customer_id = x.Customer.Name,
                        customer_phone = x.CustomerPhone,
                        is_updated = x.IsUpdated,
                        is_deleted = x.IsDeleted,
                        Cash_Amount = x.CashAmount,
                        Online_Amount = x.OnlineAmount,
                        Is_Printed = x.IsPrinted,
                        Service_Charge = x.ServiceCharge,
                    }).ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    myList = DB.SaleOrder.GetAll().Where(x => x.OrderDate >= Sdate && x.OrderDate <= Edate).Select(x => new SaleOrderDTO
                    {
                        id = x.Id,
                        restaurant_id = x.RestaurantId,
                        user_id = x.User.UserName,
                        order_count = x.OrderCount,
                        total = x.Total,
                        date = x.Date,
                        order_date = x.OrderDate,
                        description = x.Description,
                        coupon = x.Coupon,
                        coupon_value = x.CouponValue,
                        coupon_type = x.CouponType,
                        coupon_applies_to = x.CouponAppliesTo,
                        coupon_categories = x.CouponCategories,
                        discount_amount = x.DiscountAmount,
                        discount_desc = x.DiscountDesc,
                        payment_mode = x.PaymentMode,
                        payment_status = x.PaymentStatus,
                        addby = x.Addby,
                        addon = x.Addon,
                        customer_id = x.Customer.Name,
                        customer_phone = x.CustomerPhone,
                        is_updated = x.IsUpdated,
                        is_deleted = x.IsDeleted,
                        Cash_Amount = x.CashAmount,
                        Online_Amount = x.OnlineAmount,
                        Is_Printed = x.IsPrinted,
                        Service_Charge = x.ServiceCharge,
                    }).ToList();
                }

                ResetPaging(myList);

            }
        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (filter == "")
                    {
                        myList = DB.SaleOrder.GetAll().Select(x => new SaleOrderDTO
                        {
                            id = x.Id,
                            restaurant_id = x.RestaurantId,
                            user_id = x.User.UserName,
                            order_count = x.OrderCount,
                            total = x.Total,
                            date = x.Date,
                            order_date = x.OrderDate,
                            description = x.Description,
                            coupon = x.Coupon,
                            coupon_value = x.CouponValue,
                            coupon_type = x.CouponType,
                            coupon_applies_to = x.CouponAppliesTo,
                            coupon_categories = x.CouponCategories,
                            discount_amount = x.DiscountAmount,
                            discount_desc = x.DiscountDesc,
                            payment_mode = x.PaymentMode,
                            payment_status = x.PaymentStatus,
                            addby = x.Addby,
                            addon = x.Addon,
                            customer_id = x.Customer.Name,
                            customer_phone = x.CustomerPhone,
                            is_updated = x.IsUpdated,
                            is_deleted = x.IsDeleted,
                            Cash_Amount = x.CashAmount,
                            Online_Amount = x.OnlineAmount,
                            Is_Printed = x.IsPrinted,
                            Service_Charge = x.ServiceCharge,
                        }).ToList();

                    }
                    else
                    {

                        {

                            if (t.Name == "GridCName")
                            {
                                myList = DB.SaleOrder.GetAll().Where(x => x.Customer.Name.ToUpper().StartsWith(filter.ToUpper())).Select(x => new SaleOrderDTO
                                {
                                    id = x.Id,
                                    restaurant_id = x.RestaurantId,
                                    user_id = x.User.UserName,
                                    order_count = x.OrderCount,
                                    total = x.Total,
                                    date = x.Date,
                                    order_date = x.OrderDate,
                                    description = x.Description,
                                    coupon = x.Coupon,
                                    coupon_value = x.CouponValue,
                                    coupon_type = x.CouponType,
                                    coupon_applies_to = x.CouponAppliesTo,
                                    coupon_categories = x.CouponCategories,
                                    discount_amount = x.DiscountAmount,
                                    discount_desc = x.DiscountDesc,
                                    payment_mode = x.PaymentMode,
                                    payment_status = x.PaymentStatus,
                                    addby = x.Addby,
                                    addon = x.Addon,
                                    customer_id = x.Customer.Name,
                                    customer_phone = x.CustomerPhone,
                                    is_updated = x.IsUpdated,
                                    is_deleted = x.IsDeleted,
                                    Cash_Amount = x.CashAmount,
                                    Online_Amount = x.OnlineAmount,
                                    Is_Printed = x.IsPrinted,
                                    Service_Charge = x.ServiceCharge,
                                }).ToList(); ;
                            }
                            if (t.Name == "GridPhone")
                            {
                                myList = DB.SaleOrder.GetAll().Where(x => x.CustomerPhone.ToUpper().StartsWith(filter.ToUpper())).Select(x => new SaleOrderDTO
                                {
                                    id = x.Id,
                                    restaurant_id = x.RestaurantId,
                                    user_id = x.User.UserName,
                                    order_count = x.OrderCount,
                                    total = x.Total,
                                    date = x.Date,
                                    order_date = x.OrderDate,
                                    description = x.Description,
                                    coupon = x.Coupon,
                                    coupon_value = x.CouponValue,
                                    coupon_type = x.CouponType,
                                    coupon_applies_to = x.CouponAppliesTo,
                                    coupon_categories = x.CouponCategories,
                                    discount_amount = x.DiscountAmount,
                                    discount_desc = x.DiscountDesc,
                                    payment_mode = x.PaymentMode,
                                    payment_status = x.PaymentStatus,
                                    addby = x.Addby,
                                    addon = x.Addon,
                                    customer_id = x.Customer.Name,
                                    customer_phone = x.CustomerPhone,
                                    is_updated = x.IsUpdated,
                                    is_deleted = x.IsDeleted,
                                    Cash_Amount = x.CashAmount,
                                    Online_Amount = x.OnlineAmount,
                                    Is_Printed = x.IsPrinted,
                                    Service_Charge = x.ServiceCharge,
                                }).ToList(); ;


                            }
                            if (t.Name == "GridOrderDate")
                            {
                                myList = DB.SaleOrder.GetAll().Where(x => x.OrderDate.ToString().ToUpper().StartsWith(filter.ToUpper())).Select(x => new SaleOrderDTO
                                {
                                    id = x.Id,
                                    restaurant_id = x.RestaurantId,
                                    user_id = x.User.UserName,
                                    order_count = x.OrderCount,
                                    total = x.Total,
                                    date = x.Date,
                                    order_date = x.OrderDate,
                                    description = x.Description,
                                    coupon = x.Coupon,
                                    coupon_value = x.CouponValue,
                                    coupon_type = x.CouponType,
                                    coupon_applies_to = x.CouponAppliesTo,
                                    coupon_categories = x.CouponCategories,
                                    discount_amount = x.DiscountAmount,
                                    discount_desc = x.DiscountDesc,
                                    payment_mode = x.PaymentMode,
                                    payment_status = x.PaymentStatus,
                                    addby = x.Addby,
                                    addon = x.Addon,
                                    customer_id = x.Customer.Name,
                                    customer_phone = x.CustomerPhone,
                                    is_updated = x.IsUpdated,
                                    is_deleted = x.IsDeleted,
                                    Cash_Amount = x.CashAmount,
                                    Online_Amount = x.OnlineAmount,
                                    Is_Printed = x.IsPrinted,
                                    Service_Charge = x.ServiceCharge,
                                }).ToList(); ;


                            }
                            if (t.Name == "GridOrderAmount")
                            {
                                myList = DB.SaleOrder.GetAll().Where(x => x.CashAmount.ToString().ToUpper().StartsWith(filter.ToUpper())).Select(x => new SaleOrderDTO
                                {
                                    id = x.Id,
                                    restaurant_id = x.RestaurantId,
                                    user_id = x.User.UserName,
                                    order_count = x.OrderCount,
                                    total = x.Total,
                                    date = x.Date,
                                    order_date = x.OrderDate,
                                    description = x.Description,
                                    coupon = x.Coupon,
                                    coupon_value = x.CouponValue,
                                    coupon_type = x.CouponType,
                                    coupon_applies_to = x.CouponAppliesTo,
                                    coupon_categories = x.CouponCategories,
                                    discount_amount = x.DiscountAmount,
                                    discount_desc = x.DiscountDesc,
                                    payment_mode = x.PaymentMode,
                                    payment_status = x.PaymentStatus,
                                    addby = x.Addby,
                                    addon = x.Addon,
                                    customer_id = x.Customer.Name,
                                    customer_phone = x.CustomerPhone,
                                    is_updated = x.IsUpdated,
                                    is_deleted = x.IsDeleted,
                                    Cash_Amount = x.CashAmount,
                                    Online_Amount = x.OnlineAmount,
                                    Is_Printed = x.IsPrinted,
                                    Service_Charge = x.ServiceCharge,
                                }).ToList(); ;


                            }
                            if (t.Name == "GridUser")
                            {
                                myList = DB.SaleOrder.GetAll().Where(x => x.User.Name.ToUpper().StartsWith(filter.ToUpper())).Select(x => new SaleOrderDTO
                                {
                                    id = x.Id,
                                    restaurant_id = x.RestaurantId,
                                    user_id = x.User.UserName,
                                    order_count = x.OrderCount,
                                    total = x.Total,
                                    date = x.Date,
                                    order_date = x.OrderDate,
                                    description = x.Description,
                                    coupon = x.Coupon,
                                    coupon_value = x.CouponValue,
                                    coupon_type = x.CouponType,
                                    coupon_applies_to = x.CouponAppliesTo,
                                    coupon_categories = x.CouponCategories,
                                    discount_amount = x.DiscountAmount,
                                    discount_desc = x.DiscountDesc,
                                    payment_mode = x.PaymentMode,
                                    payment_status = x.PaymentStatus,
                                    addby = x.Addby,
                                    addon = x.Addon,
                                    customer_id = x.Customer.Name,
                                    customer_phone = x.CustomerPhone,
                                    is_updated = x.IsUpdated,
                                    is_deleted = x.IsDeleted,
                                    Cash_Amount = x.CashAmount,
                                    Online_Amount = x.OnlineAmount,
                                    Is_Printed = x.IsPrinted,
                                    Service_Charge = x.ServiceCharge,
                                }).ToList(); ;

                            }
                            
                        };
                    }
                    ResetPaging(myList);
                }
            }

        }

        private void btnSaleOrderDetail_Click(object sender, RoutedEventArgs e)
        {

            EZYPOS.DTO.SaleOrderDTO SaleOrder = (EZYPOS.DTO.SaleOrderDTO)SaleOrderGrid.SelectedItem;
            WindowSaleOrderDetail SaleOrderDetail = new WindowSaleOrderDetail(SaleOrder);
            SaleOrderDetail.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHome("");
        }

        #region Pagination

        private void ResetPaging(List<SaleOrderDTO> ListTopagenate)
        {
            SaleOrderGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            SaleOrderGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            SaleOrderGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            SaleOrderGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            SaleOrderGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }


        #endregion
    }
}