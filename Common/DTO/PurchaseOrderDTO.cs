using Common.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class PurchaseOrderDTO
    {


            public string PaymentType = Common.OrderEnums.PaymentType.CASH;
            public int OrderId { get; set; }
            public List<PurchaseOrderDetail> OrdersDetails { get; set; }
            public DateTime OrderDate { get; set; }
            public coupon Coupon { get; set; }
            public int OrderStatusNo { get; set; }
            public string OrderType { get; set; }
            public bool IsPreOrder { get; set; }
            public string Token { get; set; }
            public string Instrictions { get; set; }
            public string payment_status { get; set; }
            public string diverlyType { get; set; }
            public decimal DeliverCharges { get; set; }
            public int SupplierId { get; set; }
            public int EmployeeId { get; set; }
            public int UserId { get; set; }
            public decimal OrderCount { get; set; }
            public decimal Discount { get; set; }
            public decimal ServiceCharges { get; set; }


            public PurchaseOrderDTO()
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
                    foreach (PurchaseOrderDetail or in OrdersDetails)
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


        

    }
    public class Purchaseitem
    {
        public int id { get; set; }       
        public string name { get; set; }    
        public decimal price { get; set; }
        public decimal Sale_price { get; set; }  
        public int sub_cat_id { get; set; }       
        public string status { get; set; }
    }

    public class PurchaseOrderDetail : PropertyHelper
    {

        private int qty;
        private int itemdisc;
        private string note;
        private DateTime startDate=DateTime.Now;
        private DateTime expiryDate = DateTime.Now;
        private int seletedHeight;
        private int normalHeight;
        private string noteVisibilty;
        private bool? isMiscItem;
        private coupon coupon;
        internal string subCategory;
        internal int? subCategoryId;
        public int? OrderId;

        public PurchaseOrderDetail()
        {
            Qty = 1;
            SeletectedHeight = 100;
            NormalHeight = 30;
            itemdisc = 0;



        }

       


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

        public Purchaseitem Item { get; set; }


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

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged("Note");
                OnPropertyChanged("NoteVisibility");
                OnPropertyChanged("NormalHeight");
            }
        }


        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set
            {
                expiryDate = value;
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

        public int ItemDiscount
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


        public decimal GetTotal { get { return (GetItemTotal() * Convert.ToDecimal(Qty)) - Convert.ToDecimal(ItemDiscount); } }

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
        //public string NoteVisibility
        //{
        //    get
        //    {
        //        if (StartDate!=null)
        //        {
        //            if (noteVisibilty == "Collapsed")
        //            {// NormalHeight += 60;
        //             }
        //            else
        //                NormalHeight = NormalHeight;
        //            noteVisibilty = "Visible";
        //            return "Visible";
        //        }
        //        noteVisibilty = "Collapsed";
        //        return "Collapsed";
        //    }
        //}

        #endregion

    }
}
