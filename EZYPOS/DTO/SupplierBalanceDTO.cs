using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class SupplierBalanceDTO
    {
        public string SupplierName { get; set; }
        public string Date { get; set; }
        public string TransactionType { get; set; }
        public string Detail { get; set; }
        public string CR { get; set; }
        public string DR { get; set; }
        public string Balance { get; set; }
    }
}
