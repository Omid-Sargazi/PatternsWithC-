using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AdventureWorksConsole.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal ListPrice { get; set; }
        public bool MakeFlag { get; set; }
        public DateTime SellStartDate { get; set; }
        [Column("ProductModelID")]
        public int? ProductModelId { get; set; }
    }

    [Table("ProductModel", Schema = "Production")]
    public class ProductModel
    {
        [Key]
        public int ProductModelId { get; set; }
        public string? Name { get; set; }
    }

    [Table("SalesOrderDetail", Schema = "Sales")]
    public class SalesOrderDetail
    {
        [Key]
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public short OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
    }

    [Table("Customer", Schema = "Sales")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? AccountNumber { get; set; }

        public int? PersonId { get; set; }
        public string? State { get; set; }
    }

    [Table("Person", Schema = "Person")]
    public class Person
    {
        [Key]
        public int BusinessEntityId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    [Table("EmailAddress", Schema = "Person")]
    public class EmailAddress
    {
        [Key]
        public int EmailAddressID { get; set; }
        public int BusinessEntityId { get; set; }
        [Column("EmailAddress")]
        public string? Email { get; set; }
    }

    [Table("Address", Schema = "Person")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [MaxLength(60)]
        public string? AddressLine1 { get; set; }

        [MaxLength(60)]
        public string? AddressLine2 { get; set; }

        [MaxLength(30)]
        public string? City { get; set; }

        public int StateProvinceId { get; set; }
        [MaxLength(15)]
        public string? PostalCode { get; set; }

        
    }
}