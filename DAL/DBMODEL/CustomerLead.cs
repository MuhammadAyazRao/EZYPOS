using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class CustomerLead
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int? TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDetail { get; set; }
        public int? Dr { get; set; }
        public int? Cr { get; set; }
    }
}
