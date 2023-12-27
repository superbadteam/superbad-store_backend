using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToShippingAddressesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_UserId",
                table: "ShippingAddresses");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_UserId_IsMainAddress",
                table: "ShippingAddresses",
                columns: new[] { "UserId", "IsMainAddress" },
                unique: true,
                filter: "\"DeletedAt\" IS NULL AND \"IsMainAddress\" = true");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_UserId_IsMainAddress",
                table: "ShippingAddresses");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_UserId",
                table: "ShippingAddresses",
                column: "UserId");
        }
    }
}
