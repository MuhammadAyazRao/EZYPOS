using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class Page
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string Tag { get; set; }
        public string ClickEvent { get; set; }
        public bool? Isclickable { get; set; }
        public string Template { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
