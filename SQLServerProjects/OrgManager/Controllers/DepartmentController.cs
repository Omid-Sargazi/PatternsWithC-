using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrgManager.Database;
using OrgManager.Models;

namespace OrgManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Department created", department.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _context.Departments
            .Include(d => d.ParentDepartment)
            .Select(d => new
            {
                d.Id,
                d.Name,
                d.ParentDepartmentId,
                ParentName = d.ParentDepartment != null ? d.ParentDepartment.Name : null
            }).ToListAsync();
            return Ok(departments);
        }
    }
}