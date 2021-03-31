using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class SaleOrder
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public int OrderCount { get; set; }
        public long Total { get; set; }
        public DateTime Date { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Description { get; set; }
        public string Coupon { get; set; }
        public string CouponValue { get; set; }
        public string CouponType { get; set; }
        public string CouponAppliesTo { get; set; }
        public string CouponCategories { get; set; }
        public long? DiscountAmount { get; set; }
        public string DiscountDesc { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentStatus { get; set; }
        public string Addby { get; set; }
        public string Addon { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string IsUpdated { get; set; }
        public string IsDeleted { get; set; }
        public long CashAmount { get; set; }
        public long OnlineAmount { get; set; }
        public int IsPrinted { get; set; }
        public long? ServiceCharge { get; set; }
    }
}
