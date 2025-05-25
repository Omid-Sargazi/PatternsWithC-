using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoService.GetByIdAsync(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }
        [HttpPost]
        public async Task<IActionResult> Add(TodoItem item)
        {
            await _todoService.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

    }
}