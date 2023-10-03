using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CherryShop.Migrations
{
    /// <inheritdoc />
    public partial class FileUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Files",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "storagePath",
                table: "Files",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "storagePath",
                table: "Files");
        }
    }
}
