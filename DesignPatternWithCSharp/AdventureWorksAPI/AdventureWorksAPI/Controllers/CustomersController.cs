using AdventureWorksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("top5")]
        public async Task<IActionResult> GetTop5()
        {
            var customers = await _repository.GetTop5CustomersAsync();
            return Ok(customers);
        }

        [HttpGet("dividezero")]
        public async Task<IActionResult> DivideZero()
        {
            int zero = 0;
            int result = 10 / zero;
            return Ok();
        }
    }
}