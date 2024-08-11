using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IRepo
{
    public interface ITransactionRepo
    {
        Task<TransactionSearchResult> GetTransactionsAsync(TransactionRequest filterRequest);
        public  Task<TransactionSearchResult> GetAllTransactionsByMerchantIdAsync(TransactionRequest filterRequest);
    }
}
