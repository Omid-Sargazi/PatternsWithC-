using Microsoft.EntityFrameworkCore;
using ServicesInProjects.Data;
using ServicesInProjects.Models;

namespace ServicesInProjects.Services
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task AddAsync(TodoItem item);
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;
        
        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TodoItem item)
        {
            await _context.TodoItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }
    }
}