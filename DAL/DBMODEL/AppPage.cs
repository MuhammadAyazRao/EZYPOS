using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class AppPage
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public bool? Isdeleted { get; set; }
        public int? ParentId { get; set; }
        public int? ListingOrder { get; set; }
    }
}
