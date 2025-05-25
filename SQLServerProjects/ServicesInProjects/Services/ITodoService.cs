using System.Threading.Tasks;
using ServicesInProjects.Models;

namespace ServicesInProjects.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task AddAsync(TodoItem item);
    }

    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;
        private readonly ILogger<TodoService> _logger;
        public TodoService(ITodoRepository repository, ILogger<TodoService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task AddAsync(TodoItem item)
        {
            _logger.LogInformation("Add new Todo item:{Title}", item.Title);
            if (string.IsNullOrWhiteSpace(item.Title))
                throw new AggregateException("Title must be fiiled");
            await _repository.AddAsync(item);
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        
    }

}