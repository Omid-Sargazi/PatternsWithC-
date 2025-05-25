using ServicesInProjects.Models;

namespace ServicesInProjects.Services
{
    public interface ITodoService
    {
        List<TodoItem> GetAll();
        TodoItem GetById(int id);
        void Add(TodoItem item);
    }

    public class TodoService : ITodoService
    {
        private static List<TodoItem> _todos = new List<TodoItem>();
        public void Add(TodoItem item)
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));

            if (_todos.Any(x => x.Id == item.Id))
                throw new InvalidOperationException("item is ");
            _todos.Add(item);
        }

        public List<TodoItem> GetAll()
        {
            return _todos;
        }

        public TodoItem GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }
    }

}