using BulkyWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options) {
           
        }

        public DbSet<Student> Students { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { id = 1, name = "Shaheer", dept = "Natural Science" },
                new Student { id = 2, name = "Saboor", dept = "Engineering" },
                new Student { id = 3, name = "Laiba", dept = "Computer Science" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
