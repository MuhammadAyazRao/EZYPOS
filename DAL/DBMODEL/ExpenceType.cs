using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class ExpenceType
    {
        public ExpenceType()
        {
            ExpenceTransactions = new HashSet<ExpenceTransaction>();
        }

        public int Id { get; set; }
        public string ExpenceName { get; set; }
        public bool? Isdeleted { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ICollection<ExpenceTransaction> ExpenceTransactions { get; set; }
    }
}
