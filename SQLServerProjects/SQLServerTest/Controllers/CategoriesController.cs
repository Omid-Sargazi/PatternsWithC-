using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLServerTest.Models;

namespace SQLServerTest.Controllers
{
    public class CategoriesController : ControllerBase
    {
        private readonly BookStoreContext _context;
        public CategoriesController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _context.Categories
            .Include(c=>c.Books).Select(c=>new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Books = c.Books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    CategoryId = b.CategoryId
                }).ToList()


            }).ToListAsync();
                return categories;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories
            .Include(c => c.Books)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Books = c.Books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    CategoryId = b.CategoryId
                }).ToList()
            }).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto category)
        {

        }
    }
}