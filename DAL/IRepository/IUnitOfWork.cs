﻿using DAL.DBMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IRepository<City> City { get; }
        IRepository<ExpenceTransaction> expt { get; }
        IRepository<TblShelf> Shelf { get; }
        IRepository<Unit> MUnit { get; }
        IRepository<CustomerDrnote> CustomerDRNote { get; }
        IRepository<SupplierCrnote> SupplierCRNote { get; }
        IRepository<Setting> Setting { get; }
        IRepository<CashSummary> CashSummary { get; }
        IRepository<Po> POS { get; }
        IRepository<AdvancedSalary> AdvanceSalary { get; }
        IRepository<SupplierPayment> SupplierPayment { get; }
        IRepository<Supplier> Supplier { get; }
        IRepository<User> User { get; }
        IRepository<CustomerReceipt> CustomerReceipt { get; }
        IRepository<UserPage> UserPage { get; }
        IRepository<UserRole> UserRole { get; }
        IRepository<Emplyee> Employee { get; }
        IRepository<ExpenceType> ExpenceType { get; }
        IRepository<ProductCategory> ProductCategory { get; }
        IRepository<Page> Pages { get; }
        IRepository<ProductSubcategory> ProductSubcategory { get; }
        IRepository<ProductGroup> ProductGroup { get; }
        IRepository<Product> Product { get; }
        IRepository<ShopSetting> shopSettings { get; }
        IRepository<SaleOrderDetail> SaleOrderDetail { get; }
        IRepository<PriceRule> PriceRule { get; }
        IRepository<PriceRulePriceBreak> PriceRulePriceBreak { get; }
        ISaleOrderRepository SaleOrder { get; }
        IStockRepository Stock { get; }
        IRepository<StockOderDetail> StockOderDetail { get; }
        IRepository<PurchaseOrderDetail> PurchaseOrderDetail { get; }
        IPurchaseRepository PurchaseOrder { get; }

        int Complete();
    }
}
