using DAL.DBMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class PriceRuleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Type { get; set; }
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
        public string RuleType { get; set; }
    }
}
