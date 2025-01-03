using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PresizelyWeb.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet <ShoppingCart> ShoppingCart{ get; set; }
        public DbSet<OrderHeader> OrderHeader{ get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //Seed Categories
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

            //Seed Products

            builder.Entity<Product>().HasData(
               // T-Shirts
               new Product
               {
                   Id = 1,
                   Name = "Plain White T-Shirt",
                   Price = 12.99M,
                   Size = "S,M,L,XL",
                   Color = "White",
                   Material = "Cotton",
                   Stock = 50,
                   Description = "A comfortable plain white T-shirt.",
                   SpecialTag = "Casual Wear",
                   CategoryId = 1,
                   ImageUrl = "/lib/images/product/T-shirt1.png"
               },
               new Product
               {
                   Id = 2,
                   Name = "Graphic T-Shirt",
                   Price = 15.99M,
                   Size = "S,M,L,XL",
                   Color = "Black",
                   Material = "Cotton",
                   Stock = 40,
                   Description = "A stylish graphic T-shirt.",
                   SpecialTag = "Trendy",
                   CategoryId = 1,
                   ImageUrl = "/lib/images/product/T-Shirt2.png"
               },
               // Shirts
               new Product
               {
                   Id = 3,
                   Name = "Formal Shirt",
                   Price = 29.99M,
                   Size = "S,M,L,XL",
                   Color = "Blue",
                   Material = "Polyester",
                   Stock = 30,
                   Description = "Perfect for office and formal events.",
                   SpecialTag = "Formal",
                   CategoryId = 2,
                   ImageUrl = "/lib/images/product/Shirt1.png"
               },
               new Product
               {
                   Id = 4,
                   Name = "Casual Check Shirt",
                   Price = 25.99M,
                   Size = "S,M,L,XL",
                   Color = "Red",
                   Material = "Cotton",
                   Stock = 35,
                   Description = "A comfortable casual shirt with checkered design.",
                   SpecialTag = "Casual",
                   CategoryId = 2,
                   ImageUrl = "/lib/images/product/Shirt2.png"
               },
               // Jeans
               new Product
               {
                   Id = 5,
                   Name = "Blue Denim Jeans",
                   Price = 39.99M,
                   Size = "32,34,36,38",
                   Color = "Blue",
                   Material = "Denim",
                   Stock = 60,
                   Description = "Classic blue denim jeans.",
                   SpecialTag = "Everyday Wear",
                   CategoryId = 3,
                   ImageUrl = "/lib/images/product/Jeans1.png"
               },
               new Product
               {
                   Id = 6,
                   Name = "Black Skinny Jeans",
                   Price = 42.99M,
                   Size = "32,34,36,38",
                   Color = "Black",
                   Material = "Denim",
                   Stock = 45,
                   Description = "Stylish black skinny jeans.",
                   SpecialTag = "Trendy",
                   CategoryId = 3,
                   ImageUrl = "/lib/images/product/Jeans2.png"
               },
               // Trousers
               new Product
               {
                   Id = 7,
                   Name = "Chino Trousers",
                   Price = 34.99M,
                   Size = "32,34,36,38",
                   Color = "Khaki",
                   Material = "Cotton",
                   Stock = 25,
                   Description = "Smart casual chino trousers.",
                   SpecialTag = "Smart Casual",
                   CategoryId = 4,
                   ImageUrl = "/lib/images/product/Trousers1.png"
               },
               new Product
               {
                   Id = 8,
                   Name = "Formal Trousers",
                   Price = 49.99M,
                   Size = "32,34,36,38",
                   Color = "Grey",
                   Material = "Polyester",
                   Stock = 20,
                   Description = "Elegant trousers for formal occasions.",
                   SpecialTag = "Formal",
                   CategoryId = 4,
                   ImageUrl = "/lib/images/product/Trousers2.png"
               },
               // Jackets
               new Product
               {
                   Id = 9,
                   Name = "Leather Jacket",
                   Price = 99.99M,
                   Size = "S,M",
                   Color = "Black",
                   Material = "Leather",
                   Stock = 15,
                   Description = "A premium leather jacket for stylish outings.",
                   SpecialTag = "Premium",
                   CategoryId = 5,
                   ImageUrl = "/lib/images/product/Jacket1.png"
               }      
           );
        }
    }
}
