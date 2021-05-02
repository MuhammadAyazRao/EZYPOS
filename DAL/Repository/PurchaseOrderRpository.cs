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
    public class PurchaseOrderRpository: Repository<PurchaseOrder>, IPurchaseRepository
    {
        private readonly EPOSDBContext _DbEntities;
        public IStockRepository Stock { get; }
        public IRepository<DAL.DBModel.PurchaseOrderDetail> PurchaseOrderDetail { get; }
        public PurchaseOrderRpository(EPOSDBContext context) : base(context)
        {
            _DbEntities = context;
            Stock = new StockRepository(context);
            PurchaseOrderDetail = new Repository<DAL.DBModel.PurchaseOrderDetail>(context);
        }





        public bool SaveOrder(PurchaseOrderDTO CartOrderToProcess)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    PurchaseOrder NewOrder = new PurchaseOrder();
                   // NewOrder.CashAmount = (long)CartOrderToProcess.GetNetTotal();
                    //NewOrder.DiscountAmount = (long)CartOrderToProcess.GetTotalDiscount();
                    NewOrder.Date = DateTime.Now;
                    NewOrder.PaymentMode = "Cash";                    
                    //  NewOrder.OrderDate = CartOrderToProcess.OrderDate;
                    NewOrder.PaymentStatus = "Paid";
                    //NewOrder.Addby = "Admin";
                    //NewOrder.Addon = "";
                    //NewOrder.RestaurantId = 1;
                    //NewOrder.UserId = 1;
                    //NewOrder.OrderCount = 1;
                    NewOrder.TotalAmount =(int) CartOrderToProcess.GetTotal();
                    Add(NewOrder);
                   
                    //Order Detail
                    foreach (var item in CartOrderToProcess?.OrdersDetails)
                    {
                        DAL.DBModel.PurchaseOrderDetail NewOrderDetail = new  DAL.DBModel.PurchaseOrderDetail();
                        NewOrderDetail.PurchaseOrderId = NewOrder.Id;
                        NewOrderDetail.ProductId = (int)item?.Item.id;
                       // NewOrderDetail.ItemName = item?.Item.name;
                        NewOrderDetail.Qty = (int)item?.Qty;
                        NewOrderDetail.PurchasePrice = (int) item?.Item.price;
                        NewOrderDetail.ExpiryDate = item?.ExpiryDate;
                        NewOrderDetail.StartDate = item?.StartDate;
                        NewOrderDetail.Total = (int)(item.Qty* item?.Item.price);
                        //NewOrderDetail.ItemIndex = 1;
                        //NewOrderDetail.IsUpdated = "";
                        //NewOrderDetail.IsDeleted = "";
                        //NewOrderDetail.KitchenLines = 1;
                        PurchaseOrderDetail.Add(NewOrderDetail);                        
                        Stock.Add(new ProductStock { ProductId= NewOrderDetail.ProductId,StartDate=(DateTime) NewOrderDetail.StartDate,ExpiryDate= (DateTime)NewOrderDetail.ExpiryDate,Qty= NewOrderDetail.Qty, PurchaseOrderId = NewOrderDetail.PurchaseOrderId ,Adjustment=0});

                       // Stock.SaveStockAdjustment(CartOrderToProcess, NewOrderDetail.Id, NewOrder.Id);
                    }


                    //The Transaction will be completed    
                    scope.Complete();

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                }
            }
            return true;
        }
        public List<Order> GetMappedOrder(int Id = 0)
        {
            List<PurchaseOrder> Alldata;
            List<Order> MappedOrdeList = new List<Order>();
            if (Id == 0)
            {
                Alldata = GetAll().ToList();
            }
            else
            {
                Alldata = GetAll().Where(x => x.Id == Id).ToList();
            }

            foreach (var SingleItem in Alldata)
            {
                Order SingleOrder = new Order();
                SingleOrder.OrderId = SingleItem.Id;
                //SingleOrder.Discount = (double)SingleItem.DiscountAmount;
                SingleOrder.PaymentType = SingleItem.PaymentMode;
                SingleOrder.payment_status = SingleItem.PaymentStatus;
                //SingleOrder.OrderDate = (DateTime)SingleItem.OrderDate;
                foreach (var orderdetail in PurchaseOrderDetail.GetAll().Where(x => x.PurchaseOrderId == SingleItem.Id))
                {
                    OrderDetail SingleOrderDetail = new OrderDetail();
                    SingleOrderDetail.OrderId = orderdetail.Id;
                    SingleOrderDetail.Qty = (int)orderdetail?.Qty;

                    item NewItem = new item();
                   // NewItem.id = orderdetail.ItemId;
                   // NewItem.name = orderdetail?.ItemName;
                    NewItem.price = (long)orderdetail?.PurchasePrice;
                    SingleOrderDetail.Item = NewItem;
                    if (SingleOrder.OrdersDetails == null)
                    { SingleOrder.OrdersDetails = new List<OrderDetail>(); }
                    SingleOrder.OrdersDetails.Add(SingleOrderDetail);


                }
                MappedOrdeList.Add(SingleOrder);
            }
            return MappedOrdeList;

        }
        public bool DeleteOrder(int id)
        {
            //_DbEntities.ProductStocks.RemoveRange(_DbEntities.ProductStocks.Where(x => x.p == id).ToList());
            //_DbEntities.SaleOrderDetails.RemoveRange(_DbEntities.SaleOrderDetails.Where(x => x.OrderId == id).ToList());
            //Delete(id);
            return true;

        }

        //public bool SaveOrder(Order CartOrderToProcess)
        //{
        //    throw new NotImplementedException();
        //}

        List<Order> IPurchaseRepository.GetMappedOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
