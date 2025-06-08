using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> Getll();
        Book? GetByID(int id);
        void Add(Book book);
        void Delete(int id);
    }
}