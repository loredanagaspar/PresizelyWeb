using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresizelyWeb.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Description", "ImageUrl", "Name" },
                values: new object[] { "Blue", "Relaxed fit T-shirt. Round neck and short sleeves.", "/lib/images/nproduct/T-Shirt1.png", "STRIPED T-SHIRT" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Description", "ImageUrl", "Name" },
                values: new object[] { "Lime", "Relaxed fit T-shirt. Round neck and short sleeves. Tone-on-tone embroidered detail on the front.", "/lib/images/nproduct/T-Shirt2.png", "T-SHIRT WITH CONTRAST EMBROIDERY" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/lib/images/nproduct/Shirt2.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "ImageUrl" },
                values: new object[] { "Green", "/lib/images/nproduct/Shirt1.png" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/lib/images/nproduct/Jeans1.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "Description", "ImageUrl", "Name" },
                values: new object[] { "Blue", "Skinny fit jeans. Five-pocket design. Faded and ripped-effect details on the legs. Button-up front fastening.", "/lib/images/nproduct/Jeans2.png", "RIPPED SKINNY FIT" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "Description", "ImageUrl", "Name", "SpecialTag" },
                values: new object[] { "Camel", "Wide-leg trousers in cotton twill. Featuring front pockets, rear welt pockets and ripped detailing on the legs. Zip fly and top button fastening.", "/lib/images/nproduct/Trousers1.png", "WIDE FIT CHINO TROUSERS", "Trendy" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "Description", "ImageUrl", "Material", "Name" },
                values: new object[] { "Vanilla", "Straight-leg trousers made of cotton fabric. Front pockets and welt back pocket detail. Zip fly and top button fastening.", "/lib/images/nproduct/Trousers2.png", "Cotton", "STRAIGHT-LEG CHINOS" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "Description", "ImageUrl", "Material", "Name" },
                values: new object[] { "Dark khaki", "Regular fit overshirt. Featuring a collar, long sleeves with buttoned cuffs, a chest patch pocket and a button-up front.", "/lib/images/nproduct/Jacket1.png", "Suede Leather", "FAUX SUEDE OVERSHIRT" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Color", "Description", "ImageUrl", "IsTop", "Material", "Name", "Price", "Size", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { 10, 5, "Khaki", "Lightweight jacket made of technical fabric. High neck and long sleeves. Hip welt pockets. Inside pocket detail. Ribbed trims. Front zip fastening.", "/lib/images/nproduct/Jacket2.png", true, "Coton", "TECHNICAL BOMBER JACKET", 50.99m, "S,M", "{\r\n                          \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                          \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                          \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 65, \"SleeveMax\": 70 },\r\n                          \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 70, \"SleeveMax\": 75 }\r\n                       }", "Premium", 15 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Description", "ImageUrl", "Name" },
                values: new object[] { "White", "A comfortable plain white T-shirt.", "/lib/images/product/T-shirt1.png", "Plain White T-Shirt" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Description", "ImageUrl", "Name" },
                values: new object[] { "Black", "A stylish graphic T-shirt.", "/lib/images/product/T-Shirt2.png", "Graphic T-Shirt" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/lib/images/product/Shirt1.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "ImageUrl" },
                values: new object[] { "Red", "/lib/images/product/Shirt2.png" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/lib/images/product/Jeans1.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "Description", "ImageUrl", "Name" },
                values: new object[] { "Black", "Stylish black skinny jeans.", "/lib/images/product/Jeans2.png", "Black Skinny Jeans" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "Description", "ImageUrl", "Name", "SpecialTag" },
                values: new object[] { "Khaki", "Smart casual chino trousers.", "/lib/images/product/Trousers1.png", "Chino Trousers", "Smart Casual" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "Description", "ImageUrl", "Material", "Name" },
                values: new object[] { "Grey", "Elegant trousers for formal occasions.", "/lib/images/product/Trousers2.png", "Polyester", "Formal Trousers" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "Description", "ImageUrl", "Material", "Name" },
                values: new object[] { "Black", "A premium leather jacket for stylish outings.", "/lib/images/product/Jacket1.png", "Leather", "Leather Jacket" });
        }
    }
}
