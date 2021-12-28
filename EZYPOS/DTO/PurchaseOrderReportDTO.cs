using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class PurchaseOrderReportDTO
    {
        public int id { get; set; }
        public string SupplierId { get; set; }
        public DateTime? Date { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMode { get; set; }
        public int? TotalAmount { get; set; }


    }
}
