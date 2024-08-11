using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IService
{
    public interface ITransactionService
    {
        Task<TransactionSearchResult> GetTransactionsAsync(TransactionRequest filterRequest);
        Task<TransactionSearchResult> GetTransactionSearchAsync(TransactionRequest filterRequest);
    }
}
