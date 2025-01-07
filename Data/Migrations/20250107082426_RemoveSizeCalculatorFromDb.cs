using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresizelyWeb.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSizeCalculatorFromDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SizeCalculator");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SizeCalculator",
                columns: table => new
                {
                    Bust = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Hips = table.Column<int>(type: "int", nullable: true),
                    Inseam = table.Column<int>(type: "int", nullable: true),
                    RecommendedSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SleeveLength = table.Column<int>(type: "int", nullable: true),
                    Waist = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
