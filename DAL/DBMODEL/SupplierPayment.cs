using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class SupplierPayment
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public string Discription { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? PayedBy { get; set; }
        public int? Supplier { get; set; }

        public virtual User PayedByNavigation { get; set; }
        public virtual Supplier SupplierNavigation { get; set; }
    }
}
