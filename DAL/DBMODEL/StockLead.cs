using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class StockLead
    {
        public int Id { get; set; }
        public long? TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDetail { get; set; }
        public long? ProductId { get; set; }
        public decimal? DrQty { get; set; }
        public decimal? CrQty { get; set; }
        public long? UserId { get; set; }
        public long? PosId { get; set; }
    }
}
