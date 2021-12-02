using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductSubcategories = new HashSet<ProductSubcategory>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Isdeleted { get; set; }
        public DateTime? Createdon { get; set; }

        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
