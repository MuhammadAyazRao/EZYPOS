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
        public string Unit { get; set; }
        public string Size { get; set; }
        public string Barcode { get; set; }
        public string CategoryName{ get; set; }
        public string SubcategoryName{ get; set; }
        public bool? Isdeleted { get; set; }
        public int? GroupName { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal? Wholesaleprice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string? TaxType { get; set; }
        public decimal? Tax { get; set; }
        public DateTime? Lastupdated { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }
       
    }
}
