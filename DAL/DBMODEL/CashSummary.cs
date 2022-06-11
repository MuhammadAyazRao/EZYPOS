using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class CashSummary
    {
        public int Id { get; set; }
        public decimal? StartAmount { get; set; }
        public decimal? EndAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public string StartedBy { get; set; }
        public string EndedBy { get; set; }
        public string Posid { get; set; }
    }
}
