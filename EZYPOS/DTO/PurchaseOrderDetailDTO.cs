using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class PurchaseOrderDetailDTO
    {
        public string ItemName { get; set; }
        public string PurchasePrice { get; set; }
        public string Qty { get; set; }
        public string Total { get; set; }
    }
}
