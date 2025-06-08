using BookStore.Application.Services;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;
        public BooksController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetBooks());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _service.GetBook(id);
            return book == null ? NotFound() : Ok(book);
        }

        public IActionResult Post(Book book)
        {
            _service.AddBook(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteBook(id);
            return NoContent();
        }


    }
}