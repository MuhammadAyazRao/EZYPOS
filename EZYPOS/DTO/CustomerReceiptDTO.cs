using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class CustomerReceiptDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Discription { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Customer { get; set; }
        public string Employee { get; set; }
    }
}
