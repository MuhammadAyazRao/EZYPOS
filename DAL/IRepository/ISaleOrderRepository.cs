﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using DAL.DBModel;

namespace DAL.IRepository
{
    public interface ISaleOrderRepository: IRepository<SaleOrder>
    {
        IEnumerable<SaleOrder> GetAllCyCustomer();
         bool SaveOrder(Order CartOrderToProcess);
        List<Order> GetMappedOrder(int id);
        bool DeleteOrder(int id);
        // List<Order> GetMappedOrderbyid(int id);


    }
}