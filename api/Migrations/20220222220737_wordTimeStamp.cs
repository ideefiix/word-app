using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class wordTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WordList",
                keyColumn: "Id",
                keyValue: -1,
                column: "createdAt",
                value: new DateTime(2022, 2, 22, 22, 7, 37, 726, DateTimeKind.Utc).AddTicks(3142));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WordList",
                keyColumn: "Id",
                keyValue: -1,
                column: "createdAt",
                value: new DateTime(2022, 2, 22, 19, 32, 20, 298, DateTimeKind.Utc).AddTicks(7981));
        }
    }
}
