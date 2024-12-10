using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PresizelyWeb.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "T-Shirts" },
            new Category { Id = 2, Name = "Shirts" },
            new Category { Id = 3, Name = "Jeans" },
            new Category { Id = 4, Name = "Trousers" },
            new Category { Id = 5, Name = "Jackets" },
            new Category { Id = 6, Name = "Sweaters" },
            new Category { Id = 7, Name = "Hoodies" },
            new Category { Id = 8, Name = "Shorts" }
             );
        }
    }
}
