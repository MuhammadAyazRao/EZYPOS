using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
   public  class SaleOrderDTO
    {
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public string user_id { get; set; }
        public int order_count { get; set; }
        public long total { get; set; }
        public DateTime? date { get; set; }
        public DateTime? order_date { get; set; }
        public string description { get; set; }
        public string coupon { get; set; }
        public string coupon_value { get; set; }
        public string coupon_type { get; set; }
        public string coupon_applies_to { get; set; }
        public string coupon_categories { get; set; }
        public long? discount_amount { get; set; }
        public string discount_desc { get; set; }
        public string payment_mode { get; set; }
        public string payment_status { get; set; }
        public string addby { get; set; }
        public string addon { get; set; }
        public string customer_id { get; set; }
        public string customer_phone { get; set; }
        public string is_updated { get; set; }
        public string is_deleted { get; set; }
        public long Cash_Amount { get; set; }
        public long Online_Amount { get; set; }
        public int Is_Printed { get; set; }
        public long? Service_Charge { get; set; }

    }
}
