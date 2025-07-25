using AdventureWorksAPI.Middlewares.ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
   [ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateTask([FromBody] TaskModel model)
    {
        if (string.IsNullOrEmpty(model.Title))
        {
            throw new ValidationExceptions("Task title cannot be empty.");
        }
        return Ok(new { Id = 1, Title = model.Title });
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(int id)
    {
        if (id != 1) // فرض می‌کنیم فقط وظیفه با ID=1 وجود داره
        {
            throw new NotFoundException($"Task with ID {id} not found.");
        }
        return Ok(new { Id = id, Title = "Sample Task" });
    }
}

    public class TaskModel
    {
        public string Title { get; set; }
    }
}