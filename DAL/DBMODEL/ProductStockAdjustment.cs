using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class ProductStockAdjustment
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public int? Added { get; set; }
        public int? Subtracted { get; set; }
        public long StockId { get; set; }
    }
}
