using Microsoft.EntityFrameworkCore;
using ServicesInProjects.Models;

namespace ServicesInProjects.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tasks> Taskss { get; set; }
        public DbSet<Note> Notes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
            .HasOne(t => t.Project)
            .WithMany(p => p.Taskss)
            .HasForeignKey(t => t.ProjectId);

            modelBuilder.Entity<Note>()
            .HasOne(n => n.Project)
            .WithMany(p => p.Notes)
            .HasForeignKey(n => n.ProjectId);
        }
    }
}