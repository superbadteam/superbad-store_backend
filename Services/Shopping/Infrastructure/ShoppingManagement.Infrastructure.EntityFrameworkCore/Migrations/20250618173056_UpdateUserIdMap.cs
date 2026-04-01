using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserIdMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIdMaps",
                table: "UserIdMaps");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserIdMaps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserIdMaps",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserIdMaps",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "UserIdMaps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "UserIdMaps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserIdMaps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UserIdMaps",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIdMaps",
                table: "UserIdMaps",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserIdMaps_GuidUserId_StringUserId",
                table: "UserIdMaps",
                columns: new[] { "GuidUserId", "StringUserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIdMaps",
                table: "UserIdMaps");

            migrationBuilder.DropIndex(
                name: "IX_UserIdMaps_GuidUserId_StringUserId",
                table: "UserIdMaps");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserIdMaps");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserIdMaps");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserIdMaps");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "UserIdMaps");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserIdMaps");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserIdMaps");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserIdMaps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIdMaps",
                table: "UserIdMaps",
                columns: new[] { "GuidUserId", "StringUserId" });
        }
    }
}
