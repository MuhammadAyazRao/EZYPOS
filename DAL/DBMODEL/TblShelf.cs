using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class TblShelf
    {
        public int Id { get; set; }
        public string ShelfName { get; set; }
        public string ShelfCode { get; set; }
    }
}
