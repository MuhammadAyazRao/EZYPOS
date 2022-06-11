using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class SaleOrder
    {
        public SaleOrder()
        {
            SaleOrderDetails = new HashSet<SaleOrderDetail>();
        }

        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public string Posid { get; set; }
        public int OrderCount { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Description { get; set; }
        public string Coupon { get; set; }
        public string CouponValue { get; set; }
        public string CouponType { get; set; }
        public string CouponAppliesTo { get; set; }
        public string CouponCategories { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string DiscountDesc { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentStatus { get; set; }
        public string Addby { get; set; }
        public string Addon { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerPhone { get; set; }
        public string IsUpdated { get; set; }
        public string IsDeleted { get; set; }
        public decimal? TaxPercentage { get; set; }
        public decimal? Tax { get; set; }
        public decimal CashAmount { get; set; }
        public decimal OnlineAmount { get; set; }
        public int IsPrinted { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? DeliveryCharges { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Emplyee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SaleOrderDetail> SaleOrderDetails { get; set; }
    }
}
