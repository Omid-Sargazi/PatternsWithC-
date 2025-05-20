using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLServerTest.Models;

namespace SQLServerTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreContext _context;
        public AuthorsController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            return await _context.Authors.Include(a => a.Books).Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                Books = a.Books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                }).ToList()
            }).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            // var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
            // if (author == null) return NotFound();
            // return author;

            var author = await _context.Authors
            .Include(a => a.Books)
            .Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                Books = a.Books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                }).ToList()
            }).FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) return NotFound();
            return author;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorDto authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name,
                Books = authorDto.Books.Select(b => new Book
                {
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                }).ToList()
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            authorDto.Id = author.Id;
            return CreatedAtAction(nameof(GetAuthor), new { id = authorDto.Id }, authorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, AuthorDto authorDto)
        {
            if (id != authorDto.Id) return BadRequest();
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return NotFound();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Authors.Any(a => a.Id == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return NotFound();
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}