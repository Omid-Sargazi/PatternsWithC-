using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrgManager.Database;
using OrgManager.Models;

namespace OrgManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("flat")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories
            .Include(c => c.ParentCategory)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId,
                ParentCategoryName = c.ParentCategory != null ? c.ParentCategory.Name : null
            }).ToListAsync();
            return Ok(categories);
        }

        [HttpGet("tree")]
        public async Task<IActionResult> GetTree()
        {
            var rootCategories = await _context.Categories
            .Where(c => c.ParentCategoryId == null)
            .Include(c => c.SubCategories)
            .ToListAsync();

            var result = rootCategories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                SubCategories = c.SubCategories.Select(sc => new SubCategoryDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                }).ToList()
            });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                ParentCategoryId = categoryDto.ParentCategoryId
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Category created.", category.Id });
        }
    }
}