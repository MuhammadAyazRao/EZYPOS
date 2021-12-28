using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class ProductLedgerDTO
    {
        public DateTime? TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDetail { get; set; }
        public string ProductN { get; set; }
        public decimal? DR { get; set; }
        public decimal? CR { get; set; }
        

    }
}
