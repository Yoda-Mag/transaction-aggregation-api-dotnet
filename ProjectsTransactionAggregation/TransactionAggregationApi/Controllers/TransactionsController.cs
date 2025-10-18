using Microsoft.AspNetCore.Mvc;
using TransactionAggregationApi.Models;
using TransactionAggregationApi.Services;

namespace TransactionAggregationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionsController()
        {
            _transactionService = new TransactionService();
        }

        // GET: api/transactions
        [HttpGet]
        public IActionResult GetAll()
        {
            var transactions = _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        // GET: api/transactions/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomer(Guid customerId)
        {
            var transactions = _transactionService.GetTransactionsByCustomer(customerId);
            if (!transactions.Any())
                return NotFound($"No transactions found for customer {customerId}");
            
            return Ok(transactions);
        }

        // GET: api/transactions/aggregate/category
        [HttpGet("aggregate/category")]
        public IActionResult GetAggregatedByCategory()
        {
            var aggregated = _transactionService.GetAggregatedCategory();
            return Ok(aggregated);
        }

        // GET: api/transactions/aggregate/source
        [HttpGet("aggregate/source")]
        public IActionResult GetAggregatedBySource()
        {
            var aggregated = _transactionService.GetAggregatedSource();
            return Ok(aggregated);
        }
    }
}
