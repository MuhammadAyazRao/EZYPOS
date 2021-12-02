using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class SupplierLead
    {
        public int Id { get; set; }
        public int? SuplierId { get; set; }
        public int? TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDet { get; set; }
        public decimal? Dr { get; set; }
        public decimal? Cr { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
