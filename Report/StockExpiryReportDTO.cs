using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    public class StockExpiryReportDTO
    {     

            public int ProductId { get; set; }
            public int ProductName { get; set; }
            public int AvailableQty { get; set; }
            public int CanbeSettled { get; set; }
            public int StockId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime ExpirationDate { get; set; }
        
    }
    public class ReportItem
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Total => Price * Qty;
    }
}
