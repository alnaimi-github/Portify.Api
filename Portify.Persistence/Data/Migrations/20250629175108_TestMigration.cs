using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portify.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLink_Users_UserId",
                table: "UserLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLink",
                table: "UserLink");

            migrationBuilder.RenameTable(
                name: "UserLink",
                newName: "UserLinks");

            migrationBuilder.RenameIndex(
                name: "IX_UserLink_UserId_Platform",
                table: "UserLinks",
                newName: "IX_UserLinks_UserId_Platform");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLinks",
                table: "UserLinks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLinks_Users_UserId",
                table: "UserLinks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLinks_Users_UserId",
                table: "UserLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLinks",
                table: "UserLinks");

            migrationBuilder.RenameTable(
                name: "UserLinks",
                newName: "UserLink");

            migrationBuilder.RenameIndex(
                name: "IX_UserLinks_UserId_Platform",
                table: "UserLink",
                newName: "IX_UserLink_UserId_Platform");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLink",
                table: "UserLink",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLink_Users_UserId",
                table: "UserLink",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
