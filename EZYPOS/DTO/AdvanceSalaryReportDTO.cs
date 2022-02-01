using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class AdvanceSalaryReportDTO
    {
        public string Employee { get; set; }
        public string PayedBy { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
    }
}
