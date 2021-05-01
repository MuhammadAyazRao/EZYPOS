using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class StockOderDetail
    {
        public long Id { get; set; }
        public long StockId { get; set; }
        public int OrderDetailId { get; set; }
        public int Qty { get; set; }
        public int ProductId { get; set; }
        public int? OrderId { get; set; }

        public virtual SaleOrderDetail OrderDetail { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductStock Stock { get; set; }
    }
}
