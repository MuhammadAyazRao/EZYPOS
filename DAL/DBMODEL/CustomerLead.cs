using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class CustomerLead
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int? TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDetail { get; set; }
        public decimal? Dr { get; set; }
        public decimal? Cr { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
