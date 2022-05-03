using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HightBackend.Migrations
{
    public partial class init62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating",
                table: "comments");

            migrationBuilder.AddColumn<float>(
                name: "locationRating",
                table: "comments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "overallRating",
                table: "comments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "price_qualityRating",
                table: "comments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "serviceRating",
                table: "comments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "locationRating",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "overallRating",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "price_qualityRating",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "serviceRating",
                table: "comments");

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
