﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class Product
    {
        public Product()
        {
            ProductStocks = new HashSet<ProductStock>();
            StockOderDetails = new HashSet<StockOderDetail>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public bool? Isdeleted { get; set; }
        public int? GroupId { get; set; }
        public long RetailPrice { get; set; }
        public long? Wholesaleprice { get; set; }
        public long PurchasePrice { get; set; }
        public DateTime? Lastupdated { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ProductGroup Group { get; set; }
        public virtual ProductSubcategory Subcategory { get; set; }
        public virtual ICollection<ProductStock> ProductStocks { get; set; }
        public virtual ICollection<StockOderDetail> StockOderDetails { get; set; }
    }
}
