﻿using Common.DTO;
using DAL.DBMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IPurchaseRepository : IRepository<PurchaseOrder>
    {
        bool SaveOrder(PurchaseOrderDTO CartOrderToProcess);
        List<PurchaseOrderDTO> GetMappedOrder(int id=0);
        bool DeleteOrder(int id);
    }
}
