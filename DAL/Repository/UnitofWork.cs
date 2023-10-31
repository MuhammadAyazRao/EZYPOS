using DAL.DBMODEL;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EPOSDBContext _context;

        public UnitOfWork(EPOSDBContext context)
        {
            _context = context;           
            City = new Repository<City>(_context);
            Shelf = new Repository<TblShelf>(_context);
            MUnit = new Repository<Unit>(_context);
            CustomerDRNote = new Repository<CustomerDrnote>(_context);
            SupplierCRNote = new Repository<SupplierCrnote>(_context);
            Setting = new Repository<Setting>(_context);
            CashSummary = new Repository<CashSummary>(_context);
            POS = new Repository<Po>(_context);
            AdvanceSalary = new Repository<AdvancedSalary>(_context);
            SupplierPayment = new Repository<SupplierPayment>(_context);
            User = new Repository<User>(_context);
            CustomerReceipt = new Repository<CustomerReceipt>(_context);
            Pages = new Repository<Page>(_context);
            expt = new Repository<ExpenceTransaction>(_context);
            Account = new Repository<Account>(_context);
            Customers = new CustomerRepository(_context);
            UserRole = new Repository<UserRole>(_context);
            UserPage = new Repository<UserPage>(_context);
            Employee = new Repository<Emplyee>(_context);
            ExpenceType = new Repository<ExpenceType>(_context);
            ProductCategory= new Repository<ProductCategory>(_context);
            ProductSubcategory = new Repository<ProductSubcategory>(_context);
            ProductGroup= new Repository<ProductGroup>(_context);
            Product= new Repository<Product>(_context);
            shopSettings = new Repository<ShopSetting>(_context);
            Supplier= new Repository<Supplier>(_context);
            SaleOrder = new SaleOrderRepository(_context);
            Stock = new StockRepository(_context);
            PriceRule = new Repository<PriceRule>(_context);
            SaleOrderDetail = new Repository<SaleOrderDetail>(_context);
            StockOderDetail= new Repository<StockOderDetail>(_context);
            PurchaseOrderDetail = new Repository<PurchaseOrderDetail>(_context);
            PurchaseOrder = new PurchaseOrderRpository(_context);
            ProductStock = new Repository<ProductStock>(_context);
            StockLeader = new Repository<StockLead>(_context);
            CustomerLead = new Repository<CustomerLead>(_context);
            SupplierLead = new Repository<SupplierLead>(_context);
            CashBookLead = new Repository<CashBookLead>(_context);

        }
        public  IRepository<Page> Pages { get; }
        public IRepository<SupplierLead> SupplierLead { get; }
        public IRepository<CustomerLead> CustomerLead { get; }
        public IRepository<CashBookLead> CashBookLead { get; }
        public IRepository<StockLead> StockLeader { get; }
        public IRepository<City> City { get; }
        public IRepository<TblShelf> Shelf { get; }
        public IRepository<Unit> MUnit { get; }
        public IRepository<CustomerDrnote> CustomerDRNote { get; }
        public IRepository<SupplierCrnote> SupplierCRNote { get; }
        public IRepository<Setting> Setting { get; }
        public IRepository<CashSummary> CashSummary { get; }
        public IRepository<Po> POS { get; }

        public IRepository<AdvancedSalary> AdvanceSalary { get; }
        public IRepository<SupplierPayment> SupplierPayment { get; }
        public IRepository<User> User { get; }
        public IRepository<CustomerReceipt> CustomerReceipt { get; }
        public IRepository<ExpenceTransaction> expt { get; }
        public IRepository<Account> Account { get; }
        public ICustomerRepository Customers { get; }
        public ISaleOrderRepository SaleOrder { get; }
        
        public IRepository<UserPage> UserPage { get; }
        public IRepository<UserRole> UserRole { get; }
        public IRepository<Emplyee> Employee { get; }
        public IRepository<ExpenceType> ExpenceType { get; }
        public IRepository<ProductCategory> ProductCategory { get; }
        public IRepository<ProductSubcategory> ProductSubcategory { get; }
        public IRepository<ProductGroup> ProductGroup { get; }
        public IRepository<Product> Product { get; }
        public IRepository<ShopSetting> shopSettings { get; }
        public IRepository<Supplier> Supplier { get; }
        public IRepository<PriceRule> PriceRule { get; }
        public IStockRepository Stock { get; }
        public IRepository<SaleOrderDetail> SaleOrderDetail { get; }
        public IRepository<StockOderDetail> StockOderDetail { get; }
        public IRepository<PurchaseOrderDetail> PurchaseOrderDetail { get; }

        public IPurchaseRepository PurchaseOrder { get; }
        public IRepository<ProductStock> ProductStock { get; }

        

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
