using System.ComponentModel.DataAnnotations;

namespace AdvantureWorksDatabse02.Models
{
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

    public class Customer
    {
        public int CustomerID { get; set; }
        public int? PersonID { get; set; }
        public int? StoreID { get; set; }

        // Navigation Properties
        public Person? Person { get; set; }
        public ICollection<SalesOrderHeader> SalesOrders { get; set; } = new List<SalesOrderHeader>();

    }

    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new List<ProductSubcategory>();
    }

    public class ProductSubcategory
    {
        public int ProductSubcategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public ProductCategory ProductCategory { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime? SellEndDate { get; set; }

        // Navigation Properties
        public ProductSubcategory? ProductSubcategory { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
    }


    public class SalesTerritory
    {
        public int TerritoryID { get; set; }
        public string Name { get; set; }
        public string CountryRegionCode { get; set; }

        // Navigation Properties
        public ICollection<SalesOrderHeader> SalesOrders { get; set; } = new List<SalesOrderHeader>();
    }

    public class SalesOrderHeader
    {
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

    public class SalesOrderDetail
    {
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
