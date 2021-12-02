using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class ExpenseTransactionDTO
    {
        public int Id { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int CreateBy { get; set; }
        public string Discription { get; set; }
        public int Amount { get; set; }
        public bool Isdeleted { get; set; }
        public string ExpenseType { get; set; }

    }
}
