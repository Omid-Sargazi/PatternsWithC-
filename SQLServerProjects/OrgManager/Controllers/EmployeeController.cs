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
            var deptExists = await _applicationDbContext.Departments.AnyAsync(d => d.Id == employee.DepartmentId);
            if(!deptExists)
                return BadRequest("Invalid DepartmentId");
            _applicationDbContext.Employees.Add(employee);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpGet("hierarchy/{managerId}")]
        public async Task<IActionResult> GetHierarchy(int managerId)
        {
            var allEmployees = await _applicationDbContext.Employees
            .Include(e => e.Subordinates)
            .ToListAsync();

            var root = allEmployees.FirstOrDefault(ae => ae.Id == managerId);
            if (root == null) return NotFound("Manager not found.");
            var tree = BuildEmployeeTree(root, allEmployees);
            return Ok(tree);

        }

        private EmployeeTreeDto BuildEmployeeTree(Employee employee, List<Employee> all)
        {
            return new EmployeeTreeDto
            {
                Id = employee.Id,
                FullName = employee.FullName,
                ManagerId = employee.ManagerId,
                Subordinates = all.Where(e => e.ManagerId == employee.Id)
                .Select(e => BuildEmployeeTree(e, all)).ToList()
            };
        }
    }
}