namespace SQLServerTest.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }
}