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
    public class SaleOrderRepository : Repository<SaleOrder>, ISaleOrderRepository
    {
        private readonly EPOSDBContext _DbEntities;
        public IStockRepository Stock { get; }
        public IRepository<SaleOrderDetail> SaleOrderDetail { get; }
        public SaleOrderRepository(EPOSDBContext context) : base(context)
        {
            _DbEntities = context;
            Stock = new StockRepository(context);
            SaleOrderDetail = new Repository<SaleOrderDetail>(context);
        }



        public IEnumerable<SaleOrder> GetAllCyCustomer()
        {
            return _DbEntities.SaleOrders.OrderByDescending(x => x.Id).ToList();
        }

        public bool SaveOrder(Order CartOrderToProcess)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    SaleOrder NewOrder = new SaleOrder();
                    NewOrder.CashAmount = (long)CartOrderToProcess.GetNetTotal();
                    NewOrder.DiscountAmount = (long)CartOrderToProcess.GetTotalDiscount();
                    NewOrder.Date = DateTime.Now;
                    NewOrder.PaymentMode = CartOrderToProcess.PaymentType;
                    NewOrder.OrderDate = CartOrderToProcess.OrderDate;
                    NewOrder.PaymentStatus = "Paid";
                    NewOrder.Addby = "Admin";
                    NewOrder.Addon = "";
                    NewOrder.RestaurantId = 1;
                    NewOrder.UserId = 1;
                    NewOrder.OrderCount = 1;
                    NewOrder.Total = (long)CartOrderToProcess.GetTotal();
                    Add(NewOrder);
                    var id = NewOrder.Id;

                    //Order Detail
                    foreach (var item in CartOrderToProcess?.OrdersDetails)
                    {
                        SaleOrderDetail NewOrderDetail = new SaleOrderDetail();
                        NewOrderDetail.OrderId = NewOrder.Id;
                        NewOrderDetail.ItemId =(int) item?.Item.id;
                        NewOrderDetail.ItemName = item?.Item.name;                        
                        NewOrderDetail.ItemQty = (int)item?.Qty;                      
                        NewOrderDetail.ItemPrice = (long) item?.Item.price;
                        NewOrderDetail.ItemIndex = 1;
                        NewOrderDetail.IsUpdated = "";
                        NewOrderDetail.IsDeleted = "";
                        NewOrderDetail.KitchenLines = 1;
                        SaleOrderDetail.Add(NewOrderDetail);
                        
                        Stock.SaveStockAdjustment(CartOrderToProcess, NewOrderDetail.Id, NewOrder.Id);
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
       public List<Order> GetMappedOrder(int Id=0)
        {
            List<SaleOrder> Alldata;
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
                SingleOrder.Discount = (double)SingleItem.DiscountAmount;
                SingleOrder.PaymentType= SingleItem.PaymentMode;
                SingleOrder.payment_status = SingleItem.PaymentStatus;
                SingleOrder.OrderDate =(DateTime) SingleItem.OrderDate;
                foreach(var orderdetail in SaleOrderDetail.GetAll().Where(x=>x.OrderId== SingleItem.Id))
                {
                    OrderDetail SingleOrderDetail = new OrderDetail();
                    SingleOrderDetail.OrderId = orderdetail.Id;
                    SingleOrderDetail.Qty = (int)orderdetail?.ItemQty;
                    
                    item NewItem = new item();
                    NewItem.id = orderdetail.ItemId;
                    NewItem.name = orderdetail?.ItemName;                   
                    NewItem.price =(long) orderdetail?.ItemPrice;
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
            _DbEntities.StockOderDetails.RemoveRange(_DbEntities.StockOderDetails.Where(x => x.OrderId == id).ToList());
            _DbEntities.SaleOrderDetails.RemoveRange(_DbEntities.SaleOrderDetails.Where(x => x.OrderId == id).ToList());           
            Delete(id);
            return true;

        }
    }
}
