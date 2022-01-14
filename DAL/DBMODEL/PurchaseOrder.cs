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
        public DateTime Date { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMode { get; set; }
        public int? TotalAmount { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ProductStock> ProductStocks { get; set; }
    }
}
