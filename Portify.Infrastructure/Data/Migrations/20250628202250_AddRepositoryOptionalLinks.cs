using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRepositoryOptionalLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHubUrl",
                table: "Repositories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Repositories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LiveDemoUrl",
                table: "Repositories",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHubUrl",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "LiveDemoUrl",
                table: "Repositories");
        }
    }
}
