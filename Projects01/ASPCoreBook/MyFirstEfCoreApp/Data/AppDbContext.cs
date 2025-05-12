using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp.Models;

namespace MyFirstEfCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=books.db");
        }
    }   
}