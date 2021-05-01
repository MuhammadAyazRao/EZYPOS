using DAL.DBModel;
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
        IRepository<UserPage> UserPage { get; }
        IRepository<UserRole> UserRole { get; }
        IRepository<Emplyee> Employee { get; }
        IRepository<ExpenceType> ExpenceType { get; }
        IRepository<ProductCategory> ProductCategory { get; }
        IRepository<ProductSubcategory> ProductSubcategory { get; }
        IRepository<ProductGroup> ProductGroup { get; }
        IRepository<Product> Product { get; }
        IRepository<SaleOrderDetail> SaleOrderDetail { get; }
        ISaleOrderRepository SaleOrder { get; }
        IStockRepository Stock { get; }
        IRepository<StockOderDetail> StockOderDetail { get; }

        int Complete();
    }
}
