using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class PriceRulePriceBreak
    {
        public int Id { get; set; }
        public int RuleId { get; set; }
        public int? ItemsToBuy { get; set; }
        public decimal? PercentOff { get; set; }
        public decimal? FixedOff { get; set; }

        public virtual PriceRule Rule { get; set; }
    }
}
