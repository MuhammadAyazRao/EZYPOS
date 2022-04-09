using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class SaleOrderDetail
    {
        public SaleOrderDetail()
        {
            StockOderDetails = new HashSet<StockOderDetail>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string FixedItemDes { get; set; }
        public int? SubCatId { get; set; }
        public string SubCatName { get; set; }
        public string CatName { get; set; }
        public int? PrintSort { get; set; }
        public int KitchenLines { get; set; }
        public string ItemComments { get; set; }
        public int ItemQty { get; set; }
        public decimal? ItemDiscount { get; set; }
        public decimal? ItemPrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int ItemIndex { get; set; }
        public int? BillNo { get; set; }
        public string IsUpdated { get; set; }
        public string IsDeleted { get; set; }

        public virtual SaleOrder Order { get; set; }
        public virtual ICollection<StockOderDetail> StockOderDetails { get; set; }
    }
}
