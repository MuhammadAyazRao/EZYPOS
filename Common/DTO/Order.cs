using Common.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class Order
    {
        public string PaymentType = Common.OrderEnums.PaymentType.CASH;
        public int OrderId { get; set; }
        public List<OrderDetail> OrdersDetails { get; set; }
        public DateTime OrderDate { get; set; }
        public coupon Coupon { get; set; }
        public int OrderStatusNo { get; set; }
        public string OrderType { get; set; }
        public bool IsPreOrder { get; set; }
        public string Token { get; set; }
        public string Instrictions { get; set; }
        public string payment_status { get; set; }
        public string diverlyType { get;  set; }
        public decimal DeliverCharges { get; set; }
        public int CustId { get;  set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal Tax { get; set; }
        public decimal OrderCount { get;  set; }
        public decimal Discount { get;  set; }
        public decimal ServiceCharges { get; set; }
        public bool? IsUpdated { get; set; }
        public bool? IsDeleted { get; set; }
        public string? OrderStatus { get; set; }
        public int ParenOrderId { get; set; }
        public string POS { get; set; }
        public bool RewardRedeemed { get; set; }


        public Order()
        {
            OrderDate = DateTime.Now;
        }

        public decimal GetTotal()
        {
            if (OrdersDetails == null)
                return 0;
            return OrdersDetails.Sum(x => x.GetTotal);
        }

        public decimal GetCouponDiscount()
        {
            if (Coupon != null)
            {
                decimal discAmt = 0;
                if (Coupon != null)
                {
                    switch (Coupon.type)
                    {
                        case "pound":
                            discAmt = Convert.ToDecimal(Coupon.coupon_value);
                            break;
                        case "percentage":
                            discAmt = (GetTotal() / 100) * Convert.ToDecimal(Coupon.coupon_value);
                            break;
                        case "free_shipping":
                            //todo after calculating delivory charges
                            break;
                    }
                }
                return discAmt;
            }
            return 0;
        }

        public decimal GetTotalDiscount()
        {
            Recalculatediscount();
            decimal total = 0;
            if (OrdersDetails != null)
                foreach (OrderDetail or in OrdersDetails)
                {
                    total += or.GetCouponDiscount;
                }
            return total + GetCouponDiscount() + Discount;
        }


        public void Recalculatediscount()
        {

            if (ActiveSession.order_Discount_percentage != 0)
            {
                Discount = (ActiveSession.order_Discount_percentage / 100) * GetTotal();
            }

        }

        public decimal GetNetTotal()
        {
            Recalculatediscount();
            return ((GetTotal() + DeliverCharges + ServiceCharges) - GetCouponDiscount()) - Discount;
        }

    public object GetTotalRewardPoints() {
      if (OrdersDetails == null)
        return 0;
      return OrdersDetails.Sum(x => x.Item.reward_points*x.Qty);
    }
  }
    public class OrderDetail : PropertyHelper
    {

        private int qty;
        private decimal itemdisc;
        private string note;
        private int seletedHeight;
        private int normalHeight;
        private string noteVisibilty;
        private bool? isMiscItem;
        private coupon coupon;
        internal string subCategory;
        internal int? subCategoryId;
        public int? OrderId;

        public OrderDetail()
        {
            Qty = 1;
            SeletectedHeight = 100;
            NormalHeight = 30;
            itemdisc = 0;



        }

        //public string Note
        //{
        //    get { return note; }
        //    set
        //    {
        //        note = value;
        //        OnPropertyChanged("Note");

        //    }
        //}


        public coupon Coupon
        {
            get { return coupon; }
            set
            {
                coupon = value;
                OnPropertyChanged("GetCouponDiscount");
                OnPropertyChanged("DiscVisibility");
            }
        }

        public bool? IsMiscItem
        {
            get { return isMiscItem; }
            set { isMiscItem = value; }
        }

        public item Item { get; set; }


        public int NormalHeight
        {
            get
            {
                return normalHeight;
            }
            set
            {

                normalHeight = value;
                OnPropertyChanged("NormalHeight");
            }

        }

        public int SeletectedHeight
        {
            get { return seletedHeight; }
            set
            {
                seletedHeight = value;
                OnPropertyChanged("SeletectedHeight");
            }
        }

        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged("Note");
                OnPropertyChanged("NoteVisibility");
                OnPropertyChanged("NormalHeight");
            }
        }

        public int Qty
        {
            get { return qty; }
            set
            {
                qty = value;
                OnPropertyChanged("GetTotal");
                OnPropertyChanged("GetCouponDiscount");
                OnPropertyChanged("Qty");
            }
        }

        public decimal ItemDiscount
        {
            get { return itemdisc; }
            set
            {
                itemdisc = value;
                OnPropertyChanged("GetTotal");
                OnPropertyChanged("GetCouponDiscount");
                OnPropertyChanged("ItemDiscount");
            }
        }


        public decimal GetTotal { get { return (GetItemTotal() * Convert.ToDecimal(Qty)) - ItemDiscount; } }

        public decimal GetCouponDiscount
        {
            get
            {
                decimal discAmt = 0;
                if (Coupon != null)
                {
                    switch (Coupon.type)
                    {
                        case "pound":
                            discAmt = Convert.ToDecimal(Coupon.coupon_value);
                            break;
                        case "percentage":
                            discAmt = (Item.price / 100) * Convert.ToDecimal(Coupon.coupon_value);
                            break;
                    }
                }
                return discAmt;
            }
        }

        //public List<addon_item> GetAddOnItem
        //{
        //    get
        //    {
        //        List<addon_item> it = new List<addon_item>();
        //        if (AdonItems != null)
        //            foreach (List<addon_item> ao in AdonItems)
        //                it.AddRange(ao);
        //        return it;
        //    }
        //}

        public decimal GetItemTotal()
        {
            return Item.price;
        }

        #region Visibility Control code
        public string DiscVisibility
        {
            get
            {
                if (Coupon != null)
                {
                    NormalHeight += 20;
                    return "Visible";
                }
                return "Collapsed";
            }
        }
        public string NoteVisibility
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Note))
                {
                    if (noteVisibilty == "Collapsed")
                        NormalHeight += 60;
                    else
                        NormalHeight = NormalHeight;
                    noteVisibilty = "Visible";
                    return "Visible";
                }
                noteVisibilty = "Collapsed";
                return "Collapsed";
            }
        }

        #endregion

    }
    public class PropertyHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
    public class coupon
    {
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public string code { get; set; }
        public string coupon_value { get; set; }
        public string type { get; set; }
        public string coupon_for { get; set; }
        public string applies_to { get; set; }
        public string categories { get; set; }
        public int code_limit { get; set; }
        public int per_customer_limit { get; set; }
        public System.DateTime valid_from { get; set; }
        public System.DateTime expires_on { get; set; }
        public string details { get; set; }
        public int code_use_counter { get; set; }
        public int minimum_order_amount { get; set; }
    }
    public class item
    {
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string fixed_items { get; set; }
        public decimal price { get; set; }
        public decimal PurchasePrice { get; set; }
        public string TaxType { get; set; }
        public decimal Tax { get; set; }

        public double epos_price { get; set; }
        public string days { get; set; }
        public string pic { get; set; }
        public string allow_coupon { get; set; }
        public Nullable<int> sort_order { get; set; }
        public string bg_color { get; set; }
        public string text_color { get; set; }
        public int sub_cat_id { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public int addon_item_id { get; set; }
        public string kitchen_lines { get; set; }
        public string addon_display_inline { get; set; }
        public string status { get; set; }
        public decimal reward_points { get; set; }
    }  
}
