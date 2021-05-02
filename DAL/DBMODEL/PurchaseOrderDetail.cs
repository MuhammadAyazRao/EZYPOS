using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class PurchaseOrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PurchasePrice { get; set; }
        public long? SalePrice { get; set; }
        public int Qty { get; set; }
        public int? StockId { get; set; }
        public int PurchaseOrderId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Discount { get; set; }
        public int? Total { get; set; }
    }
}
