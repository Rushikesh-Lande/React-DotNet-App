using Common.IRepo;
using Common.IService;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _transactionRepo;

        public TransactionService(ITransactionRepo transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public async Task<TransactionSearchResult> GetTransactionsAsync(TransactionRequest filterRequest)
        {
            // Business logic can be added here if necessary
            return await _transactionRepo.GetAllTransactionsByMerchantIdAsync(filterRequest);
        }
        public async Task<TransactionSearchResult> GetTransactionSearchAsync(TransactionRequest filterRequest)
        {
            // Business logic can be added here if necessary
            return await _transactionRepo.GetTransactionsAsync(filterRequest);
        }
    }
}
