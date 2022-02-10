using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class SupplierCrnote
    {
        public int Id { get; set; }
        public string Discription { get; set; }
        public string ReceiptAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int SupplierId { get; set; }
        public int PayedBy { get; set; }
        public int? UserId { get; set; }

        public virtual Emplyee PayedByNavigation { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
