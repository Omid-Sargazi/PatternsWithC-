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
    }
}