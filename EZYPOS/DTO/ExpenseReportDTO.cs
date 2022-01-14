using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class ExpenseReportDTO
    {
        public string ExpenseDate { get; set; }
        public string CreateBy { get; set; }
        public string Discription { get; set; }
        public string Amount { get; set; }
        public string ExpenseType { get; set; }
    }
}
