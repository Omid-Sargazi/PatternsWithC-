using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ServicesInProjects.Models.DTOs;
using ServicesInProjects.Services;

namespace ServicesInProjects.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectDto projectDto)
        {
            await _projectService.AddAsync(projectDto);
            return CreatedAtAction(nameof(GetById), new { id = projectDto.Id }, projectDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProjectDto projectDto)
        {
            await _projectService.UpdateAsync(id, projectDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectService.DeleteAsync(id);
            return NoContent();
        }
    }
}