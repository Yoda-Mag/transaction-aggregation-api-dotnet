using Microsoft.AspNetCore.Mvc;
using TransactionAggregationApi.Data;

namespace TransactionAggregationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getAllCustomers() =>
           Ok(MockDataSource.Customers);
        
    }
}
