﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class Supplier
    {
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            SupplierLeads = new HashSet<SupplierLead>();
            SupplierPayments = new HashSet<SupplierPayment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Adress { get; set; }
        public int? City { get; set; }
        public string MobileNo { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<SupplierLead> SupplierLeads { get; set; }
        public virtual ICollection<SupplierPayment> SupplierPayments { get; set; }
    }
}
