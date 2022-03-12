using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class AdvanceSalaryDTO
    {
        public int Id { get; set; }
        public string Employee { get; set; }
        public string PayedBy { get; set; }
        public DateTime? Date { get; set; }
        public string Month { get; set; }
        public decimal? Amount { get; set; }

    }
}
