﻿using Common.Session;
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
       
        
            public string PaymentType { get; set; }
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
            public string diverlyType { get; set; }
            public double DeliverCharges { get; set; }
            public int CustId { get; set; }
            public int OrderCount { get; set; }
            public double Discount { get; set; }
            public double ServiceCharges { get; set; }


            public PurchaseOrderDTO()
            {
                OrderDate = DateTime.Now;
            }

            public double GetTotal()
            {
                if (OrdersDetails == null)
                    return 0;
                return OrdersDetails.Sum(x => x.GetTotal);
            }

            public double GetCouponDiscount()
            {
                if (Coupon != null)
                {
                    double discAmt = 0;
                    if (Coupon != null)
                    {
                        switch (Coupon.type)
                        {
                            case "pound":
                                discAmt = Convert.ToDouble(Coupon.coupon_value);
                                break;
                            case "percentage":
                                discAmt = (GetTotal() / 100) * Convert.ToDouble(Coupon.coupon_value);
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

            public double GetTotalDiscount()
            {
                Recalculatediscount();
                double total = 0;
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

            public double GetNetTotal()
            {
                Recalculatediscount();
                return ((GetTotal() + DeliverCharges + ServiceCharges) - GetCouponDiscount()) - Discount;
            }


        

    }
    public class Purchaseitem
    {
        public int id { get; set; }       
        public string name { get; set; }    
        public long Purchase_price { get; set; }
        public long Sale_price { get; set; }  
        public int sub_cat_id { get; set; }       
        public string status { get; set; }
    }

    public class PurchaseOrderDetail : PropertyHelper
    {

        private int qty;
        private int itemdisc;
        private string note;
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


        public double GetTotal { get { return (GetItemTotal() * Convert.ToDouble(Qty)) - Convert.ToDouble(ItemDiscount); } }

        public double GetCouponDiscount
        {
            get
            {
                double discAmt = 0;
                if (Coupon != null)
                {
                    switch (Coupon.type)
                    {
                        case "pound":
                            discAmt = Convert.ToDouble(Coupon.coupon_value);
                            break;
                        case "percentage":
                            discAmt = (Item.price / 100) * Convert.ToDouble(Coupon.coupon_value);
                            break;
                    }
                }
                return discAmt;
            }
        }

      

        public double GetItemTotal()
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
}
