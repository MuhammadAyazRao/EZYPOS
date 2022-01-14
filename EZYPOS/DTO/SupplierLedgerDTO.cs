using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class SupplierLedgerDTO
    {
        public string SupplierName { get; set; }
        public DateTime Date { get; set; }
        public string TransactionType { get; set; }
        public string Detail { get; set; }
        public decimal? CR { get; set; }
        public decimal? DR { get; set; }
        public decimal? Balance { get; set; }
    }
}
