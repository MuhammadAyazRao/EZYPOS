using Common.DTO;
using DAL.DBMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IStockRepository: IRepository<ProductStock>
    {
        List<StockDetailDTO> GetStockDetailToAdjust(int Qty, int? ProductId);
        bool SaveStockAdjustment(Order Order, int OrderDetailId, int OrderId);
        int GetProductQty(int ProductId);
        List<StockDetailDTO> GetStockDetail();
        // List<long?> GetStockDetailToAdjust(int Qty, int ProductId);
    }
}
