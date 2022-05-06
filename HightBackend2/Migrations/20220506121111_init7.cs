using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HightBackend.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 1,
                column: "time",
                value: new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 2,
                column: "time",
                value: new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 3,
                column: "time",
                value: new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 1,
                column: "time",
                value: new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 2,
                column: "time",
                value: new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 3,
                column: "time",
                value: new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
