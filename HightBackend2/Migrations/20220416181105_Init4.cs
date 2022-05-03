using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HightBackend.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "User",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "User",
                type: "bytea",
                nullable: true);

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
        }
    }
}
