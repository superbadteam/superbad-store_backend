using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class ApplyUniqueFilters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId_ProductTypeId",
                table: "Cart");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId_ProductTypeId",
                table: "Cart",
                columns: new[] { "UserId", "ProductTypeId" },
                unique: true,
                filter: "\"DeletedAt\" IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId_ProductTypeId",
                table: "Cart");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId_ProductTypeId",
                table: "Cart",
                columns: new[] { "UserId", "ProductTypeId" },
                unique: true);
        }
    }
}
