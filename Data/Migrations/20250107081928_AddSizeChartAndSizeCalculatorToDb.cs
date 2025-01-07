using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresizelyWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddSizeChartAndSizeCalculatorToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTop",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SizeChartJson",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SizeCalculator",
                columns: table => new
                {
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Bust = table.Column<int>(type: "int", nullable: true),
                    Waist = table.Column<int>(type: "int", nullable: true),
                    SleeveLength = table.Column<int>(type: "int", nullable: true),
                    Hips = table.Column<int>(type: "int", nullable: true),
                    Inseam = table.Column<int>(type: "int", nullable: true),
                    RecommendedSize = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsTop", "SizeChartJson" },
                values: new object[] { true, "{\r\n                \"S\": { \"BustMin\": 80, \"BustMax\": 90, \"WaistMin\": 60, \"WaistMax\": 70, \"SleeveMin\": 50, \"SleeveMax\": 55 },\r\n                \"M\": { \"BustMin\": 90, \"BustMax\": 100, \"WaistMin\": 70, \"WaistMax\": 80, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                \"L\": { \"BustMin\": 100, \"BustMax\": 110, \"WaistMin\": 80, \"WaistMax\": 90, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                \"XL\": { \"BustMin\": 110, \"BustMax\": 120, \"WaistMin\": 90, \"WaistMax\": 100, \"SleeveMin\": 65, \"SleeveMax\": 70 }\r\n            }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsTop", "SizeChartJson" },
                values: new object[] { true, "{\r\n                \"S\": { \"BustMin\": 80, \"BustMax\": 90, \"WaistMin\": 60, \"WaistMax\": 70, \"SleeveMin\": 50, \"SleeveMax\": 55 },\r\n                \"M\": { \"BustMin\": 90, \"BustMax\": 100, \"WaistMin\": 70, \"WaistMax\": 80, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                \"L\": { \"BustMin\": 100, \"BustMax\": 110, \"WaistMin\": 80, \"WaistMax\": 90, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                \"XL\": { \"BustMin\": 110, \"BustMax\": 120, \"WaistMin\": 90, \"WaistMax\": 100, \"SleeveMin\": 65, \"SleeveMax\": 70 }\r\n            }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsTop", "SizeChartJson" },
                values: new object[] { true, "{\r\n                \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 52, \"SleeveMax\": 57 },\r\n                \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 57, \"SleeveMax\": 62 },\r\n                \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 62, \"SleeveMax\": 67 },\r\n                \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 67, \"SleeveMax\": 72 }\r\n            }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsTop", "SizeChartJson" },
                values: new object[] { true, "{\r\n                \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 52, \"SleeveMax\": 57 },\r\n                \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 57, \"SleeveMax\": 62 },\r\n                \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 62, \"SleeveMax\": 67 },\r\n                \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 67, \"SleeveMax\": 72 }\r\n            }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsTop", "SizeChartJson" },
                values: new object[] { false, "{\r\n                \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n            }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IsTop", "SizeChartJson" },
                values: new object[] { false, "{\r\n                     \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                       \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                      \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                      \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n                   }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "IsTop", "SizeChartJson" },
                values: new object[] { false, "{\r\n                        \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                        \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                        \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                        \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n                     }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "IsTop", "SizeChartJson" },
                values: new object[] { false, "{\r\n                       \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                       \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                       \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                        \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n                   }" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "IsTop", "SizeChartJson" },
                values: new object[] { true, "{\r\n                          \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                          \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                          \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 65, \"SleeveMax\": 70 },\r\n                          \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 70, \"SleeveMax\": 75 }\r\n                       }" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SizeCalculator");

            migrationBuilder.DropColumn(
                name: "IsTop",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SizeChartJson",
                table: "Product");
        }
    }
}
