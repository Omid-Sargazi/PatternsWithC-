using ServicesInProjects.Models;
using ServicesInProjects.Models.DTOs;

namespace ServicesInProjects.Services
{
    public class ValidationService : IValidationService
    {
        public bool ValidateNote(NoteDto noteDto)
        {
            if (string.IsNullOrWhiteSpace(noteDto.Content))
                return false;
            if (noteDto.ProjectId < 0)
                return false;
            return true;
        }

        public bool ValidateProject(ProjectDto projectDto)
        {
            if (string.IsNullOrWhiteSpace(projectDto.Name))
                return false;
            if (projectDto.Name.Length > 100)
                return false;
            return true;
        }

        public bool ValidateTasks(TasksDto tasksDto)
        {
            if (string.IsNullOrWhiteSpace(tasksDto.Title))
                return false;
            if (tasksDto.ProjectId < 0)
                return false;
            return true;
        }
    }

}