using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class TblShelf
    {
        public TblShelf()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string ShelfName { get; set; }
        public string ShelfCode { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
