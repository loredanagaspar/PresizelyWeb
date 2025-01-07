using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PresizelyWeb.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
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
                   SizeChartJson = @"{
                'S': { 'BustMin': 80, 'BustMax': 90, 'WaistMin': 60, 'WaistMax': 70, 'SleeveMin': 50, 'SleeveMax': 55 },
                'M': { 'BustMin': 90, 'BustMax': 100, 'WaistMin': 70, 'WaistMax': 80, 'SleeveMin': 55, 'SleeveMax': 60 },
                'L': { 'BustMin': 100, 'BustMax': 110, 'WaistMin': 80, 'WaistMax': 90, 'SleeveMin': 60, 'SleeveMax': 65 },
                'XL': { 'BustMin': 110, 'BustMax': 120, 'WaistMin': 90, 'WaistMax': 100, 'SleeveMin': 65, 'SleeveMax': 70 }
            }".Replace("'", "\""),
                   IsTop = true,
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
                   SizeChartJson = @"{
                'S': { 'BustMin': 80, 'BustMax': 90, 'WaistMin': 60, 'WaistMax': 70, 'SleeveMin': 50, 'SleeveMax': 55 },
                'M': { 'BustMin': 90, 'BustMax': 100, 'WaistMin': 70, 'WaistMax': 80, 'SleeveMin': 55, 'SleeveMax': 60 },
                'L': { 'BustMin': 100, 'BustMax': 110, 'WaistMin': 80, 'WaistMax': 90, 'SleeveMin': 60, 'SleeveMax': 65 },
                'XL': { 'BustMin': 110, 'BustMax': 120, 'WaistMin': 90, 'WaistMax': 100, 'SleeveMin': 65, 'SleeveMax': 70 }
            }".Replace("'", "\""),
                   IsTop = true,
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
                   SizeChartJson = @"{
                'S': { 'BustMin': 85, 'BustMax': 95, 'WaistMin': 65, 'WaistMax': 75, 'SleeveMin': 52, 'SleeveMax': 57 },
                'M': { 'BustMin': 95, 'BustMax': 105, 'WaistMin': 75, 'WaistMax': 85, 'SleeveMin': 57, 'SleeveMax': 62 },
                'L': { 'BustMin': 105, 'BustMax': 115, 'WaistMin': 85, 'WaistMax': 95, 'SleeveMin': 62, 'SleeveMax': 67 },
                'XL': { 'BustMin': 115, 'BustMax': 125, 'WaistMin': 95, 'WaistMax': 105, 'SleeveMin': 67, 'SleeveMax': 72 }
            }".Replace("'", "\""),
                   IsTop = true,
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
                   SizeChartJson = @"{
                'S': { 'BustMin': 85, 'BustMax': 95, 'WaistMin': 65, 'WaistMax': 75, 'SleeveMin': 52, 'SleeveMax': 57 },
                'M': { 'BustMin': 95, 'BustMax': 105, 'WaistMin': 75, 'WaistMax': 85, 'SleeveMin': 57, 'SleeveMax': 62 },
                'L': { 'BustMin': 105, 'BustMax': 115, 'WaistMin': 85, 'WaistMax': 95, 'SleeveMin': 62, 'SleeveMax': 67 },
                'XL': { 'BustMin': 115, 'BustMax': 125, 'WaistMin': 95, 'WaistMax': 105, 'SleeveMin': 67, 'SleeveMax': 72 }
            }".Replace("'", "\""),
                   IsTop = true,
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
                   SizeChartJson = @"{
                '32': { 'WaistMin': 76, 'WaistMax': 81, 'HipsMin': 91, 'HipsMax': 96, 'InseamMin': 75, 'InseamMax': 80 },
                '34': { 'WaistMin': 82, 'WaistMax': 87, 'HipsMin': 97, 'HipsMax': 102, 'InseamMin': 75, 'InseamMax': 80 },
                '36': { 'WaistMin': 88, 'WaistMax': 93, 'HipsMin': 103, 'HipsMax': 108, 'InseamMin': 76, 'InseamMax': 81 },
                '38': { 'WaistMin': 94, 'WaistMax': 99, 'HipsMin': 109, 'HipsMax': 114, 'InseamMin': 76, 'InseamMax': 81 }
            }".Replace("'", "\""),
                   IsTop = false,
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
                   SizeChartJson = @"{
                     '32': { 'WaistMin': 76, 'WaistMax': 81, 'HipsMin': 91, 'HipsMax': 96, 'InseamMin': 75, 'InseamMax': 80 },
                       '34': { 'WaistMin': 82, 'WaistMax': 87, 'HipsMin': 97, 'HipsMax': 102, 'InseamMin': 75, 'InseamMax': 80 },
                      '36': { 'WaistMin': 88, 'WaistMax': 93, 'HipsMin': 103, 'HipsMax': 108, 'InseamMin': 76, 'InseamMax': 81 },
                      '38': { 'WaistMin': 94, 'WaistMax': 99, 'HipsMin': 109, 'HipsMax': 114, 'InseamMin': 76, 'InseamMax': 81 }
                   }".Replace("'", "\""),
                   IsTop = false,
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
                   SizeChartJson = @"{
                        '32': { 'WaistMin': 76, 'WaistMax': 81, 'HipsMin': 91, 'HipsMax': 96, 'InseamMin': 75, 'InseamMax': 80 },
                        '34': { 'WaistMin': 82, 'WaistMax': 87, 'HipsMin': 97, 'HipsMax': 102, 'InseamMin': 75, 'InseamMax': 80 },
                        '36': { 'WaistMin': 88, 'WaistMax': 93, 'HipsMin': 103, 'HipsMax': 108, 'InseamMin': 76, 'InseamMax': 81 },
                        '38': { 'WaistMin': 94, 'WaistMax': 99, 'HipsMin': 109, 'HipsMax': 114, 'InseamMin': 76, 'InseamMax': 81 }
                     }".Replace("'", "\""),
                   IsTop = false,
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
                   SizeChartJson = @"{
                       '32': { 'WaistMin': 76, 'WaistMax': 81, 'HipsMin': 91, 'HipsMax': 96, 'InseamMin': 75, 'InseamMax': 80 },
                       '34': { 'WaistMin': 82, 'WaistMax': 87, 'HipsMin': 97, 'HipsMax': 102, 'InseamMin': 75, 'InseamMax': 80 },
                       '36': { 'WaistMin': 88, 'WaistMax': 93, 'HipsMin': 103, 'HipsMax': 108, 'InseamMin': 76, 'InseamMax': 81 },
                        '38': { 'WaistMin': 94, 'WaistMax': 99, 'HipsMin': 109, 'HipsMax': 114, 'InseamMin': 76, 'InseamMax': 81 }
                   }".Replace("'", "\""),
                   IsTop = false,
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
                   SizeChartJson = @"{
                          'S': { 'BustMin': 85, 'BustMax': 95, 'WaistMin': 65, 'WaistMax': 75, 'SleeveMin': 55, 'SleeveMax': 60 },
                          'M': { 'BustMin': 95, 'BustMax': 105, 'WaistMin': 75, 'WaistMax': 85, 'SleeveMin': 60, 'SleeveMax': 65 },
                          'L': { 'BustMin': 105, 'BustMax': 115, 'WaistMin': 85, 'WaistMax': 95, 'SleeveMin': 65, 'SleeveMax': 70 },
                          'XL': { 'BustMin': 115, 'BustMax': 125, 'WaistMin': 95, 'WaistMax': 105, 'SleeveMin': 70, 'SleeveMax': 75 }
                       }".Replace("'", "\""), // Replace single quotes with double quotes for valid JSON
                   IsTop = true,
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
