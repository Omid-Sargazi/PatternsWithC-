using ServicesInProjects.Models.DTOs;

namespace ServicesInProjects.Services
{
    public interface IValidationService
    {
        bool ValidateProject(ProjectDto projectDto);
        bool ValidateTasks(TasksDto tasksDto);
        bool ValidateNote(NoteDto noteDto);
    }
}