using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductIdToProductTypeIdInCartsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Cart",
                newName: "ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId_ProductId",
                table: "Cart",
                newName: "IX_Cart_UserId_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                newName: "IX_Cart_ProductTypeId");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Users",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_ProductTypes_ProductTypeId",
                table: "Cart",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_ProductTypes_ProductTypeId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Cart",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId_ProductTypeId",
                table: "Cart",
                newName: "IX_Cart_UserId_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_ProductTypeId",
                table: "Cart",
                newName: "IX_Cart_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
