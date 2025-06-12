using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantureWorksDatabse02.Models
{
     [Table("Employee",Schema ="HumanResources")]

    public class Employee
    {
        [Key]
        public int BusinessEntityID { get; set; }
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; }

        // Navigation Properties
        public Person Person { get; set; }
        public ICollection<SalesOrderHeader> SalesOrders { get; set; } = new List<SalesOrderHeader>();
    }

     [Table("Customer",Schema ="Sales")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public int? PersonID { get; set; }
        public int? StoreID { get; set; }

        // Navigation Properties
        public Person? Person { get; set; }
        public ICollection<SalesOrderHeader> SalesOrders { get; set; } = new List<SalesOrderHeader>();

    }

    [Table("ProductCategory",Schema ="Production")]
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new List<ProductSubcategory>();
    }
    [Table("ProductSubcategory",Schema ="Production")]
    public class ProductSubcategory
    {
        [Key]
        public int ProductSubcategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public ProductCategory ProductCategory { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

     [Table("Product", Schema = "Production")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime? SellEndDate { get; set; }

        // Navigation Properties
        public ProductSubcategory? ProductSubcategory { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
    }

     [Table("SalesTerritory", Schema = "Sales")]
    public class SalesTerritory
    {
        [Key]
        public int TerritoryID { get; set; }
        public string Name { get; set; }
        public string CountryRegionCode { get; set; }

        // Navigation Properties
        public ICollection<SalesOrderHeader> SalesOrders { get; set; } = new List<SalesOrderHeader>();
    }

     [Table("SalesOrderHeader", Schema = "Sales")]
    public class SalesOrderHeader
    {
        [Key]
        public int SalesOrderID { get; set; }
        public int CustomerID { get; set; }
        public int? SalesPersonID { get; set; }
        public int? TerritoryID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalDue { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public Employee? SalesPerson { get; set; }
        public SalesTerritory? Territory { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
    }

    [Table("SalesOrderDetail", Schema = "Sales")]
    public class SalesOrderDetail
    {
        [Key]
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public int ProductID { get; set; }
        public short OrderQty { get; set; }
        public decimal LineTotal { get; set; }

        // Navigation Properties
        public SalesOrderHeader SalesOrder { get; set; }
        public Product Product { get; set; }
    }
}
