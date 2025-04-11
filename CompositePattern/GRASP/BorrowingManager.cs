namespace CompositePattern.GRASP
{
    public class BorrowingManager
    {
        public void BorrowBook(Book book, User user)
        {
            book.Borrow();
            user.BorrowedBooks.Add(book);
            Console.WriteLine($"{user.Name} borrowed {book.Title}");
        }
    }
}