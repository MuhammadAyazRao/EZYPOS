﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
   public  class SaleOrderDTO
   {
        public int id { get; set; }
        public string Customer { get; set; }
        public string Employee { get; set; }
        public string Date { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentStatus { get; set; }
        public string TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string POS { get; set; }
   }
}
