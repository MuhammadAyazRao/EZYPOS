using DAL.DBMODEL;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly EPOSDBContext _customerDbEntities;

        public CustomerRepository(EPOSDBContext context) : base(context)
        {
            _customerDbEntities = context;
        }

        public IEnumerable<Customer> GetBestCustomers(int amountOfCustomers)
        {
            if (amountOfCustomers > _customerDbEntities.Customers.ToList().Count)
            {
                throw new IndexOutOfRangeException();
            }

            return _customerDbEntities.Customers.OrderByDescending(x => x.Id).Take(amountOfCustomers).ToList();
        }
    }
}
