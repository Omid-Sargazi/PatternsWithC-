using AdventureWorksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        public OrdersController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("qty-over10")]
        public async Task<IActionResult> GetOrdersOver10Qty()
        {
            var result = await _repository.GetOrdersWithQtyOver10Async();
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetOrderCount()
        {
            var result = await _repository.GetTotalOrderCountAsync();
            return Ok(result);
        }

        [HttpGet("sum-high-value")]
        public async Task<IActionResult> GetHighValueOrdersSum()
        {
            var total = await _repository.GetHighValueOrderSumAsync();
            return Ok(total);
        }
    }
}