using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class TransactionRequest
    {
        [Required]
        public string? MerchantId { get; set; }
        
        public string TerminalId { get; set; }
        public string? Status { get; set; }
        public string? RRN { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        public string? CardScheme { get; set; }
        public string? CardMode { get; set; }
        public string? TransactionType { get; set; }
    }
}
