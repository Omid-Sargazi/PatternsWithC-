using Microsoft.EntityFrameworkCore;
using OrgManager.Models;

namespace OrgManager.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany(e => e.Subordinates)
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}