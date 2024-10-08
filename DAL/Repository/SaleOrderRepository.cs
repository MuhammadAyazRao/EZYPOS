﻿using Common;
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
        public IRepository<Customer> Customers { get; }
        public SaleOrderRepository(EPOSDBContext context) : base(context)
        {
            _DbEntities = context;
            Stock = new StockRepository(context);
            SaleOrderDetail = new Repository<SaleOrderDetail>(context);
            StockLead = new Repository<StockLead>(context);
            CustomerLead = new Repository<CustomerLead>(context);
            CashBookLead = new Repository<CashBookLead>(context);
            Customers = new Repository<Customer>(context);
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
                    NewOrder.Posid = ActiveSession.POSId;
                    NewOrder.OrderCount = 1;
                    NewOrder.CustomerId = CartOrderToProcess.CustId;
                    NewOrder.EmployeeId = ActiveSession.ActiveUser;
                    NewOrder.Total = CartOrderToProcess.GetTotal();
                    NewOrder.ParentOrderId = CartOrderToProcess.ParenOrderId;
                    NewOrder.OrderStatus = CartOrderToProcess.OrderStatus;
                    Add(NewOrder);

                    //Customer Reward
                    string WalkingCustomer = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.WalkingCustomer).FirstOrDefault().AppValue;
                    if(Convert.ToInt32(WalkingCustomer) != CartOrderToProcess.CustId)
                    {
                        var customer = Customers.Get(CartOrderToProcess.CustId);
                        if (CartOrderToProcess.RewardRedeemed == true)
                        {
                            customer.RewardPoints = 0;
                        }
                        else
                        {
                            decimal RP = Convert.ToDecimal(CartOrderToProcess.GetTotalRewardPoints());
                            customer.RewardPoints = customer.RewardPoints + RP;
                        }
                        Customers.Save();
                    }
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
                        NewOrderDetail.TaxType = item?.Item.TaxType;
                        NewOrderDetail.ItemTax = item?.Item.Tax;
                        NewOrderDetail.ItemIndex = 1;
                        NewOrderDetail.IsUpdated = "";
                        //NewOrderDetail.IsDeleted = "";
                        NewOrderDetail.KitchenLines = 1;
                        NewOrderDetail.CategoryId = item?.Item.CategoryId;
                        NewOrderDetail.CatName = item?.Item.CategoryName;
                        NewOrderDetail.ItemDiscount = item?.ItemDiscount;
                        NewOrderDetail.Posid = ActiveSession.POSId;
                        SaleOrderDetail.Add(NewOrderDetail);
                        if (CartOrderToProcess.OrderStatus == OrderStatus.Refunded.ToString())
                        {
                            Stock.revertStockAdjustmentItemWise(item, NewOrderDetail.Id, NewOrder.Id, NewOrder.ParentOrderId);
                        }
                        else
                        {
                            Stock.SaveStockAdjustmentItemWise(item, NewOrderDetail.Id, NewOrder.Id);                            
                        }
                        //Ledger Transaction

                        //Stock Transaction
                        StockLead stockled = new StockLead();
                        if(CartOrderToProcess.OrderStatus==OrderStatus.Refunded.ToString())
                        {
                            stockled.DrQty = NewOrderDetail.ItemQty;
                            stockled.TransactionType = Common.InvoiceType.ReturnInvoice;
                            stockled.TransactionDetail = "Return Transaction against Invoice Number # " + NewOrder.Id;

                        }
                        else
                        {
                            stockled.CrQty = NewOrderDetail.ItemQty;
                            stockled.TransactionType = Common.InvoiceType.SaleInvoice;
                            stockled.TransactionDetail = "Sale Transaction against Invoice Number # " + NewOrder.Id;

                        }
                        stockled.TransactionDate = DateTime.Now;
                        stockled.TransactionId = NewOrder.Id;
                        stockled.ProductId = NewOrderDetail.ItemId;                       
                        StockLead.Add(stockled);
                        
                    }

                    // Customer Transaction
                   

                    if (CartOrderToProcess.OrderStatus == OrderStatus.Refunded.ToString())
                    {
                        if (CartOrderToProcess.PaymentType.ToUpper() == OrderEnums.PaymentType.CREDIT)
                        {
                            CustomerLead CustomerLed = new CustomerLead();
                            CustomerLed.Cr = (int)NewOrder.CashAmount;
                            CustomerLed.TransactionType = Common.InvoiceType.ReturnInvoice;
                            CustomerLed.TransactionDetail = "Return Transaction against Invoice Number # " + NewOrder.Id;
                            CustomerLed.TransactionDate = DateTime.Now;
                            CustomerLed.TransactionId = NewOrder.Id;
                            CustomerLed.CustomerId = CartOrderToProcess.CustId;
                            CustomerLead.Add(CustomerLed);
                        }
                        else
                        {
                            CashBookLead CashBookLed = new CashBookLead();
                            CashBookLed.CrAmt = (int)NewOrder.CashAmount;
                            CashBookLed.TransactionDate = DateTime.Now;
                            CashBookLed.TransactionId = NewOrder.Id;
                            CashBookLed.TransactionType = Common.InvoiceType.ReturnInvoice;
                            CashBookLed.TransactionDetail = "Cash Return Transaction against Invoice Number # " + NewOrder.Id;
                            //CashBookLed.CustomerId = 1;
                            CashBookLead.Add(CashBookLed);
                        }
                       
                    }
                    else
                    {
                        CustomerLead CustomerLed = new CustomerLead();
                        CustomerLed.Dr = (int)NewOrder.CashAmount;
                        CustomerLed.TransactionType = Common.InvoiceType.SaleInvoice;
                        CustomerLed.TransactionDetail = "Sale Transaction against Invoice Number # " + NewOrder.Id;
                        CustomerLed.TransactionDate = DateTime.Now;
                        CustomerLed.TransactionId = NewOrder.Id;
                        CustomerLed.CustomerId = CartOrderToProcess.CustId;
                        CustomerLead.Add(CustomerLed);
                    }
                   
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
                SingleOrder.Tax = (decimal)(SingleItem.Tax==null?0: SingleItem.Tax);
                SingleOrder.PaymentType= SingleItem.PaymentMode;
                SingleOrder.payment_status = SingleItem.PaymentStatus;
                SingleOrder.OrderDate =(DateTime) SingleItem.OrderDate;
                SingleOrder.EmployeeId = (int)SingleItem.EmployeeId;
                SingleOrder.CustId = (int)SingleItem.CustomerId;
                SingleOrder.IsUpdated = SingleItem.IsUpdated;
                SingleOrder.IsDeleted = SingleItem.IsDeleted;
                SingleOrder.OrderStatus = SingleItem.OrderStatus;
                SingleOrder.POS = SingleItem.Posid;
                foreach(var orderdetail in SaleOrderDetail.GetAll().Where(x=>x.OrderId== SingleItem.Id))
                {
                    OrderDetail SingleOrderDetail = new OrderDetail();
                    SingleOrderDetail.OrderId = orderdetail.Id;
                    SingleOrderDetail.Qty = (int)orderdetail?.ItemQty;
                    SingleOrderDetail.ItemDiscount = (decimal)(orderdetail?.ItemDiscount == null ? 0 : orderdetail?.ItemDiscount);
                    item NewItem = new item();
                    NewItem.id = orderdetail.ItemId;
                    NewItem.name = orderdetail?.ItemName;                   
                    NewItem.price = (decimal)(orderdetail?.ItemPrice == null ? 0 : orderdetail?.ItemPrice);
                    NewItem.PurchasePrice = (decimal)(orderdetail?.PurchasePrice == null ? 0 : orderdetail?.PurchasePrice);
                    
                    NewItem.TaxType = orderdetail?.TaxType;
                    NewItem.Tax = (decimal)orderdetail?.ItemTax;
                    SingleOrderDetail.Item = NewItem;
                    if (SingleOrder.OrdersDetails == null)
                    { SingleOrder.OrdersDetails = new List<OrderDetail>(); }
                    SingleOrder.OrdersDetails.Add(SingleOrderDetail);


                }
                MappedOrdeList.Add(SingleOrder);               
            }
            return MappedOrdeList;

        }
        public bool DeleteOrder(int id , string type)
        {
            _DbEntities.StockOderDetails.RemoveRange(_DbEntities.StockOderDetails.Where(x => x.OrderId == id).ToList());
            _DbEntities.CustomerLeads.RemoveRange(_DbEntities.CustomerLeads.Where(x => x.Id == id).ToList());
            _DbEntities.CashBookLeads.RemoveRange(_DbEntities.CashBookLeads.Where(x => x.Id == id).ToList());

            var allorderdet = _DbEntities.SaleOrderDetails.Where(x => x.OrderId == id).ToList();
            allorderdet.ForEach(x => x.IsDeleted = true);
            _DbEntities.SaleOrderDetails.UpdateRange(allorderdet);
            var Order = _DbEntities.SaleOrders.Find(id);
            Order.IsDeleted = true;
            if(type == OrderStatus.Deleted.ToString())
            {
                Order.OrderStatus = OrderStatus.Deleted.ToString();
            }
            else if (type == OrderStatus.Canceled.ToString())
            {
                Order.OrderStatus = OrderStatus.Canceled.ToString();
            }
            else if (type == OrderStatus.Edited.ToString())
            {
                Order.OrderStatus = OrderStatus.Edited.ToString();
            }
            _DbEntities.SaleOrders.Update(Order);
            _DbEntities.SaveChanges();
            return true;
        }
    }
}
