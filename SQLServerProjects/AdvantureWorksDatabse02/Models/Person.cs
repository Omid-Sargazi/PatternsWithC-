using System.ComponentModel.DataAnnotations;

namespace AdvantureWorksDatabse02.Models
{
    public class Person
    {
        [Key]
        public int BusinessEntityID { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    
    // Navigation Properties
    public Employee? Employee { get; set; }
    public Customer? Customer { get; set; }
    }
}