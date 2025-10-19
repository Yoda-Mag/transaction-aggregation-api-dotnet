using Microsoft.AspNetCore.Mvc;
using TransactionAggregationApi.Data;

namespace TransactionAggregationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(MockDataSource.Customers);
        }
    }
}
