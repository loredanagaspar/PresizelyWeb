using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresizelyWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddSizeToShoppingCartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "ShoppingCart");
        }
    }
}
