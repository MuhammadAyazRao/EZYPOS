using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class Setting
    {
        public int Id { get; set; }
        public string AppKey { get; set; }
        public string AppValue { get; set; }
    }
}
