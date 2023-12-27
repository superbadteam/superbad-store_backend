using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneColumnsToShippingAddressesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ShippingAddresses");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber_CountryCode",
                table: "ShippingAddresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PhoneNumber_NationalNumber",
                table: "ShippingAddresses",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber_CountryCode",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "PhoneNumber_NationalNumber",
                table: "ShippingAddresses");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ShippingAddresses",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
