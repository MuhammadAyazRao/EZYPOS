using DAL.DBMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetBestCustomers(int amountOfCustomers);
    }
}
