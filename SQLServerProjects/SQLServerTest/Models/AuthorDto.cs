namespace SQLServerTest.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }

    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}