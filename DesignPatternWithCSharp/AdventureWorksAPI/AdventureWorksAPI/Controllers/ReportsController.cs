using AdventureWorksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository _repository;
        public ReportsController(IReportRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("products-per-category")]
        public async Task<IActionResult> GetProductsPerCategory()
        {
            var result = await _repository.GetProductCountsPerCategoryAsync();
            return Ok(result);
        }

        [HttpGet("total-spent-per-customer")]
        public async Task<IActionResult> GetTotalSpentPerCustomer()
        {
            var result = await _repository.GetTotalSpentPerCustomerAsync();
            return Ok(result);
        }

        [HttpGet("avg-qty-per-product")]
        public async Task<IActionResult> GetAvgQtyPerProduct()
        {
            var result = await _repository.GetAvgOrderQtyPerProductAsync();
            return Ok(result);
        }

        [HttpGet("top10-orders")]
        public async Task<IActionResult> GetTop10Orders()
        {
            var result = await _repository.GetTop10OrdersAsync();
            return Ok(result);
        }
    }
}