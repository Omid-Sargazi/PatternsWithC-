using AdventureWorksDatabase.Models;
using Microsoft.EntityFrameworkCore;


namespace AdventureWorksDatabase.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AdventureWorks2019;User Id=sa;Password=15935755Omid$@;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SalesOrderDetail>()
            .HasKey(sod => new { sod.SalesOrderID, sod.SalesOrderDetailID });

            modelBuilder.Entity<Customer>()
            .HasOne(c => c.Person)
            .WithMany(p => p.Customers)
            .HasForeignKey(c => c.PersonId);

            modelBuilder.Entity<SalesOrderHeader>()
            .HasOne(s => s.Customer)
            .WithMany(c => c.SalesOrdersHeaders)
            .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<SalesOrderDetail>()
            .HasOne(s => s.SalesOrderHeader)
            .WithMany(sh => sh.SalesOrderDetails)
            .HasForeignKey(s => s.SalesOrderDetailID);

            modelBuilder.Entity<SalesOrderDetail>()
            .HasOne(s => s.Product)
            .WithMany(p => p.SalesOrderDetails)
            .HasForeignKey(s => s.ProductID);

          


        }
    }
}