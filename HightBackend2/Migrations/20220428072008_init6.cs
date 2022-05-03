using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HightBackend.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "typeID",
                table: "Estabilishments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    commentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment = table.Column<string>(type: "text", nullable: true),
                    publishedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    estabilishmentID = table.Column<int>(type: "integer", nullable: false),
                    userID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_comments_Estabilishments_estabilishmentID",
                        column: x => x.estabilishmentID,
                        principalTable: "Estabilishments",
                        principalColumn: "estabilishmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estabilishmentTypes",
                columns: table => new
                {
                    typeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    typeName = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estabilishmentTypes", x => x.typeID);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 1,
                column: "time",
                value: new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 2,
                column: "time",
                value: new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 3,
                column: "time",
                value: new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_Estabilishments_typeID",
                table: "Estabilishments",
                column: "typeID");

            migrationBuilder.CreateIndex(
                name: "IX_comments_estabilishmentID",
                table: "comments",
                column: "estabilishmentID");

            migrationBuilder.CreateIndex(
                name: "IX_comments_userID",
                table: "comments",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabilishments_estabilishmentTypes_typeID",
                table: "Estabilishments",
                column: "typeID",
                principalTable: "estabilishmentTypes",
                principalColumn: "typeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabilishments_estabilishmentTypes_typeID",
                table: "Estabilishments");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "estabilishmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Estabilishments_typeID",
                table: "Estabilishments");

            migrationBuilder.DropColumn(
                name: "typeID",
                table: "Estabilishments");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 1,
                column: "time",
                value: new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 2,
                column: "time",
                value: new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 3,
                column: "time",
                value: new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
