using System;
using System.Collections.Generic;

#nullable disable

namespace EZYPOS.DBModels
{
    public partial class AppPage
    {
        public AppPage()
        {
            UserPages = new HashSet<UserPage>();
        }

        public int Id { get; set; }
        public string PageName { get; set; }
        public bool? Isdeleted { get; set; }
        public int? ParentId { get; set; }
        public int? ListingOrder { get; set; }

        public virtual ICollection<UserPage> UserPages { get; set; }
    }
}
