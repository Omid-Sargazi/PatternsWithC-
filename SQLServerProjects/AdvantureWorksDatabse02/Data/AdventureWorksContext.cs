using AdvantureWorksDatabse02.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvantureWorksDatabse02.Data
{
    public class AdventureWorksContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesTerritory> SalesTerritories { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AdventureWorks2019;User Id=sa;Password=15935755Omid$@;Encrypt=False;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Person - Employee (1:0..1)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Person)
                .WithOne(p => p.Employee)
                .HasForeignKey<Employee>(e => e.BusinessEntityID);

            // Person - Customer (1:0..1)
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Person)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(c => c.PersonID);

            // ProductCategory - ProductSubcategory (1:Many)
            modelBuilder.Entity<ProductSubcategory>()
                .HasOne(ps => ps.ProductCategory)
                .WithMany(pc => pc.ProductSubcategories)
                .HasForeignKey(ps => ps.ProductCategoryID);

            // ProductSubcategory - Product (1:Many)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductSubcategory)
                .WithMany(ps => ps.Products)
                .HasForeignKey(p => p.ProductSubcategoryID);

            // Customer - SalesOrderHeader (1:Many)
            modelBuilder.Entity<SalesOrderHeader>()
                .HasOne(so => so.Customer)
                .WithMany(c => c.SalesOrders)
                .HasForeignKey(so => so.CustomerID);

            // Employee - SalesOrderHeader (1:Many)
            modelBuilder.Entity<SalesOrderHeader>()
                .HasOne(so => so.SalesPerson)
                .WithMany(e => e.SalesOrders)
                .HasForeignKey(so => so.SalesPersonID);

            // SalesTerritory - SalesOrderHeader (1:Many)
            modelBuilder.Entity<SalesOrderHeader>()
                .HasOne(so => so.Territory)
                .WithMany(st => st.SalesOrders)
                .HasForeignKey(so => so.TerritoryID);

            // SalesOrderHeader - SalesOrderDetail (1:Many)
            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(sod => sod.SalesOrder)
                .WithMany(so => so.SalesOrderDetails)
                .HasForeignKey(sod => sod.SalesOrderID);

            // Product - SalesOrderDetail (1:Many)
            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(sod => sod.Product)
                .WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(sod => sod.ProductID);

            // Composite Key for SalesOrderDetail
            modelBuilder.Entity<SalesOrderDetail>()
                .HasKey(sod => new { sod.SalesOrderID, sod.SalesOrderDetailID });
        }
    }
}