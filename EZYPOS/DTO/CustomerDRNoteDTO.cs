using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class CustomerDRNoteDTO
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public string Discription { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomerName { get; set; }
        public string ReceivedBy { get; set; }
        public string Shop { get; set; }
    }
}
