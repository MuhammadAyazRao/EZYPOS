using Common;
using Common.DTO;
using Common.Session;
using DAL.DBMODEL;
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
        public IRepository<StockLead> StockLead { get; }
        public IRepository<CustomerLead> CustomerLead { get; }
        public IRepository<CashBookLead> CashBookLead { get; }
        public SaleOrderRepository(EPOSDBContext context) : base(context)
        {
            _DbEntities = context;
            Stock = new StockRepository(context);
            SaleOrderDetail = new Repository<SaleOrderDetail>(context);
            StockLead = new Repository<StockLead>(context);
            CustomerLead = new Repository<CustomerLead>(context);
            CashBookLead = new Repository<CashBookLead>(context);
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
                    NewOrder.CashAmount = CartOrderToProcess.GetNetTotal() + CartOrderToProcess.Tax;
                    NewOrder.TaxPercentage = CartOrderToProcess.TaxPercentage;
                    NewOrder.Tax = CartOrderToProcess.Tax;
                    NewOrder.DiscountAmount = CartOrderToProcess.GetTotalDiscount();
                    NewOrder.DeliveryCharges = CartOrderToProcess.DeliverCharges;
                    NewOrder.Date = CartOrderToProcess.OrderDate;  //DateTime.Today;
                    NewOrder.PaymentMode = CartOrderToProcess.PaymentType;
                    NewOrder.OrderDate = CartOrderToProcess.OrderDate;
                    NewOrder.PaymentStatus = "Paid";
                    NewOrder.Addby = "Admin";
                    NewOrder.Addon = "";
                    NewOrder.RestaurantId = 1;
                    NewOrder.UserId = 1;
                    NewOrder.OrderCount = 1;
                    NewOrder.CustomerId = CartOrderToProcess.CustId;
                    NewOrder.EmployeeId = ActiveSession.ActiveUser;
                    NewOrder.Total = CartOrderToProcess.GetTotal();
                    Add(NewOrder);
                    //var id = NewOrder.Id;

                    //Order Detail
                    foreach (var item in CartOrderToProcess?.OrdersDetails)
                    {
                        SaleOrderDetail NewOrderDetail = new SaleOrderDetail();
                        NewOrderDetail.OrderId = NewOrder.Id;
                        NewOrderDetail.ItemId =(int) item?.Item.id;
                        NewOrderDetail.ItemName = item?.Item.name;                        
                        NewOrderDetail.ItemQty = (int)item?.Qty;                      
                        NewOrderDetail.ItemPrice = item?.Item.price;
                        NewOrderDetail.PurchasePrice = item?.Item.PurchasePrice;
                        NewOrderDetail.ItemIndex = 1;
                        NewOrderDetail.IsUpdated = "";
                        NewOrderDetail.IsDeleted = "";
                        NewOrderDetail.KitchenLines = 1;
                        NewOrderDetail.ItemDiscount = item?.ItemDiscount;
                        SaleOrderDetail.Add(NewOrderDetail);
                        
                        Stock.SaveStockAdjustment(CartOrderToProcess, NewOrderDetail.Id, NewOrder.Id);

                        //Ledger Transaction

                        //Stock Transaction
                        StockLead stockled = new StockLead();
                        stockled.CrQty = NewOrderDetail.ItemQty;
                        stockled.TransactionDate = DateTime.Now;
                        stockled.TransactionId = NewOrder.Id;
                        stockled.TransactionType = Common.InvoiceType.SaleInvoice;
                        stockled.TransactionDetail = "Sale Transaction against Invoice Number # " + NewOrder.Id;
                        stockled.ProductId = NewOrderDetail.ItemId;                       
                        StockLead.Add(stockled);
                        
                    }

                    // Customer Transaction
                    CustomerLead CustomerLed = new CustomerLead();
                    CustomerLed.Dr =(int)NewOrder.CashAmount;
                    CustomerLed.TransactionDate = DateTime.Now;
                    CustomerLed.TransactionId = NewOrder.Id;
                    CustomerLed.TransactionType = Common.InvoiceType.SaleInvoice;
                    CustomerLed.TransactionDetail = "Sale Transaction against Invoice Number # " + NewOrder.Id;
                    CustomerLed.CustomerId = CartOrderToProcess.CustId;
                    CustomerLead.Add(CustomerLed);
                    if (CartOrderToProcess.PaymentType.ToUpper() == OrderEnums.PaymentType.CASH)
                    {
                        CustomerLead CustomerLedCR = new CustomerLead();
                        CustomerLedCR.Cr = (int)NewOrder.CashAmount;
                        CustomerLedCR.TransactionDate = DateTime.Now;
                        CustomerLedCR.TransactionId = NewOrder.Id;
                        CustomerLedCR.TransactionType = Common.InvoiceType.SaleInvoice;
                        CustomerLedCR.TransactionDetail = "Cash Sale Transaction against Invoice Number # " + NewOrder.Id;
                        CustomerLedCR.CustomerId = CartOrderToProcess.CustId;
                        CustomerLead.Add(CustomerLedCR);

                        // CashBook Leader Transaction

                        CashBookLead CashBookLed = new CashBookLead();
                        CashBookLed.DrAmt = (int)NewOrder.CashAmount;
                        CashBookLed.TransactionDate = DateTime.Now;
                        CashBookLed.TransactionId = NewOrder.Id;
                        CashBookLed.TransactionType = Common.InvoiceType.SaleInvoice;
                        CashBookLed.TransactionDetail = "Cash Sale Transaction against Invoice Number # " + NewOrder.Id;
                        //CashBookLed.CustomerId = 1;
                        CashBookLead.Add(CashBookLed);
                    }
                    //else if (CartOrderToProcess.PaymentType.ToUpper() == "CREDIT")
                    //{

                    //}

                    //The Transaction will be completed    
                    scope.Complete();

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return false;
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
                SingleOrder.Discount = (decimal)SingleItem.DiscountAmount;
                SingleOrder.DeliverCharges = (decimal)SingleItem.DeliveryCharges;
                SingleOrder.Tax = (decimal)SingleItem.Tax;
                SingleOrder.PaymentType= SingleItem.PaymentMode;
                SingleOrder.payment_status = SingleItem.PaymentStatus;
                SingleOrder.OrderDate =(DateTime) SingleItem.OrderDate;
                SingleOrder.EmployeeId = (int)SingleItem.EmployeeId;
                SingleOrder.CustId = (int)SingleItem.CustomerId;
                foreach(var orderdetail in SaleOrderDetail.GetAll().Where(x=>x.OrderId== SingleItem.Id))
                {
                    OrderDetail SingleOrderDetail = new OrderDetail();
                    SingleOrderDetail.OrderId = orderdetail.Id;
                    SingleOrderDetail.Qty = (int)orderdetail?.ItemQty;

                    item NewItem = new item();
                    NewItem.id = orderdetail.ItemId;
                    NewItem.name = orderdetail?.ItemName;                   
                    NewItem.price = (decimal)orderdetail?.ItemPrice;
                    NewItem.PurchasePrice = (decimal)orderdetail?.PurchasePrice;
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
