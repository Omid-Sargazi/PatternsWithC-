using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLT2019_2.Models
{
    [Table("Customer", Schema = "SalesLT")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? CompanyName { get; set; }
    }

    [Table("Product", Schema = "SalesLT")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public decimal ListPrice { get; set; }
        public int? ProductCategoryID { get; set; }
        public int? ProductModelID { get; set; }
        [ForeignKey("ProductCategoryID")]
        public ProductCategory? ProductCategory { get; set; }
        [ForeignKey("ProductModelID")]
        public ProductModel? ProductModel { get; set; }
    }


    [Table("SalesOrderHeader", Schema = "SalesLT")]
    public class SalesOrderHeader
    {
        [Key]
        public int SalesOrderID { get; set; }
        public string? SalesOrderNumber { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalDue { get; set; }
        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }
    }

    [Table("SalesOrderDetail", Schema = "SalesLT")]
    public class SalesOrderDetail
    {
        [Key]
        public int SalesOrderDetailID { get; set; }
        public int SalesOrderID { get; set; }
        public int ProductID { get; set; }
        public short OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        [ForeignKey("SalesOrderID")]
        public SalesOrderHeader? SalesOrderHeader { get; set; }
        [ForeignKey("ProductID")]
        public Product? Product { get; set; }
    }

    [Table("ProductCategory", Schema = "SalesLT")]
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }
        public string? Name { get; set; }
    }

    [Table("Address", Schema = "SalesLT")]
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public string? AddressLine1 { get; set; }
        public string? City { get; set; }
        public string? StateProvince { get; set; }
        public string? CountryRegion { get; set; }
        public string? PostalCode { get; set; }
    }

    [Table("CustomerAddress", Schema = "SalesLT")]
    [PrimaryKey(nameof(CustomerID), nameof(AddressID))]
    public class CustomerAddress
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public string? AddressType { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

        [ForeignKey("AddressID")]
        public Address? Address { get; set; }
    }

    [Table("ProductModel", Schema = "SalesLT")]
    public class ProductModel
    {
        [Key]
        public int ProductModelID { get; set; }
        public string? Name { get; set; }
    }
}