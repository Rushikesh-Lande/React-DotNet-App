using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class TransactionSearchResult 
    { 
        public int TotalCount { get; init; } 
        public IReadOnlyCollection<TransactionResponse> TransactionOrders { get; init; } = new List<TransactionResponse>();
    }
}
