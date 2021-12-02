using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class User
    {
        public User()
        {
            CustomerReceipts = new HashSet<CustomerReceipt>();
            SupplierPayments = new HashSet<SupplierPayment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }

        public virtual UserRole UserRoleNavigation { get; set; }
        public virtual ICollection<CustomerReceipt> CustomerReceipts { get; set; }
        public virtual ICollection<SupplierPayment> SupplierPayments { get; set; }
    }
}
