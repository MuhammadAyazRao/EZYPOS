using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class ProductStock
    {
        public ProductStock()
        {
            StockOderDetails = new HashSet<StockOderDetail>();
        }

        public long Id { get; set; }
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long Qty { get; set; }
        public int Adjustment { get; set; }
        public int? PurchaseOrderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual ICollection<StockOderDetail> StockOderDetails { get; set; }
    }
}
