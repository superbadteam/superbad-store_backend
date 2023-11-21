using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddMinPriceAndMaxPriceColumnToProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxPrice",
                table: "Products",
                type: "double precision",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "MinPrice",
                table: "Products",
                type: "double precision",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "Products");
        }
    }
}
