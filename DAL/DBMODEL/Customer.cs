using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerDrnotes = new HashSet<CustomerDrnote>();
            CustomerReceipts = new HashSet<CustomerReceipt>();
            SaleOrders = new HashSet<SaleOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Adress { get; set; }
        public int? City { get; set; }
        public string MobileNo { get; set; }
        public DateTime? Createdon { get; set; }
        public decimal? RewardPoints { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual ICollection<CustomerDrnote> CustomerDrnotes { get; set; }
        public virtual ICollection<CustomerReceipt> CustomerReceipts { get; set; }
        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
    }
}
