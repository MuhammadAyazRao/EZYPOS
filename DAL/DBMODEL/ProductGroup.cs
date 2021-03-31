using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
