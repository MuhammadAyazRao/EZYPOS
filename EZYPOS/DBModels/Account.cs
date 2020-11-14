using System;
using System.Collections.Generic;

#nullable disable

namespace EZYPOS.DBModels
{
    public partial class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Type { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
