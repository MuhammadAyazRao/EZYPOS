using DAL.DBMODEL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.UserControls.Report
{
    public  class ProductWiseStockReport
    {
        public List<ProductWiseStockReportModel> GetStockreportData(string ItemName="")
        {
            List<ProductWiseStockReportModel> ReportData = new List<ProductWiseStockReportModel>();
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                List<Product> products = new List<Product>();
                if (string.IsNullOrEmpty(ItemName))
                { 
                    products = uw.Product.GetAll().ToList();
                }
                else
                {
                    products = uw.Product.GetAll().Where(x=>x.ProductName.Contains(ItemName)).ToList();
                }
                foreach (var pro in products)
                {
                    ReportData.Add(new ProductWiseStockReportModel { ProductName = pro.ProductName, ProductStock = GetTotalAvailableStock(pro.Id) });

                }
            }
            return ReportData;

        }
        public long GetTotalAvailableStock(int ProductId)
        {
            long TotalStock = 0;
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                
               // var products = uw.ProductStock.GetAll().wherer.ToList();
               // foreach (var pro in products)
                {
                    var StockInformations = uw.ProductStock.GetAll().Where(x => x.ProductId == ProductId).ToList();
                    foreach (var StockInfo in StockInformations)
                    {
                        if (StockInfo != null)
                        {
                            TotalStock += StockInfo.Qty + (StockInfo.Adjustment) + (long)StockInfo.Conversion;
                            foreach (var subitem in uw.StockOderDetail.GetAll().Where(x => x.StockId == StockInfo.Id).ToList())
                            {
                                TotalStock = TotalStock - subitem.Qty;

                            }
                        }
                    }
                    
                }
                    
                

            }
            return TotalStock;

        }

    }
    public class ProductWiseStockReportModel
    {
        public string ProductName { get; set; }
        public long ProductStock { get; set; }
    }
}
