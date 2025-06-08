using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        public readonly BookDbContext _context;
        public EFBookRepository(BookDbContext context)
        {
            _context = context;
        }
        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book? GetByID(int id)
        {
            return _context.Books.Find(id);
        }
    }
}