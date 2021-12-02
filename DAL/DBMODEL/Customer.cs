using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerReceipts = new HashSet<CustomerReceipt>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Adress { get; set; }
        public int? City { get; set; }
        public string MobileNo { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual ICollection<CustomerReceipt> CustomerReceipts { get; set; }
    }
}
