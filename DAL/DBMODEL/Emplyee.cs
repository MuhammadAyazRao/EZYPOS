using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class Emplyee
    {
        public Emplyee()
        {
            AdvancedSalaryEmployees = new HashSet<AdvancedSalary>();
            AdvancedSalaryPayedByNavigations = new HashSet<AdvancedSalary>();
            CustomerDrnotes = new HashSet<CustomerDrnote>();
            CustomerReceipts = new HashSet<CustomerReceipt>();
            ExpenceTransactions = new HashSet<ExpenceTransaction>();
            PurchaseOrders = new HashSet<PurchaseOrder>();
            SaleOrders = new HashSet<SaleOrder>();
            SupplierCrnotes = new HashSet<SupplierCrnote>();
            SupplierPayments = new HashSet<SupplierPayment>();
            UserPages = new HashSet<UserPage>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public int? Role { get; set; }
        public int? City { get; set; }
        public string Cnic { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public bool? Isdeleted { get; set; }
        public DateTime? Createdon { get; set; }
        public string Password { get; set; }
        public bool? IsLoginAllowed { get; set; }
        public long? Salary { get; set; }
        public string SalaryType { get; set; }
        public decimal? WorkingHours { get; set; }
        public string Image { get; set; }
        public string LoginName { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual UserRole RoleNavigation { get; set; }
        public virtual ICollection<AdvancedSalary> AdvancedSalaryEmployees { get; set; }
        public virtual ICollection<AdvancedSalary> AdvancedSalaryPayedByNavigations { get; set; }
        public virtual ICollection<CustomerDrnote> CustomerDrnotes { get; set; }
        public virtual ICollection<CustomerReceipt> CustomerReceipts { get; set; }
        public virtual ICollection<ExpenceTransaction> ExpenceTransactions { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
        public virtual ICollection<SupplierCrnote> SupplierCrnotes { get; set; }
        public virtual ICollection<SupplierPayment> SupplierPayments { get; set; }
        public virtual ICollection<UserPage> UserPages { get; set; }
    }
}
