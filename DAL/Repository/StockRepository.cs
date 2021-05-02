using Common.DTO;
using DAL.DBModel;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL.Repository
{
    class StockRepository : Repository<ProductStock>, IStockRepository
    {


        private readonly EPOSDBContext _DbEntities;
        IRepository<StockOderDetail> StockOderDetail { get; }
        IRepository<ProductStock> ProductStock { get; }
        IRepository<Product> Product { get; }
        public StockRepository(EPOSDBContext context) : base(context)
        {
            _DbEntities = context;
            StockOderDetail= new Repository<StockOderDetail>(context);
            ProductStock =new  Repository<ProductStock>(context);
            Product = new Repository<Product>(context);
        }

        public List<StockDetailDTO> GetStockDetailToAdjust(int Qty, int? ProductId)
        {
            List<StockDetailDTO> StockList = new List<StockDetailDTO>();
            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
               
                try
                {
                    long? SettledQty = 0;

                    foreach (var item in _DbEntities.ProductStocks.Where(x => x.ProductId == ProductId).ToList())
                    {
                        StockDetailDTO StockDetail = new StockDetailDTO();
                        StockDetail.ProductId = item.ProductId;
                        StockDetail.StockId = (int)item.Id;
                        StockDetail.StartDate = item.StartDate;
                        StockDetail.ExpirationDate = item.ExpiryDate;
                        var Available = item.Qty + (item.Adjustment);
                        foreach (var subitem in _DbEntities.StockOderDetails.Where(x => x.StockId == item.Id).ToList())
                        {
                            Available = Available - subitem.Qty;
                        }
                        if (Available > 0)
                        {
                            if (Qty > SettledQty)
                            {
                                if (Qty-SettledQty >= Available)
                                {
                                    SettledQty += Available;
                                    StockDetail.AvailableQty = (int)Available;
                                    StockDetail.CanbeSettled = (int)Available;
                                }
                                else
                                {
                                    StockDetail.AvailableQty = (int)Available;
                                    StockDetail.CanbeSettled = (int)Qty-(int)SettledQty;
                                    SettledQty+= (int)Qty - (int)SettledQty;

                                }
                                StockList.Add(StockDetail);
                            }
                        }
                       
                    }
                    // var StockInfo=from Stock in _DbEntities.ProductStocks join StockAdj in _DbEntities.ProductStockAdjustments on Stock.ProductId equals StockAdj.StockId join Stock_Order in _DbEntities.StockOderDetails on Stock.Id equals Stock_Order.StockId where Stock.ProductId == ProductId select new { Stock , StockAdj, Stock_Order };
                    //var StockInfo = (from Stock in _DbEntities.ProductStocks join Stock_Order in _DbEntities.StockOderDetails on Stock.Id equals Stock_Order.StockId into gj  from x in gj.DefaultIfEmpty() where Stock.ProductId == ProductId select new { StockQTY = Stock.Qty + (Stock.Adjustment)-(x==null?0:x.Qty) , StockId = Stock.Id,ProductId=Stock.ProductId,StartDate=Stock.StartDate,ExpiryDate=Stock.ExpiryDate }).ToList();

                    //var Adjusted = StockInfo.GroupBy(x => x.StockId).Select(g => new
                    //{
                    //    StockID = g.Key,
                    //    TotalAvailibility = g.Sum(s => s.StockQTY),

                    //}).ToList();



                    //The Transaction will be completed    
                    //scope.Complete();

                }
                catch (Exception ex)
                {
                    //scope.Dispose();
                }
                return StockList;
            }         

        }
        public int GetProductQty(int ProductId)
        {
            long? ToTalStock = 0;
            try
            {
                foreach (var item in _DbEntities.ProductStocks.Where(x => x.ProductId == ProductId).ToList())
                {

                    ToTalStock += item.Qty + (item.Adjustment);
                    foreach (var subitem in _DbEntities.StockOderDetails.Where(x => x.StockId == item.Id).ToList())
                    {
                        ToTalStock = ToTalStock - subitem.Qty;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return (int)ToTalStock;
        }

        public List<StockDetailDTO> GetStockDetail()
        {
            List<StockDetailDTO> StockList = new List<StockDetailDTO>();
            try
            {
                
                    foreach (var item in ProductStock.GetAll().ToList())
                    {
                        long? ToTalStock = 0;
                        StockDetailDTO StockDetail = new StockDetailDTO();
                        StockDetail.ProductId = item.ProductId;
                        StockDetail.ProductName = Product.Get(item.ProductId).ProductName;

                        StockDetail.StockId = (int)item.Id;
                        StockDetail.StartDate = item.StartDate;
                        StockDetail.ExpirationDate = item.ExpiryDate;
                        ToTalStock = item.Qty + (item.Adjustment);
                        foreach (var subitem in StockOderDetail.GetAll().Where(x => x.StockId == item.Id).ToList())
                        {
                            ToTalStock -= subitem.Qty;
                        }
                        StockDetail.AvailableQty = (int)ToTalStock;
                        StockList.Add(StockDetail);
                    }
                
            }
            catch (Exception ex)
            {
            }
            return StockList;


        }
        public bool SaveStockAdjustment(Order order, int OrderDetailId, int OrderId)
        {

          // using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    foreach (var item in order?.OrdersDetails)
                    {
                        foreach (var Subitem in GetStockDetailToAdjust(item.Qty, item?.Item.id))
                        {

                            StockOderDetail.Add(new StockOderDetail {ProductId=Subitem.ProductId, StockId=Subitem.StockId,OrderDetailId= OrderDetailId, Qty=Subitem.CanbeSettled,OrderId= OrderId });
                        }
                    }
                                  
                  
                    //The Transaction will be completed    
                    //scope.Complete();

                }
                catch (Exception ex)
                {
                   // scope.Dispose();
                }
                
            }

            return true;
        }

    }
}
