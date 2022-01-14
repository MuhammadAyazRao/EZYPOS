using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using DAL.DBMODEL;

namespace DAL.IRepository
{
    public interface ISaleOrderRepository: IRepository<SaleOrder>
    {
        IEnumerable<SaleOrder> GetAllCyCustomer();
         bool SaveOrder(Order CartOrderToProcess);
        List<Order> GetMappedOrder(int id=0);
        bool DeleteOrder(int id);
        // List<Order> GetMappedOrderbyid(int id);


    }
}
