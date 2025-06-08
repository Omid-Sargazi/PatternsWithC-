using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetByID(int id);
        void Add(Book book);
        void Delete(int id);
    }
}