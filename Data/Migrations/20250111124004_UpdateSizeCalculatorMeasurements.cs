using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresizelyWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSizeCalculatorMeasurements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeChartJson",
                value: "{\r\n                \"S\": { \"ChestMin\": 80, \"ChestMax\": 90, \"WaistMin\": 70, \"WaistMax\": 75, \"SleeveLengthMin\": 50, \"SleeveLengthMax\": 55 },\r\n                \"M\": { \"ChestMin\": 91, \"ChestMax\": 96, \"WaistMin\": 76, \"WaistMax\": 81, \"SleeveLengthMin\": 55, \"SleeveLengthMax\": 60 },\r\n                \"L\": { \"ChestMin\": 97, \"ChestMax\": 102, \"WaistMin\": 82, \"WaistMax\": 87, \"SleeveLengthMin\": 60, \"SleeveLengthMax\": 65 },\r\n                \"XL\": { \"ChestMin\": 103, \"ChestMax\": 110, \"WaistMin\": 88, \"WaistMax\": 95, \"SleeveLengthMin\": 65, \"SleeveLengthMax\": 70 }\r\n            }");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "SizeChartJson" },
                values: new object[] { "Relaxed fit T-shirt with tone-on-tone embroidered detail.", "RELAXED T-SHIRT", "{\r\n                \"S\": { \"ChestMin\": 80, \"ChestMax\": 90, \"WaistMin\": 70, \"WaistMax\": 75, \"SleeveLengthMin\": 50, \"SleeveLengthMax\": 55 },\r\n                \"M\": { \"ChestMin\": 91, \"ChestMax\": 96, \"WaistMin\": 76, \"WaistMax\": 81, \"SleeveLengthMin\": 55, \"SleeveLengthMax\": 60 },\r\n                \"L\": { \"ChestMin\": 97, \"ChestMax\": 102, \"WaistMin\": 82, \"WaistMax\": 87, \"SleeveLengthMin\": 60, \"SleeveLengthMax\": 65 },\r\n                \"XL\": { \"ChestMin\": 103, \"ChestMax\": 110, \"WaistMin\": 88, \"WaistMax\": 95, \"SleeveLengthMin\": 65, \"SleeveLengthMax\": 70 }\r\n            }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "SizeChartJson" },
                values: new object[] { "FORMAL SHIRT", "{\r\n                \"S\": { \"ChestMin\": 85, \"ChestMax\": 95, \"WaistMin\": 70, \"WaistMax\": 75, \"SleeveLengthMin\": 52, \"SleeveLengthMax\": 57 },\r\n                \"M\": { \"ChestMin\": 96, \"ChestMax\": 105, \"WaistMin\": 76, \"WaistMax\": 81, \"SleeveLengthMin\": 57, \"SleeveLengthMax\": 62 },\r\n                \"L\": { \"ChestMin\": 106, \"ChestMax\": 115, \"WaistMin\": 82, \"WaistMax\": 87, \"SleeveLengthMin\": 62, \"SleeveLengthMax\": 67 },\r\n                \"XL\": { \"ChestMin\": 116, \"ChestMax\": 125, \"WaistMin\": 88, \"WaistMax\": 95, \"SleeveLengthMin\": 67, \"SleeveLengthMax\": 72 }\r\n            }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Color", "Description", "ImageUrl", "IsTop", "Material", "Name", "Price", "Size", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { 3, "Blue", "Classic blue denim jeans.", "/lib/images/nproduct/Jeans1.png", false, "Denim", "BLUE DENIM JEANS", 39.99m, "32,34,36,38", "{\r\n                \"32\": { \"WaistMin\": 70, \"WaistMax\": 76, \"HipsMin\": 90, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                \"34\": { \"WaistMin\": 77, \"WaistMax\": 83, \"HipsMin\": 97, \"HipsMax\": 103, \"InseamMin\": 80, \"InseamMax\": 85 },\r\n                \"36\": { \"WaistMin\": 84, \"WaistMax\": 90, \"HipsMin\": 104, \"HipsMax\": 110, \"InseamMin\": 85, \"InseamMax\": 90 },\r\n                \"38\": { \"WaistMin\": 91, \"WaistMax\": 97, \"HipsMin\": 111, \"HipsMax\": 117, \"InseamMin\": 90, \"InseamMax\": 95 }\r\n            }", "Everyday Wear", 60 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { "Skinny-fit jeans with ripped-effect details.", "/lib/images/nproduct/Jeans2.png", "RIPPED SKINNY FIT JEANS", 42.99m, "{\r\n            \"32\": { \"WaistMin\": 70, \"WaistMax\": 76, \"HipsMin\": 90, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n            \"34\": { \"WaistMin\": 77, \"WaistMax\": 83, \"HipsMin\": 97, \"HipsMax\": 103, \"InseamMin\": 80, \"InseamMax\": 85 },\r\n            \"36\": { \"WaistMin\": 84, \"WaistMax\": 90, \"HipsMin\": 104, \"HipsMax\": 110, \"InseamMin\": 85, \"InseamMax\": 90 },\r\n            \"38\": { \"WaistMin\": 91, \"WaistMax\": 97, \"HipsMin\": 111, \"HipsMax\": 117, \"InseamMin\": 90, \"InseamMax\": 95 }\r\n        }", "Trendy", 45 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Color", "Description", "ImageUrl", "Material", "Name", "Price", "SizeChartJson", "Stock" },
                values: new object[] { 4, "Camel", "Wide-fit chino trousers in cotton twill.", "/lib/images/nproduct/Trousers1.png", "Cotton", "WIDE FIT CHINO TROUSERS", 34.99m, "{\r\n            \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n            \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 80, \"InseamMax\": 85 },\r\n            \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 85, \"InseamMax\": 90 },\r\n            \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 90, \"InseamMax\": 95 }\r\n        }", 25 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "Description", "ImageUrl", "Name", "Price", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { "Vanilla", "Straight-leg chinos with zip fly.", "/lib/images/nproduct/Trousers2.png", "STRAIGHT-LEG CHINOS", 49.99m, "{\r\n            \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n            \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 80, \"InseamMax\": 85 },\r\n            \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 85, \"InseamMax\": 90 },\r\n            \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 90, \"InseamMax\": 95 }\r\n        }", "Formal", 20 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Color", "Description", "ImageUrl", "IsTop", "Material", "Name", "Price", "Size", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { 5, "Dark Khaki", "Overshirt with a regular fit and chest patch pocket.", "/lib/images/nproduct/Jacket1.png", true, "Suede", "FAUX SUEDE OVERSHIRT", 99.99m, "S,M,L,XL", "{\r\n            \"S\": { \"ChestMin\": 85, \"ChestMax\": 90, \"WaistMin\": 70, \"WaistMax\": 75, \"SleeveLengthMin\": 55, \"SleeveLengthMax\": 60 },\r\n            \"M\": { \"ChestMin\": 91, \"ChestMax\": 96, \"WaistMin\": 76, \"WaistMax\": 81, \"SleeveLengthMin\": 60, \"SleeveLengthMax\": 65 },\r\n            \"L\": { \"ChestMin\": 97, \"ChestMax\": 102, \"WaistMin\": 82, \"WaistMax\": 87, \"SleeveLengthMin\": 65, \"SleeveLengthMax\": 70 },\r\n            \"XL\": { \"ChestMin\": 103, \"ChestMax\": 110, \"WaistMin\": 88, \"WaistMax\": 95, \"SleeveLengthMin\": 70, \"SleeveLengthMax\": 75 }\r\n        }", "Premium", 15 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "Description", "ImageUrl", "Material", "Name", "Price", "Size", "SizeChartJson" },
                values: new object[] { "Khaki", "Lightweight bomber jacket with ribbed trims and zip fastening.", "/lib/images/nproduct/Jacket2.png", "Cotton", "TECHNICAL BOMBER JACKET", 50.99m, "S,M,L,XL", "{\r\n            \"S\": { \"ChestMin\": 85, \"ChestMax\": 90, \"WaistMin\": 70, \"WaistMax\": 75, \"SleeveLengthMin\": 55, \"SleeveLengthMax\": 60 },\r\n            \"M\": { \"ChestMin\": 91, \"ChestMax\": 96, \"WaistMin\": 76, \"WaistMax\": 81, \"SleeveLengthMin\": 60, \"SleeveLengthMax\": 65 },\r\n            \"L\": { \"ChestMin\": 97, \"ChestMax\": 102, \"WaistMin\": 82, \"WaistMax\": 87, \"SleeveLengthMin\": 65, \"SleeveLengthMax\": 70 },\r\n            \"XL\": { \"ChestMin\": 103, \"ChestMax\": 110, \"WaistMin\": 88, \"WaistMax\": 95, \"SleeveLengthMin\": 70, \"SleeveLengthMax\": 75 }\r\n        }" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeChartJson",
                value: "{\r\n                \"S\": { \"BustMin\": 80, \"BustMax\": 90, \"WaistMin\": 60, \"WaistMax\": 70, \"SleeveMin\": 50, \"SleeveMax\": 55 },\r\n                \"M\": { \"BustMin\": 90, \"BustMax\": 100, \"WaistMin\": 70, \"WaistMax\": 80, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                \"L\": { \"BustMin\": 100, \"BustMax\": 110, \"WaistMin\": 80, \"WaistMax\": 90, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                \"XL\": { \"BustMin\": 110, \"BustMax\": 120, \"WaistMin\": 90, \"WaistMax\": 100, \"SleeveMin\": 65, \"SleeveMax\": 70 }\r\n            }");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "SizeChartJson" },
                values: new object[] { "Relaxed fit T-shirt. Round neck and short sleeves. Tone-on-tone embroidered detail on the front.", "Relaxed T-SHIRT", "{\r\n                \"S\": { \"BustMin\": 80, \"BustMax\": 90, \"WaistMin\": 60, \"WaistMax\": 70, \"SleeveMin\": 50, \"SleeveMax\": 55 },\r\n                \"M\": { \"BustMin\": 90, \"BustMax\": 100, \"WaistMin\": 70, \"WaistMax\": 80, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                \"L\": { \"BustMin\": 100, \"BustMax\": 110, \"WaistMin\": 80, \"WaistMax\": 90, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                \"XL\": { \"BustMin\": 110, \"BustMax\": 120, \"WaistMin\": 90, \"WaistMax\": 100, \"SleeveMin\": 65, \"SleeveMax\": 70 }\r\n            }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "SizeChartJson" },
                values: new object[] { "Formal Shirt", "{\r\n                \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 52, \"SleeveMax\": 57 },\r\n                \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 57, \"SleeveMax\": 62 },\r\n                \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 62, \"SleeveMax\": 67 },\r\n                \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 67, \"SleeveMax\": 72 }\r\n            }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Color", "Description", "ImageUrl", "IsTop", "Material", "Name", "Price", "Size", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { 2, "Green", "A comfortable casual shirt with checkered design.", "/lib/images/nproduct/Shirt1.png", true, "Cotton", "Casual Check Shirt", 25.99m, "S,M,L,XL", "{\r\n                \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 52, \"SleeveMax\": 57 },\r\n                \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 57, \"SleeveMax\": 62 },\r\n                \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 62, \"SleeveMax\": 67 },\r\n                \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 67, \"SleeveMax\": 72 }\r\n            }", "Casual", 35 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { "Classic blue denim jeans.", "/lib/images/nproduct/Jeans1.png", "Blue Denim Jeans", 39.99m, "{\r\n                \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n            }", "Everyday Wear", 60 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Color", "Description", "ImageUrl", "Material", "Name", "Price", "SizeChartJson", "Stock" },
                values: new object[] { 3, "Blue", "Skinny fit jeans. Five-pocket design. Faded and ripped-effect details on the legs. Button-up front fastening.", "/lib/images/nproduct/Jeans2.png", "Denim", "RIPPED SKINNY FIT", 42.99m, "{\r\n                     \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                       \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                      \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                      \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n                   }", 45 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "Description", "ImageUrl", "Name", "Price", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { "Camel", "Wide-leg trousers in cotton twill. Featuring front pockets, rear welt pockets and ripped detailing on the legs. Zip fly and top button fastening.", "/lib/images/nproduct/Trousers1.png", "WIDE FIT CHINO TROUSERS", 34.99m, "{\r\n                        \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                        \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                        \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                        \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n                     }", "Trendy", 25 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Color", "Description", "ImageUrl", "IsTop", "Material", "Name", "Price", "Size", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { 4, "Vanilla", "Straight-leg trousers made of cotton fabric. Front pockets and welt back pocket detail. Zip fly and top button fastening.", "/lib/images/nproduct/Trousers2.png", false, "Cotton", "STRAIGHT-LEG CHINOS", 49.99m, "32,34,36,38", "{\r\n                       \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                       \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                       \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                        \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n                   }", "Formal", 20 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "Description", "ImageUrl", "Material", "Name", "Price", "Size", "SizeChartJson" },
                values: new object[] { "Dark khaki", "Regular fit overshirt. Featuring a collar, long sleeves with buttoned cuffs, a chest patch pocket and a button-up front.", "/lib/images/nproduct/Jacket1.png", "Suede Leather", "FAUX SUEDE OVERSHIRT", 99.99m, "S,M", "{\r\n                          \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                          \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                          \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 65, \"SleeveMax\": 70 },\r\n                          \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 70, \"SleeveMax\": 75 }\r\n                       }" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Color", "Description", "ImageUrl", "IsTop", "Material", "Name", "Price", "Size", "SizeChartJson", "SpecialTag", "Stock" },
                values: new object[] { 10, 5, "Khaki", "Lightweight jacket made of technical fabric. High neck and long sleeves. Hip welt pockets. Inside pocket detail. Ribbed trims. Front zip fastening.", "/lib/images/nproduct/Jacket2.png", true, "Coton", "TECHNICAL BOMBER JACKET", 50.99m, "S,M", "{\r\n                          \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                          \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                          \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 65, \"SleeveMax\": 70 },\r\n                          \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 70, \"SleeveMax\": 75 }\r\n                       }", "Premium", 15 });
        }
    }
}
