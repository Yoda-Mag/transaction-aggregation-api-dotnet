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
        public IActionResult GetAll() => Ok(_service.GetAllTransactions());
        
        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomer(Guid customerId)
        {
            var transactions = _service.GetTransactionsByCustomer(customerId);
            if (!transactions.Any())
                return NotFound($"No transactions found for customer {customerId}");
            return Ok(transactions);
        }

        [HttpGet("aggregate/category")]
        public IActionResult GetCategoryAggregate() =>
            Ok(_service.GetAggregatedCategory());

        [HttpGet("aggregate/source")]
        public IActionResult GetSourceAggregate() =>
            Ok(_service.GetAggregatedSource());
    }
}
