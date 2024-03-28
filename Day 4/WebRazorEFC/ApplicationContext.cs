using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WebRazorEFC
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; } = null;

        public ApplicationContext() { }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base (options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = Program.config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = 1, Title = "C# 12", Duration = 40, Description = "C# Intro" },
                new Course() { Id = 2, Title = "C# Client-Server", Duration = 40, Description = "Creating service with c#" },
                new Course() { Id = 3, Title = "JavaScript", Duration = 24, Description = "JavaScript Intro" },
                new Course() { Id = 4, Title = "Java 1", Duration = 40, Description = "Java Intro" }
            );
        }
    }
}
