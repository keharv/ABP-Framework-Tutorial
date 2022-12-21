using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.BookStore.Migrations
{
    public partial class Add_Book_Library_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LibraryId",
                table: "AppBooks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppBooks_LibraryId",
                table: "AppBooks",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBooks_AppLibraries_LibraryId",
                table: "AppBooks",
                column: "LibraryId",
                principalTable: "AppLibraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBooks_AppLibraries_LibraryId",
                table: "AppBooks");

            migrationBuilder.DropIndex(
                name: "IX_AppBooks_LibraryId",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "AppBooks");
        }
    }
}
