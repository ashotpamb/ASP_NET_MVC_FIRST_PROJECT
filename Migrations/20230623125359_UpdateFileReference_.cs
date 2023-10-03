using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CherryShop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFileReference_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileReference_Files_FileIs",
                table: "FileReference");

            migrationBuilder.DropForeignKey(
                name: "FK_FileReference_Products_ProductId",
                table: "FileReference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileReference",
                table: "FileReference");

            migrationBuilder.RenameTable(
                name: "FileReference",
                newName: "FileRefernces");

            migrationBuilder.RenameIndex(
                name: "IX_FileReference_ProductId",
                table: "FileRefernces",
                newName: "IX_FileRefernces_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FileReference_FileIs",
                table: "FileRefernces",
                newName: "IX_FileRefernces_FileIs");

            migrationBuilder.AlterColumn<int>(
                name: "FileIs",
                table: "FileRefernces",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileRefernces",
                table: "FileRefernces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileRefernces_Files_FileIs",
                table: "FileRefernces",
                column: "FileIs",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileRefernces_Products_ProductId",
                table: "FileRefernces",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileRefernces_Files_FileIs",
                table: "FileRefernces");

            migrationBuilder.DropForeignKey(
                name: "FK_FileRefernces_Products_ProductId",
                table: "FileRefernces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileRefernces",
                table: "FileRefernces");

            migrationBuilder.RenameTable(
                name: "FileRefernces",
                newName: "FileReference");

            migrationBuilder.RenameIndex(
                name: "IX_FileRefernces_ProductId",
                table: "FileReference",
                newName: "IX_FileReference_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FileRefernces_FileIs",
                table: "FileReference",
                newName: "IX_FileReference_FileIs");

            migrationBuilder.AlterColumn<int>(
                name: "FileIs",
                table: "FileReference",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileReference",
                table: "FileReference",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileReference_Files_FileIs",
                table: "FileReference",
                column: "FileIs",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileReference_Products_ProductId",
                table: "FileReference",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
