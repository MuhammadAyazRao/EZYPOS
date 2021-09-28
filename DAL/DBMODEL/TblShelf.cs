using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class TblShelf
    {
        public int Sid { get; set; }
        public string ShelfName { get; set; }
        public string ShelfCode { get; set; }
    }
}
