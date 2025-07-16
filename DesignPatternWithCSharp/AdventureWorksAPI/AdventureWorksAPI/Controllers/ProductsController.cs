using AdventureWorksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10()
        {
            var result = await _repository.GetTop10ProductsAsync();
            return Ok(result);
        }
        [HttpGet("over1000")]
        public async Task<IActionResult> GetProductsOver1000()
        {
            var result = await _repository.GetProductsOver1000Async();
            return Ok(result);
        }

        [HttpGet("price-desc")]
        public async Task<IActionResult> GetProductsOrderedByPriceDesc()
        {
            var result = await _repository.GetOrderedByPriceDescAsync();
            return Ok(result);
        }

        [HttpGet("total-count")]
        public async Task<IActionResult> GetTotalProductCount()
        {
            var result = await _repository.GetTotalProductCountAsync();
            return Ok(result);
        }

        [HttpGet("with-subcategory")]
        public async Task<IActionResult> GetProductsWithSubcategory()
        {
            var result = await _repository.GetProductsWithSubcategoryAsync();
            return Ok(result);
        }
    }
}