using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Common.IService;
using Common.Models;

namespace DemoPortalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] TransactionRequest filterRequest)
        {
            if (filterRequest.FromDate == null || filterRequest.ToDate == null)
            {
                throw new ArgumentException("FromDate and ToDate are required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var transactions = await _transactionService.GetTransactionsAsync(filterRequest);
                return Ok(transactions);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", detail = ex.Message });
            }

        }

        [HttpPost]
        public async Task<TransactionSearchResult> GetAllTransactions([FromBody] TransactionRequest filterRequest) 
        {
            return await _transactionService.GetTransactionSearchAsync(filterRequest);
        }
    }
}
