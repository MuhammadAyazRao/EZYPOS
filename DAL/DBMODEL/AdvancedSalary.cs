using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class AdvancedSalary
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? PayedBy { get; set; }
        public DateTime? Date { get; set; }
        public int Month { get; set; }
        public long? Amount { get; set; }

        public virtual Emplyee Employee { get; set; }
        public virtual Emplyee PayedByNavigation { get; set; }
    }
}
