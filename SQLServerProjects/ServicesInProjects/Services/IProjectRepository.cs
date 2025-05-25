using Microsoft.EntityFrameworkCore;
using ServicesInProjects.Data;
using ServicesInProjects.Models;

namespace ServicesInProjects.Services
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int id);
    }

    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.Include(p => p.Taskss).Include(p => p.Notes).ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects
            .Include(p => p.Taskss)
            .Include(p => p.Notes)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}