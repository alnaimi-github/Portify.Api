using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsRepositoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LiveDemoUrl",
                table: "Repositories",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Repositories",
                newName: "Technologies");

            migrationBuilder.RenameColumn(
                name: "GitHubUrl",
                table: "Repositories",
                newName: "Homepage");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Repositories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "Forks",
                table: "Repositories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GitHubId",
                table: "Repositories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Repositories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSync",
                table: "Repositories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Private",
                table: "Repositories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReadmeContent",
                table: "Repositories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Repositories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Repositories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "Forks",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "GitHubId",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "LastSync",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "Private",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "ReadmeContent",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Repositories");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Repositories",
                newName: "LiveDemoUrl");

            migrationBuilder.RenameColumn(
                name: "Technologies",
                table: "Repositories",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Homepage",
                table: "Repositories",
                newName: "GitHubUrl");
        }
    }
}
