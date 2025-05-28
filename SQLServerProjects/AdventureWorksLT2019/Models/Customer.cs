using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksLT2019.Models
{
    [Table("Customer", Schema = "SalesLT")]
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? EmailAddress { get; set; }

        public ICollection<SalesOrderHeader>? SalesOrderHeaders { get; set; }
    }
}