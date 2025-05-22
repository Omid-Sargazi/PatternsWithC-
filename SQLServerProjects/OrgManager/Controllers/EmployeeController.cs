using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrgManager.Database;
using OrgManager.Models;

namespace OrgManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _applicationDbContext.Employees.Include(e => e.Manager).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            _applicationDbContext.Employees.Add(employee);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(employee);
        }
    }
}