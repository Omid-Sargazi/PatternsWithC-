using Microsoft.AspNetCore.Mvc;
using ServicesInProjects.Models;
using ServicesInProjects.Services;

namespace ServicesInProjects.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_todoService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }
        [HttpPost]
        public IActionResult Add(TodoItem item)
        {
            _todoService.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

    }
}