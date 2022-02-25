using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_WordList_inListId",
                table: "Word");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "WordList",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "sv",
                table: "Word",
                newName: "Sv");

            migrationBuilder.RenameColumn(
                name: "inListId",
                table: "Word",
                newName: "InListId");

            migrationBuilder.RenameColumn(
                name: "en",
                table: "Word",
                newName: "En");

            migrationBuilder.RenameIndex(
                name: "IX_Word_inListId",
                table: "Word",
                newName: "IX_Word_InListId");

            migrationBuilder.UpdateData(
                table: "WordList",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 24, 16, 12, 38, 652, DateTimeKind.Utc).AddTicks(4102));

            migrationBuilder.AddForeignKey(
                name: "FK_Word_WordList_InListId",
                table: "Word",
                column: "InListId",
                principalTable: "WordList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_WordList_InListId",
                table: "Word");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "WordList",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Sv",
                table: "Word",
                newName: "sv");

            migrationBuilder.RenameColumn(
                name: "InListId",
                table: "Word",
                newName: "inListId");

            migrationBuilder.RenameColumn(
                name: "En",
                table: "Word",
                newName: "en");

            migrationBuilder.RenameIndex(
                name: "IX_Word_InListId",
                table: "Word",
                newName: "IX_Word_inListId");

            migrationBuilder.UpdateData(
                table: "WordList",
                keyColumn: "Id",
                keyValue: -1,
                column: "createdAt",
                value: new DateTime(2022, 2, 22, 22, 7, 37, 726, DateTimeKind.Utc).AddTicks(3142));

            migrationBuilder.AddForeignKey(
                name: "FK_Word_WordList_inListId",
                table: "Word",
                column: "inListId",
                principalTable: "WordList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
