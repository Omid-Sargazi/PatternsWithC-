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
        public int ProductSubcategoryID { get; set; }
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

    [Table("BusinessEntityAddress", Schema = "Person")]
    public class BusinessEntityAddress
    {
        [Key]
        public int BusinessEntityId { get; set; }

        public int AddressId { get; set; }

        public int AddressTypeId { get; set; }

        // ✅ Navigation Properties
        [ForeignKey("BusinessEntityId")]
        public Person? Person { get; set; }  // یا Store یا Employee بسته به استفاده

        [ForeignKey("AddressId")]
        public Address? Address { get; set; }

        [ForeignKey("AddressTypeId")]
        public AddressType? AddressType { get; set; }
    }

    [Table("StateProvince", Schema = "Person")]
    public class StateProvince
    {
        [Key]
        public int StateProvinceId { get; set; }

        [MaxLength(3)]
        public string? StateProvinceCode { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        public int CountryRegionId { get; set; }

        // ✅ Navigation
        public ICollection<Address>? Addresses { get; set; }
    }

    [Table("AddressType", Schema = "Person")]
    public class AddressType
    {
        [Key]
        public int AddressTypeId { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        // ✅ Navigation
        public ICollection<BusinessEntityAddress>? BusinessEntityAddresses { get; set; }
    }

    public class SalesOrderHeader
    {
        [Key]
        public int SalesOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalDue { get; set; }

    }

    [Table("ProductSubcategory",Schema ="Production")]
    public class ProductSubcategory
    {
        [Key]
        public int ProductSubcategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }

    }
}