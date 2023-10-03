using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CherryShop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFileReference__ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileRefernces_Files_FileIs",
                table: "FileRefernces");

            migrationBuilder.DropIndex(
                name: "IX_FileRefernces_FileIs",
                table: "FileRefernces");

            migrationBuilder.DropColumn(
                name: "FileIs",
                table: "FileRefernces");

            migrationBuilder.CreateIndex(
                name: "IX_FileRefernces_FileId",
                table: "FileRefernces",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileRefernces_Files_FileId",
                table: "FileRefernces",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileRefernces_Files_FileId",
                table: "FileRefernces");

            migrationBuilder.DropIndex(
                name: "IX_FileRefernces_FileId",
                table: "FileRefernces");

            migrationBuilder.AddColumn<int>(
                name: "FileIs",
                table: "FileRefernces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FileRefernces_FileIs",
                table: "FileRefernces",
                column: "FileIs");

            migrationBuilder.AddForeignKey(
                name: "FK_FileRefernces_Files_FileIs",
                table: "FileRefernces",
                column: "FileIs",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
