using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
            .Include(c => c.Books).Select(c => new CategoryDto
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
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            categoryDto.Id = category.Id;
            return CreatedAtAction(nameof(GetCategory), new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest();
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            category.Name = categoryDto.Name;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Categories.Any(c => c.Id == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync();
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}