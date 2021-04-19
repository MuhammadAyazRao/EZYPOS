using DAL.DBModel;
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
            Customers = new CustomerRepository(_context);
            City = new Repository<City>(_context);
            UserRole= new Repository<UserRole>(_context);
            UserPage = new Repository<UserPage>(_context);
            Employee = new Repository<Emplyee>(_context);
            ExpenceType = new Repository<ExpenceType>(_context);
            ProductCategory= new Repository<ProductCategory>(_context);
            ProductSubcategory = new Repository<ProductSubcategory>(_context);
            ProductGroup= new Repository<ProductGroup>(_context);
            Product= new Repository<Product>(_context);
            Supplier= new Repository<Supplier>(_context);

        }
        public IRepository<City> City { get; }
        public ICustomerRepository Customers { get; }
        public IRepository<UserPage> UserPage { get; }
        public IRepository<UserRole> UserRole { get; }
        public IRepository<Emplyee> Employee { get; }
        public IRepository<ExpenceType> ExpenceType { get; }
        public IRepository<ProductCategory> ProductCategory { get; }
        public IRepository<ProductSubcategory> ProductSubcategory { get; }
        public IRepository<ProductGroup> ProductGroup { get; }
        public IRepository<Product> Product { get; }
        public IRepository<Supplier> Supplier { get; }

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
