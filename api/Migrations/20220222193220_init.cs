using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sv = table.Column<string>(type: "text", nullable: false),
                    en = table.Column<string>(type: "text", nullable: false),
                    inListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Word_WordList_inListId",
                        column: x => x.inListId,
                        principalTable: "WordList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WordList",
                columns: new[] { "Id", "Name", "createdAt" },
                values: new object[] { -1, "first", new DateTime(2022, 2, 22, 19, 32, 20, 298, DateTimeKind.Utc).AddTicks(7981) });

            migrationBuilder.InsertData(
                table: "Word",
                columns: new[] { "Id", "en", "inListId", "sv" },
                values: new object[,]
                {
                    { -3, "demeanour", -1, "uppträdande" },
                    { -2, "poop", -1, "bajs" },
                    { -1, "apple", -1, "äpple" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Word_inListId",
                table: "Word",
                column: "inListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Word");

            migrationBuilder.DropTable(
                name: "WordList");
        }
    }
}
