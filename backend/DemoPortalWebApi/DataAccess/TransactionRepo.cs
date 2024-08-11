using System.Collections.Generic;
using System.Threading.Tasks;
using Common.IRepo;
using Common.Models;
using Common.Models.DbConnectionModels;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections;
using Amazon.Runtime.Internal;

namespace DataAccess
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly IMongoDbContext _context;

        public TransactionRepo(IMongoDbContext context)
        {
            _context = context;
        }
        public async Task<TransactionSearchResult> GetAllTransactionsByMerchantIdAsync(TransactionRequest filterRequest)
        {
            /*var filterBuilder = Builders<TransactionResponse>.Filter;
            var filter = filterBuilder.Eq(n => n.MerchantCode, filterRequest.MerchantId);*/

            var transactions = await _context.Transactions.Find(_=>true).ToListAsync();
            var totalCount = transactions.Count();
            return new TransactionSearchResult { TotalCount = totalCount, TransactionOrders = transactions };
        }


        public async Task<TransactionSearchResult> GetTransactionsAsync(TransactionRequest request)
        {

            var filterBuilder = Builders<TransactionResponse>.Filter;
            var merchantIdFilter =
            filterBuilder.Eq(x => x.MerchantCode, request.MerchantId);

            var transactions = await _context.Transactions.Find(merchantIdFilter).ToListAsync();

            if (transactions.Count == 0)
            {
                throw new KeyNotFoundException("No transactions found for the given TerminalId and date range.");
            }

            var transactionSearchResult = new TransactionSearchResult
            {
                TotalCount = transactions.Count,
                TransactionOrders = transactions
            };

            return transactionSearchResult;
        }

    }
}
