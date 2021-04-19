using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public  class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string CategoryName{ get; set; }
        public string SubcategoryName{ get; set; }
        public bool? Isdeleted { get; set; }
        public int? GroupName { get; set; }
        public long? RetailPrice { get; set; }
        public long? Wholesaleprice { get; set; }
        public long? PurchasePrice { get; set; }
        public DateTime? Lastupdated { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }
       
    }
}
