using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PresizelyWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Color", "Description", "ImageUrl", "Material", "Name", "Price", "Size", "SpecialTag", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "White", "A comfortable plain white T-shirt.", "/lib/images/product/T-shirt1.png", "Cotton", "Plain White T-Shirt", 12.99m, "M", "Casual Wear", 50 },
                    { 2, 1, "Black", "A stylish graphic T-shirt.", "/lib/images/product/T-Shirt2.png", "Cotton", "Graphic T-Shirt", 15.99m, "L", "Trendy", 40 },
                    { 3, 2, "Blue", "Perfect for office and formal events.", "/lib/images/product/Shirt1.png", "Polyester", "Formal Shirt", 29.99m, "L", "Formal", 30 },
                    { 4, 2, "Red", "A comfortable casual shirt with checkered design.", "/lib/images/product/Shirt2.png", "Cotton", "Casual Check Shirt", 25.99m, "M", "Casual", 35 },
                    { 5, 3, "Blue", "Classic blue denim jeans.", "/lib/images/product/Jeans1.png", "Denim", "Blue Denim Jeans", 39.99m, "32", "Everyday Wear", 60 },
                    { 6, 3, "Black", "Stylish black skinny jeans.", "/lib/images/product/Jeans2.png", "Denim", "Black Skinny Jeans", 42.99m, "30", "Trendy", 45 },
                    { 7, 4, "Khaki", "Smart casual chino trousers.", "/lib/images/product/Trousers1.png", "Cotton", "Chino Trousers", 34.99m, "34", "Smart Casual", 25 },
                    { 8, 4, "Grey", "Elegant trousers for formal occasions.", "/lib/images/product/Trousers2.png", "Polyester", "Formal Trousers", 49.99m, "36", "Formal", 20 },
                    { 9, 5, "Black", "A premium leather jacket for stylish outings.", "/lib/images/product/Jacket1.png", "Leather", "Leather Jacket", 99.99m, "M", "Premium", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
