using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.IRepo;
using Common.Models;
using DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using NSubstitute;
using NUnit.Framework;

namespace DataAccessTests
{
    [TestFixture]
    public class TransactionRepoTests
    {
        private IMongoDbContext _mockContext;
        private IMongoCollection<TransactionResponse> _mockCollection;
        private IAsyncCursor<TransactionResponse> _mockAsyncCursor;
        private ITransactionRepo _transactionRepo;

        [SetUp]
        public void Setup()
        {
            _mockContext = Substitute.For<IMongoDbContext>();
            _mockCollection = Substitute.For<IMongoCollection<TransactionResponse>>();
            _mockAsyncCursor = Substitute.For<IAsyncCursor<TransactionResponse>>();

            _mockContext.Transactions.Returns(_mockCollection);
            _transactionRepo = new TransactionRepo(_mockContext);
        }

        [Test]
        public async Task GetTransactionsAsync_FilterAppliedCorrectly()
        {
            // Arrange
            var request = new TransactionRequest { MerchantId = "merchant-123" };
            var transactions = new List<TransactionResponse>
            {
                new TransactionResponse { MerchantCode = "merchant-123" },
                new TransactionResponse { MerchantCode = "merchant-124" }
            };

            // Mocking the cursor behavior
            _mockAsyncCursor.Current.Returns(transactions);
            _mockAsyncCursor.MoveNext(CancellationToken.None).Returns(true, false);
            _mockAsyncCursor.MoveNextAsync(CancellationToken.None).Returns(Task.FromResult(true), Task.FromResult(false));

            // Mocking the collection behavior
            _mockCollection.FindAsync(
                Arg.Any<FilterDefinition<TransactionResponse>>(),
                Arg.Any<FindOptions<TransactionResponse, TransactionResponse>>(),
                Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(_mockAsyncCursor));

            var filterBuilder = Builders<TransactionResponse>.Filter;
            var expectedFilter = filterBuilder.Eq(x => x.MerchantCode, request.MerchantId);

            // Act
            await _transactionRepo.GetTransactionsAsync(request);

            // Assert: Verify that the FindAsync method was called with the correct filter
            await _mockCollection.Received(1).FindAsync(
                Arg.Is<FilterDefinition<TransactionResponse>>(f => FilterDefinitionsAreEqual(f, expectedFilter)),
                Arg.Any<FindOptions<TransactionResponse, TransactionResponse>>(),
                Arg.Any<CancellationToken>()
            );
        }

        [Test]
        public async Task GetTransactionsAsync_CorrectResultReturned()
        {
            // Arrange
            var request = new TransactionRequest { MerchantId = "merchant-123" };
            var transactions = new List<TransactionResponse>
            {
                new TransactionResponse { MerchantCode = "merchant-123" },
                new TransactionResponse { MerchantCode = "merchant-124" },
                new TransactionResponse { MerchantCode = "merchant-123" }
            };

            // Filter transactions based on MerchantCode
            var filteredTransactions = transactions
                .Where(tr => tr.MerchantCode == request.MerchantId)
                .ToList();

            // Mocking the cursor behavior
            _mockAsyncCursor.Current.Returns(filteredTransactions);
            _mockAsyncCursor.MoveNext(CancellationToken.None).Returns(true, false);
            _mockAsyncCursor.MoveNextAsync(CancellationToken.None).Returns(Task.FromResult(true), Task.FromResult(false));

            // Mocking the collection behavior
            _mockCollection.FindAsync(
                Arg.Any<FilterDefinition<TransactionResponse>>(),
                Arg.Any<FindOptions<TransactionResponse, TransactionResponse>>(),
                Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(_mockAsyncCursor));

            // Act
            var result = await _transactionRepo.GetTransactionsAsync(request);

            // Assert
            // We expect transactions filtered correctly
            Assert.That(result.TotalCount, Is.EqualTo(filteredTransactions.Count));
            Assert.That(result.TransactionOrders.Count, Is.EqualTo(filteredTransactions.Count));
            Assert.That(result.TransactionOrders.All(t => t.MerchantCode == request.MerchantId), Is.True);
        }

        private static bool FilterDefinitionsAreEqual<TDocument>(FilterDefinition<TDocument> filter1, FilterDefinition<TDocument> filter2)
        {
            var serializerRegistry = BsonSerializer.SerializerRegistry;
            var documentSerializer = serializerRegistry.GetSerializer<TDocument>();
            var filter1Rendered = filter1.Render(documentSerializer, serializerRegistry).ToJson();
            var filter2Rendered = filter2.Render(documentSerializer, serializerRegistry).ToJson();
            return filter1Rendered == filter2Rendered;
        }
    }
}
