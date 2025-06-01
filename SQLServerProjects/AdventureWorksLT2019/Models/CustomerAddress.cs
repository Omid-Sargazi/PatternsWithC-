using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLT2019.Models
{
    [Table("CustomerAddress", Schema = "SalesLT")]
    [PrimaryKey(nameof(CustomerID), nameof(AddressID))]
    public class CustomerAddress
    {

        public int CustomerID { get; set; }

        public int AddressID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }
        [ForeignKey("AddressID")]
        public Address? Address { get; set; }
    }
}