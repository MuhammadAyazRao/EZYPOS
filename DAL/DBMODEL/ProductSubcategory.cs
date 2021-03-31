using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class ProductSubcategory
    {
        public ProductSubcategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string SubcategoryName { get; set; }
        public int? CategoryId { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
