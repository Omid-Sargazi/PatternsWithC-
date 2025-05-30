using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksLT2019.Models
{
    [Table("CustomerAddress", Schema = "SalesLT")]
    public class CustomerAddress
    {
        [Key]
        public int CustomerID { get; set; }
        [Key]
        public int AddressID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }
        [ForeignKey("AddressID")]
        public Address? Address { get; set; }
    }
}