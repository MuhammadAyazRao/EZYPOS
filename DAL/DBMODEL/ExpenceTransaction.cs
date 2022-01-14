using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class ExpenceTransaction
    {
        public int Id { get; set; }
        public DateTime? ExpenceDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? CreatedBy { get; set; }
        public string Discription { get; set; }
        public long? Amount { get; set; }
        public bool? Isdeleted { get; set; }
        public int? ExpenceType { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual Emplyee Employee { get; set; }
        public virtual ExpenceType ExpenceTypeNavigation { get; set; }
    }
}
