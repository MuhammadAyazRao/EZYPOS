using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class Product
    {
        public Product()
        {
            ProductStocks = new HashSet<ProductStock>();
            StockLeads = new HashSet<StockLead>();
            StockOderDetails = new HashSet<StockOderDetail>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public bool? Isdeleted { get; set; }
        public int? GroupId { get; set; }
        public int? ShelfId { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal? Wholesaleprice { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime? Lastupdated { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public decimal? Size { get; set; }
        public int? Unit { get; set; }
        public string TaxType { get; set; }
        public decimal? Tax { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ProductGroup Group { get; set; }
        public virtual TblShelf Shelf { get; set; }
        public virtual ProductSubcategory Subcategory { get; set; }
        public virtual Unit UnitNavigation { get; set; }
        public virtual ICollection<ProductStock> ProductStocks { get; set; }
        public virtual ICollection<StockLead> StockLeads { get; set; }
        public virtual ICollection<StockOderDetail> StockOderDetails { get; set; }
    public decimal? RewardPoints { get; set; }
  }
}
