using Common.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IMongoDbContext
    {
        public IMongoCollection<TransactionResponse> Transactions { get; }
    }
}
