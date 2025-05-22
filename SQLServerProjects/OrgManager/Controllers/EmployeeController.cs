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
        // public async Task<IActionResult> GetAll() => Ok(await _applicationDbContext.Employees.Include(e => e.Manager).ToListAsync());
        public async Task<IActionResult> GetAll()
        {
            var employees = await _applicationDbContext.Employees
            .Include(e => e.Manager)
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                FullName = e.FullName,
                ManagerId = e.ManagerId,
                ManagerName = e.Manager != null ? e.Manager.FullName : null
            }).ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            _applicationDbContext.Employees.Add(employee);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(employee);
        }
    }
}