using ServicesInProjects.Data;
using ServicesInProjects.Models;
using ServicesInProjects.Models.DTOs;

namespace ServicesInProjects.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllAsync();
        Task<ProjectDto> GetByIdAsync(int id);
        Task AddAsync(ProjectDto projectDto);
        Task UpdateAsync(int id, ProjectDto projectDto);
        Task DeleteAsync(int id);
    }

    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IValidationService _validation;
        public ProjectService(IProjectRepository repository, IValidationService validation)
        {
            _repository = repository;
            _validation = validation;
        }
        public async Task AddAsync(ProjectDto projectDto)
        {
            if (!_validation.ValidateProject(projectDto))
                throw new ArgumentNullException("Project information is not valid");
            var project = new Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description
            };
            await _repository.AddAsync(project);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
            var projects = await _repository.GetAllAsync();
            return projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
            }).ToList();
        }

        public async Task<ProjectDto> GetByIdAsync(int id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null) return null;
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }

        public async Task UpdateAsync(int id, ProjectDto projectDto)
        {
            if (_validation.ValidateProject(projectDto))
                throw new ArgumentException("Projects information are not valid");
            var project = await _repository.GetByIdAsync(id);
            if (project == null) throw new ArgumentException("Project is not here");

            project.Name = projectDto.Name;
            project.Description = projectDto.Description;
            await _repository.UpdateAsync(project);
        }
    }
}