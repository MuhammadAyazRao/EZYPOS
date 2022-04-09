using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class PurchaseOrderDetail
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ProductId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int Qty { get; set; }
        public int? StockId { get; set; }
        public int PurchaseOrderId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? ItemDiscount { get; set; }
        public decimal? Total { get; set; }
    }
}
