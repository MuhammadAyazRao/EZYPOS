using System;
using System.Collections.Generic;

#nullable disable

namespace EZYPOS.DBModels
{
    public partial class UserPage
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PageId { get; set; }

        public virtual AppPage Page { get; set; }
        public virtual Emplyee User { get; set; }
    }
}
