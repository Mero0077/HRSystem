using HRSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Common.AppDbContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FoodRecipesDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
            }
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
