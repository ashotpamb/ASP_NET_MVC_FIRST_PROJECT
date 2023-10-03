using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CherryShop.Migrations
{
    /// <inheritdoc />
    public partial class SliderModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SliderId",
                table: "FileRefernces",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FileRefernces_SliderId",
                table: "FileRefernces",
                column: "SliderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileRefernces_Slides_SliderId",
                table: "FileRefernces",
                column: "SliderId",
                principalTable: "Slides",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileRefernces_Slides_SliderId",
                table: "FileRefernces");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_FileRefernces_SliderId",
                table: "FileRefernces");

            migrationBuilder.DropColumn(
                name: "SliderId",
                table: "FileRefernces");
        }
    }
}
