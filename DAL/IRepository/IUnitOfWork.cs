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

        int Complete();
    }
}
