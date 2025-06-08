using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;

namespace BookStore.Application.Services
{
    public class BookService
    {
        private readonly IBookRepository _repo;
        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }


        public IEnumerable<Book> GetBooks() => _repo.GetAll();
        public Book? GetBook(int id) => _repo.GetByID(id);
        public void AddBook(Book book) => _repo.Add(book);
        public void DeleteBook(int id) => _repo.Delete(id);
    }
}