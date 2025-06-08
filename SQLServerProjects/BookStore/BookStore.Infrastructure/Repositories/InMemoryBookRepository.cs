using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;

namespace BookStore.Infrastructure.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new();
        public void Add(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
        }

        public void Delete(int id)
        {
            var book = GetByID(id);
            if (book != null)
                _books.Remove(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public Book? GetByID(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }
    }
}