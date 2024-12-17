using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Model;


namespace StudentManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasQueryFilter(s => !s.IsDeleted); // Soft Delete Query Filter
        }
    }
}
