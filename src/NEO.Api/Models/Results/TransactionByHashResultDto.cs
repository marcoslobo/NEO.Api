using System;

namespace NEO.Api.Models
{
    public class TransactionByHashResultDto
    {
        public string Hash { get; set; }
        public DateTime Time { get; set; } 
        public decimal NetworkFee { get; set; }
        public decimal SystemFee { get; set; } 
        public string Size { get; set; }
        public int BlockId { get; set; } 
    }
}
