using System;
using System.Collections.Generic;

#nullable disable

namespace EZYPOS.DBModels
{
    public partial class ShopSetting
    {
        public int Id { get; set; }
        public int? Pin { get; set; }
        public int? ShopId { get; set; }
        public string ShopName { get; set; }
    }
}
