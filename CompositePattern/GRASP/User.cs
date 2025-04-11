namespace CompositePattern.GRASP
{
    public class User{
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
    }
}