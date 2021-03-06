﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EZYPOS.DBModels
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Adress { get; set; }
        public int? City { get; set; }
        public string MobileNo { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual City CityNavigation { get; set; }
    }
}
