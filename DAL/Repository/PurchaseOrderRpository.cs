using Common;
using Common.DTO;
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
    public class PurchaseOrderRpository: Repository<PurchaseOrder>, IPurchaseRepository
    {
        private readonly EPOSDBContext _DbEntities;
        public IStockRepository Stock { get; }
        public IRepository<DAL.DBMODEL.PurchaseOrderDetail> PurchaseOrderDetail { get; }
        public IRepository<DAL.DBMODEL.Product> Product { get; }
        public IRepository<StockLead> StockLead { get; }
        public IRepository<CustomerLead> CustomerLead { get; }
        public IRepository<CashBookLead> CashBookLead { get; }
        public IRepository<SupplierLead> SupplierLeader { get; }
        public PurchaseOrderRpository(EPOSDBContext context) : base(context)
        {
            _DbEntities = context;
            Stock = new StockRepository(context);
            PurchaseOrderDetail = new Repository<DAL.DBMODEL.PurchaseOrderDetail>(context);
            Product = new Repository<DAL.DBMODEL.Product>(context);
            StockLead = new Repository<StockLead>(context);
            CustomerLead = new Repository<CustomerLead>(context);
            CashBookLead = new Repository<CashBookLead>(context);
            SupplierLeader= new Repository<SupplierLead>(context);
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
                        DAL.DBMODEL.PurchaseOrderDetail NewOrderDetail = new  DAL.DBMODEL.PurchaseOrderDetail();
                        NewOrderDetail.PurchaseOrderId = NewOrder.Id;
                        NewOrderDetail.ProductId = (int)item?.Item.id;
                        NewOrderDetail.ItemName = item?.Item.name;
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

                        //Stock Transaction
                        StockLead stockled = new StockLead();
                        stockled.DrQty = NewOrderDetail.Qty;
                        stockled.TransactionDate = DateTime.Now;
                        stockled.TransactionId = NewOrder.Id;
                        stockled.TransactionType = Common.InvoiceType.PurchaseInvoice;
                        stockled.TransactionDetail = "Purchase Transaction against Invoice Number # " + NewOrder.Id;
                        stockled.ProductId = NewOrderDetail.ProductId;
                        StockLead.Add(stockled);
                    }
                    // Supplier Transaction
                    SupplierLead SupplierLead = new SupplierLead();
                    SupplierLead.Dr = (int)NewOrder.TotalAmount;
                    SupplierLead.TransactionDate = DateTime.Now;
                    SupplierLead.TransactionId = NewOrder.Id;
                    SupplierLead.TransactionType = Common.InvoiceType.SaleInvoice;
                    SupplierLead.TransactionDet = "Purchase Transaction against Invoice Number # " + NewOrder.Id;
                    SupplierLead.SuplierId = 1;
                    SupplierLeader.Add(SupplierLead);


                    if (CartOrderToProcess.PaymentType.ToUpper() == OrderEnums.PaymentType.CASH)
                    {
                        // Supplier Transaction
                        SupplierLead SupplierLeadCr = new SupplierLead();
                        SupplierLeadCr.Cr = (int)NewOrder.TotalAmount;
                        SupplierLeadCr.TransactionDate = DateTime.Now;
                        SupplierLeadCr.TransactionId = NewOrder.Id;
                        SupplierLeadCr.TransactionType = Common.InvoiceType.SaleInvoice;
                        SupplierLeadCr.TransactionDet = "Cash Purchase Transaction against Invoice Number # " + NewOrder.Id;
                        SupplierLeadCr.SuplierId = 1;
                        SupplierLeader.Add(SupplierLeadCr);

                        // CashBook Leader Transaction

                        CashBookLead CashBookLed = new CashBookLead();
                        CashBookLed.CrAmt = (int)NewOrder.TotalAmount;
                        CashBookLed.TransactionDate = DateTime.Now;
                        CashBookLed.TransactionId = NewOrder.Id;
                        CashBookLed.TransactionType = Common.InvoiceType.SaleInvoice;
                        CashBookLed.TransactionDetail = "Cash Purchase Transaction against Invoice Number # " + NewOrder.Id;
                        //CashBookLed.CustomerId = 1;
                        CashBookLead.Add(CashBookLed);
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
        public List<PurchaseOrderDTO> GetMappedOrder(int Id = 0)
        {
            List<PurchaseOrder> Alldata;
            List<PurchaseOrderDTO> MappedOrdeList = new List<PurchaseOrderDTO>();
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
                PurchaseOrderDTO SingleOrder = new PurchaseOrderDTO();
                SingleOrder.OrderId = SingleItem.Id;
                //SingleOrder.Discount = (double)SingleItem.DiscountAmount;
                SingleOrder.PaymentType = SingleItem.PaymentMode;
                SingleOrder.payment_status = SingleItem.PaymentStatus;
                //SingleOrder.OrderDate = (DateTime)SingleItem.OrderDate;
                foreach (var orderdetail in PurchaseOrderDetail.GetAll().Where(x => x.PurchaseOrderId == SingleItem.Id))
                {
                    Common.DTO.PurchaseOrderDetail SingleOrderDetail = new Common.DTO.PurchaseOrderDetail();
                    SingleOrderDetail.OrderId = orderdetail.Id;
                    SingleOrderDetail.Qty = (int)orderdetail?.Qty;

                    Purchaseitem NewItem = new Purchaseitem();
                    NewItem.id = orderdetail.ProductId;
                    NewItem.name =orderdetail.ItemName;
                    NewItem.price = (long)orderdetail?.PurchasePrice;
                    SingleOrderDetail.Item = NewItem;
                    if (SingleOrder.OrdersDetails == null)
                    { SingleOrder.OrdersDetails = new List<Common.DTO.PurchaseOrderDetail>(); }
                    SingleOrder.OrdersDetails.Add(SingleOrderDetail);


                }
                MappedOrdeList.Add(SingleOrder);
            }
            return MappedOrdeList;

        }
        public bool DeleteOrder(int id)
        {
            if (_DbEntities.StockOderDetails.Where(x => x.StockId == _DbEntities.ProductStocks.Where(x => x.PurchaseOrderId == id).FirstOrDefault().Id).Count() <= 0)
            {
                _DbEntities.SaveChanges();
                _DbEntities.ProductStocks.RemoveRange(_DbEntities.ProductStocks.Where(x => x.PurchaseOrderId == id).ToList());
                _DbEntities.SaveChanges();
                _DbEntities.PurchaseOrderDetails.RemoveRange(_DbEntities.PurchaseOrderDetails.Where(x => x.PurchaseOrderId == id).ToList());
                Delete(id);
                return true;
            }
            else
            { 
                return false; 
            }

        }

        //public bool SaveOrder(Order CartOrderToProcess)
        //{
        //    throw new NotImplementedException();
        //}

       
    }
}
