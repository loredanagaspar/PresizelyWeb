using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PresizelyWeb.Data
{
    // ApplicationDbContext inherits from IdentityDbContext to enable ASP.NET Core Identity features for user
    // authentication and authorization.
    // This class serves as the bridge between the database and the application logic by mapping entities to database tables.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Constructor accepts DbContextOptions and passes them to the base class constructor.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet for Category entity, maps the Category model to the "Categories" table in the database.
        public DbSet<Category> Category { get; set; }

        // DbSet for Product entity, maps the Product model to the "Products" table in the database.
        public DbSet<Product> Product { get; set; }

        // DbSet for ShoppingCart entity, maps the ShoppingCart model to the "ShoppingCarts" table in the database.
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        // DbSet for OrderHeader entity, maps the OrderHeader model to the "OrderHeaders" table in the database.
        public DbSet<OrderHeader> OrderHeader { get; set; }

        // DbSet for OrderDetail entity, maps the OrderDetail model to the "OrderDetails" table in the database.
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
                   Name = "STRIPED T-SHIRT",
                   Price = 12.99M,
                   Size = "S,M,L,XL",
                   SizeChartJson = @"{
                'S': { 'ChestMin': 80, 'ChestMax': 90, 'WaistMin': 70, 'WaistMax': 75, 'SleeveLengthMin': 50, 'SleeveLengthMax': 55 },
                'M': { 'ChestMin': 91, 'ChestMax': 96, 'WaistMin': 76, 'WaistMax': 81, 'SleeveLengthMin': 55, 'SleeveLengthMax': 60 },
                'L': { 'ChestMin': 97, 'ChestMax': 102, 'WaistMin': 82, 'WaistMax': 87, 'SleeveLengthMin': 60, 'SleeveLengthMax': 65 },
                'XL': { 'ChestMin': 103, 'ChestMax': 110, 'WaistMin': 88, 'WaistMax': 95, 'SleeveLengthMin': 65, 'SleeveLengthMax': 70 }
            }".Replace("'", "\""),
                   IsTop = true,
                   Color = "Blue",
                   Material = "Cotton",
                   Stock = 50,
                   Description = "Relaxed fit T-shirt. Round neck and short sleeves.",
                   SpecialTag = "Casual Wear",
                   CategoryId = 1,
                   ImageUrl = "/lib/images/nproduct/T-Shirt1.png"
               },
        // 2. RELAXED T-SHIRT
        new Product
        {
            Id = 2,
            Name = "RELAXED T-SHIRT",
            Price = 15.99M,
            Size = "S,M,L,XL",
            SizeChartJson = @"{
                'S': { 'ChestMin': 80, 'ChestMax': 90, 'WaistMin': 70, 'WaistMax': 75, 'SleeveLengthMin': 50, 'SleeveLengthMax': 55 },
                'M': { 'ChestMin': 91, 'ChestMax': 96, 'WaistMin': 76, 'WaistMax': 81, 'SleeveLengthMin': 55, 'SleeveLengthMax': 60 },
                'L': { 'ChestMin': 97, 'ChestMax': 102, 'WaistMin': 82, 'WaistMax': 87, 'SleeveLengthMin': 60, 'SleeveLengthMax': 65 },
                'XL': { 'ChestMin': 103, 'ChestMax': 110, 'WaistMin': 88, 'WaistMax': 95, 'SleeveLengthMin': 65, 'SleeveLengthMax': 70 }
            }".Replace("'", "\""),
            IsTop = true,
            Color = "Lime",
            Material = "Cotton",
            Stock = 40,
            Description = "Relaxed fit T-shirt with tone-on-tone embroidered detail.",
            SpecialTag = "Trendy",
            CategoryId = 1,
            ImageUrl = "/lib/images/nproduct/T-Shirt2.png"
        },
        // 3. FORMAL SHIRT
        new Product
        {
            Id = 3,
            Name = "FORMAL SHIRT",
            Price = 29.99M,
            Size = "S,M,L,XL",
            SizeChartJson = @"{
                'S': { 'ChestMin': 85, 'ChestMax': 95, 'WaistMin': 70, 'WaistMax': 75, 'SleeveLengthMin': 52, 'SleeveLengthMax': 57 },
                'M': { 'ChestMin': 96, 'ChestMax': 105, 'WaistMin': 76, 'WaistMax': 81, 'SleeveLengthMin': 57, 'SleeveLengthMax': 62 },
                'L': { 'ChestMin': 106, 'ChestMax': 115, 'WaistMin': 82, 'WaistMax': 87, 'SleeveLengthMin': 62, 'SleeveLengthMax': 67 },
                'XL': { 'ChestMin': 116, 'ChestMax': 125, 'WaistMin': 88, 'WaistMax': 95, 'SleeveLengthMin': 67, 'SleeveLengthMax': 72 }
            }".Replace("'", "\""),
            IsTop = true,
            Color = "Blue",
            Material = "Polyester",
            Stock = 30,
            Description = "Perfect for office and formal events.",
            SpecialTag = "Formal",
            CategoryId = 2,
            ImageUrl = "/lib/images/nproduct/Shirt2.png"
        },
        // 4. BLUE DENIM JEANS
        new Product
        {
            Id = 4,
            Name = "BLUE DENIM JEANS",
            Price = 39.99M,
            Size = "32,34,36,38",
            SizeChartJson = @"{
                '32': { 'WaistMin': 70, 'WaistMax': 76, 'HipsMin': 90, 'HipsMax': 96, 'InseamMin': 75, 'InseamMax': 80 },
                '34': { 'WaistMin': 77, 'WaistMax': 83, 'HipsMin': 97, 'HipsMax': 103, 'InseamMin': 80, 'InseamMax': 85 },
                '36': { 'WaistMin': 84, 'WaistMax': 90, 'HipsMin': 104, 'HipsMax': 110, 'InseamMin': 85, 'InseamMax': 90 },
                '38': { 'WaistMin': 91, 'WaistMax': 97, 'HipsMin': 111, 'HipsMax': 117, 'InseamMin': 90, 'InseamMax': 95 }
            }".Replace("'", "\""),
            IsTop = false,
            Color = "Blue",
            Material = "Denim",
            Stock = 60,
            Description = "Classic blue denim jeans.",
            SpecialTag = "Everyday Wear",
            CategoryId = 3,
            ImageUrl = "/lib/images/nproduct/Jeans1.png"
        },
              new Product
              {
                  Id = 5,
                  Name = "RIPPED SKINNY FIT JEANS",
                  Price = 42.99M,
                  Size = "32,34,36,38",
                  SizeChartJson = @"{
            '32': { 'WaistMin': 70, 'WaistMax': 76, 'HipsMin': 90, 'HipsMax': 96, 'InseamMin': 75, 'InseamMax': 80 },
            '34': { 'WaistMin': 77, 'WaistMax': 83, 'HipsMin': 97, 'HipsMax': 103, 'InseamMin': 80, 'InseamMax': 85 },
            '36': { 'WaistMin': 84, 'WaistMax': 90, 'HipsMin': 104, 'HipsMax': 110, 'InseamMin': 85, 'InseamMax': 90 },
            '38': { 'WaistMin': 91, 'WaistMax': 97, 'HipsMin': 111, 'HipsMax': 117, 'InseamMin': 90, 'InseamMax': 95 }
        }".Replace("'", "\""),
                  IsTop = false,
                  Color = "Blue",
                  Material = "Denim",
                  Stock = 45,
                  Description = "Skinny-fit jeans with ripped-effect details.",
                  SpecialTag = "Trendy",
                  CategoryId = 3,
                  ImageUrl = "/lib/images/nproduct/Jeans2.png"
              },
    // 6. WIDE FIT CHINO TROUSERS
    new Product
    {
        Id = 6,
        Name = "WIDE FIT CHINO TROUSERS",
        Price = 34.99M,
        Size = "32,34,36,38",
        SizeChartJson = @"{
            '32': { 'WaistMin': 76, 'WaistMax': 81, 'HipsMin': 91, 'HipsMax': 96, 'InseamMin': 75, 'InseamMax': 80 },
            '34': { 'WaistMin': 82, 'WaistMax': 87, 'HipsMin': 97, 'HipsMax': 102, 'InseamMin': 80, 'InseamMax': 85 },
            '36': { 'WaistMin': 88, 'WaistMax': 93, 'HipsMin': 103, 'HipsMax': 108, 'InseamMin': 85, 'InseamMax': 90 },
            '38': { 'WaistMin': 94, 'WaistMax': 99, 'HipsMin': 109, 'HipsMax': 114, 'InseamMin': 90, 'InseamMax': 95 }
        }".Replace("'", "\""),
        IsTop = false,
        Color = "Camel",
        Material = "Cotton",
        Stock = 25,
        Description = "Wide-fit chino trousers in cotton twill.",
        SpecialTag = "Trendy",
        CategoryId = 4,
        ImageUrl = "/lib/images/nproduct/Trousers1.png"
    },
    // 7. STRAIGHT-LEG CHINOS
    new Product
    {
        Id = 7,
        Name = "STRAIGHT-LEG CHINOS",
        Price = 49.99M,
        Size = "32,34,36,38",
        SizeChartJson = @"{
            '32': { 'WaistMin': 76, 'WaistMax': 81, 'HipsMin': 91, 'HipsMax': 96, 'InseamMin': 75, 'InseamMax': 80 },
            '34': { 'WaistMin': 82, 'WaistMax': 87, 'HipsMin': 97, 'HipsMax': 102, 'InseamMin': 80, 'InseamMax': 85 },
            '36': { 'WaistMin': 88, 'WaistMax': 93, 'HipsMin': 103, 'HipsMax': 108, 'InseamMin': 85, 'InseamMax': 90 },
            '38': { 'WaistMin': 94, 'WaistMax': 99, 'HipsMin': 109, 'HipsMax': 114, 'InseamMin': 90, 'InseamMax': 95 }
        }".Replace("'", "\""),
        IsTop = false,
        Color = "Vanilla",
        Material = "Cotton",
        Stock = 20,
        Description = "Straight-leg chinos with zip fly.",
        SpecialTag = "Formal",
        CategoryId = 4,
        ImageUrl = "/lib/images/nproduct/Trousers2.png"
    },
    // 8. FAUX SUEDE OVERSHIRT
    new Product
    {
        Id = 8,
        Name = "FAUX SUEDE OVERSHIRT",
        Price = 99.99M,
        Size = "S,M,L,XL",
        SizeChartJson = @"{
            'S': { 'ChestMin': 85, 'ChestMax': 90, 'WaistMin': 70, 'WaistMax': 75, 'SleeveLengthMin': 55, 'SleeveLengthMax': 60 },
            'M': { 'ChestMin': 91, 'ChestMax': 96, 'WaistMin': 76, 'WaistMax': 81, 'SleeveLengthMin': 60, 'SleeveLengthMax': 65 },
            'L': { 'ChestMin': 97, 'ChestMax': 102, 'WaistMin': 82, 'WaistMax': 87, 'SleeveLengthMin': 65, 'SleeveLengthMax': 70 },
            'XL': { 'ChestMin': 103, 'ChestMax': 110, 'WaistMin': 88, 'WaistMax': 95, 'SleeveLengthMin': 70, 'SleeveLengthMax': 75 }
        }".Replace("'", "\""),
        IsTop = true,
        Color = "Dark Khaki",
        Material = "Suede",
        Stock = 15,
        Description = "Overshirt with a regular fit and chest patch pocket.",
        SpecialTag = "Premium",
        CategoryId = 5,
        ImageUrl = "/lib/images/nproduct/Jacket1.png"
    },
    // 9. TECHNICAL BOMBER JACKET
    new Product
    {
        Id = 9,
        Name = "TECHNICAL BOMBER JACKET",
        Price = 50.99M,
        Size = "S,M,L,XL",
        SizeChartJson = @"{
            'S': { 'ChestMin': 85, 'ChestMax': 90, 'WaistMin': 70, 'WaistMax': 75, 'SleeveLengthMin': 55, 'SleeveLengthMax': 60 },
            'M': { 'ChestMin': 91, 'ChestMax': 96, 'WaistMin': 76, 'WaistMax': 81, 'SleeveLengthMin': 60, 'SleeveLengthMax': 65 },
            'L': { 'ChestMin': 97, 'ChestMax': 102, 'WaistMin': 82, 'WaistMax': 87, 'SleeveLengthMin': 65, 'SleeveLengthMax': 70 },
            'XL': { 'ChestMin': 103, 'ChestMax': 110, 'WaistMin': 88, 'WaistMax': 95, 'SleeveLengthMin': 70, 'SleeveLengthMax': 75 }
        }".Replace("'", "\""),
        IsTop = true,
        Color = "Khaki",
        Material = "Cotton",
        Stock = 15,
        Description = "Lightweight bomber jacket with ribbed trims and zip fastening.",
        SpecialTag = "Premium",
        CategoryId = 5,
        ImageUrl = "/lib/images/nproduct/Jacket2.png"
    }
);
        }
    }
}
