using AdventureWorksAPI.Middlewares.AuthorizationHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;
        public ProjectsController(ILogger<ProjectsController> logger)
        {
            _logger = logger;
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanDeleteProject")]
        public IActionResult DeleteProject(int id)
        {
            var project = new Project { Id = id, Name = "Sample Project", OwnerId = "user123" };

            HttpContext.Items["Project"] = project;
            _logger.LogInformation("Project {ProjectId} deleted by user {UserId}", id, User.Identity.Name);
            return Ok($"Project {id} deleted successfully.");
        }
    }
}