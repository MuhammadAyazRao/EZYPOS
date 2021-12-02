using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class City
    {
        public City()
        {
            Customers = new HashSet<Customer>();
            Emplyees = new HashSet<Emplyee>();
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Emplyee> Emplyees { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
