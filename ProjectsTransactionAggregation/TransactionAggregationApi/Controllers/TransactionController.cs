using Microsoft.AspNetCore.Mvc;
using TransactionAggregationApi.Services;

namespace TransactionAggregationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;
        public TransactionController(TransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult getAll() => Ok(_service.getAllTransactions());
        
        [HttpGet("customer/{customerId}")]
        public IActionResult getByCustomer(Guid customerId)
        {
            var transactions = _service.getTransactionsByCustomer(customerId);
            if (!transactions.Any())
                return NotFound($"No transactions found for customer {customerId}");
            return Ok(transactions);
        }

        [HttpGet("aggregate/category")]
        public IActionResult getCategoryAggregate() =>
            Ok(_service.getAggregatedCategory());

        [HttpGet("aggregate/source")]
        public IActionResult getSourceAggregate() =>
            Ok(_service.getAggregatedSource());


        [HttpGet("aggregate/moneyflow")]
        public IActionResult getMoneyFlowAggregate() =>
            Ok(_service.getMoneyFlowAggregate());
    }
}
