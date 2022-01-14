using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class CustomerReceipt
    {
        public int Id { get; set; }
        public string Discription { get; set; }
        public int? ReceiptAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? UserId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Emplyee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
