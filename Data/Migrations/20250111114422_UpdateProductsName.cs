using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresizelyWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "T-SHIRT WITH EMBROIDERY");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "T-SHIRT WITH CONTRAST EMBROIDERY");
        }
    }
}
