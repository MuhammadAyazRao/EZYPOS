﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBMODEL
{
    public partial class CashBookLead
    {
        public int Id { get; set; }
        public long? TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDetail { get; set; }
        public long? CashBookId { get; set; }
        public decimal? DrAmt { get; set; }
        public decimal? CrAmt { get; set; }
        public long? UserId { get; set; }
        public long? PosId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
