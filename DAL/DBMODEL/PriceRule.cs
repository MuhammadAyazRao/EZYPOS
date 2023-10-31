using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class PriceRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string Type { get; set; }
        public int? ItemsToBuy { get; set; }
        public int? ItemToGet { get; set; }
        public decimal? PercentOff { get; set; }
        public decimal? FixedOff { get; set; }
        public decimal? SpendAmount { get; set; }
        public int? NumTimesToApply { get; set; }
        public string CoupanCode { get; set; }
        public string Description { get; set; }
        public bool? ShowOnReceipt { get; set; }
        public decimal? CoupanSpendAmount { get; set; }
        public bool? MixAndMatch { get; set; }
        public bool? DisableLoyaltyForRules { get; set; }
    }
}
