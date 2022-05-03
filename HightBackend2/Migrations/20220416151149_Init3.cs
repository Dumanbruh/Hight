using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HightBackend.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstabilishmentImages_Estabilishments_estabilishmentId",
                table: "EstabilishmentImages");

            migrationBuilder.RenameColumn(
                name: "estabilishmentId",
                table: "EstabilishmentImages",
                newName: "estabilishmentID");

            migrationBuilder.RenameIndex(
                name: "IX_EstabilishmentImages_estabilishmentId",
                table: "EstabilishmentImages",
                newName: "IX_EstabilishmentImages_estabilishmentID");

            migrationBuilder.AlterColumn<int>(
                name: "estabilishmentID",
                table: "EstabilishmentImages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userID);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 1,
                column: "time",
                value: new DateTime(2022, 4, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 2,
                column: "time",
                value: new DateTime(2022, 4, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 3,
                column: "time",
                value: new DateTime(2022, 4, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_EstabilishmentImages_Estabilishments_estabilishmentID",
                table: "EstabilishmentImages",
                column: "estabilishmentID",
                principalTable: "Estabilishments",
                principalColumn: "estabilishmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstabilishmentImages_Estabilishments_estabilishmentID",
                table: "EstabilishmentImages");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "estabilishmentID",
                table: "EstabilishmentImages",
                newName: "estabilishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EstabilishmentImages_estabilishmentID",
                table: "EstabilishmentImages",
                newName: "IX_EstabilishmentImages_estabilishmentId");

            migrationBuilder.AlterColumn<int>(
                name: "estabilishmentId",
                table: "EstabilishmentImages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 1,
                column: "time",
                value: new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 2,
                column: "time",
                value: new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 3,
                column: "time",
                value: new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_EstabilishmentImages_Estabilishments_estabilishmentId",
                table: "EstabilishmentImages",
                column: "estabilishmentId",
                principalTable: "Estabilishments",
                principalColumn: "estabilishmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
