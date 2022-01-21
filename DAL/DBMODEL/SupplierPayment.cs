using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class SupplierPayment
    {
        public int Id { get; set; }
        public int? Amount { get; set; }
        public string Discription { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? SupplierId { get; set; }
        public int? EmployeeId { get; set; }
        public int? UserId { get; set; }

        public virtual Emplyee Employee { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
    }
}
