using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            ProductStocks = new HashSet<ProductStock>();
        }

        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int? EmployeeId { get; set; }
        public int? UserId { get; set; }
        public DateTime Date { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMode { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DeliveryCharges { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual Emplyee Employee { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Unit User { get; set; }
        public virtual ICollection<ProductStock> ProductStocks { get; set; }
    }
}
