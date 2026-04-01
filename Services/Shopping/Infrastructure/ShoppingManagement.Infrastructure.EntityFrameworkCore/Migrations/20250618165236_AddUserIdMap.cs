using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserIdMaps",
                columns: table => new
                {
                    GuidUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    StringUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdMaps", x => new { x.GuidUserId, x.StringUserId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserIdMaps");
        }
    }
}
