using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HightBackend.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Estabilishments_estabilishmentId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "estabilishmentId",
                table: "Events",
                newName: "estabilishmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Events_estabilishmentId",
                table: "Events",
                newName: "IX_Events_estabilishmentID");

            migrationBuilder.AlterColumn<int>(
                name: "estabilishmentID",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Estabilishments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Estabilishments",
                columns: new[] { "estabilishmentId", "description", "location", "locationRating", "name", "overallRating", "price_qualityRating", "reviewNum", "serviceRating", "website" },
                values: new object[] { 1, "Отель Wyndham Garden Astana расположен в городе Астана, в 5 минутах ходьбы от торгового центра MEGA Silk Way и места проведения международной выставки «Астана ЭКСПО-2017». К услугам гостей бесплатный Wi-Fi, фитнес-центр, спа-центр и конференц-залы. На территории открыты ресторан и бар. Номера оформлены в современном стиле. В распоряжении гостей кровать размера «king-size», письменный стол, телевизор с плоским экраном, сейф, гладильные принадлежности, высокотехнологичная система климат-контроля и бесплатные принадлежности для чая/кофе. Ванная комната отделана мрамором. В числе удобств круглосуточная стойка регистрации, банкомат, камера хранения багажа и бизнес-центр. Предоставляются услуги химчистки. В отеле можно поиграть в бильярд и бесплатно взять напрокат велосипед. Поездка от отеля Wyndham Garden Astana до монумента Байтерек займет 15 минут, а до международного аэропорта Нурсултан Назарбаев — 7 минут.", "https://goo.gl/maps/BzA7ke8LvRHbEK5t7", 0f, "Wyndham Garden Astana", 0f, 0f, 0f, 0f, "http://wyndhamgardenastana.com/ru/" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "eventID", "estabilishmentID", "eventImage", "location", "price", "time", "title" },
                values: new object[,]
                {
                    { 1, 1, null, null, 0f, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), "Example" },
                    { 2, 1, null, null, 0f, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), "Example2" },
                    { 3, 1, null, null, 0f, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), "Example3" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Estabilishments_estabilishmentID",
                table: "Events",
                column: "estabilishmentID",
                principalTable: "Estabilishments",
                principalColumn: "estabilishmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Estabilishments_estabilishmentID",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "eventID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estabilishments",
                keyColumn: "estabilishmentId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "estabilishmentID",
                table: "Events",
                newName: "estabilishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_estabilishmentID",
                table: "Events",
                newName: "IX_Events_estabilishmentId");

            migrationBuilder.AlterColumn<int>(
                name: "estabilishmentId",
                table: "Events",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Estabilishments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Estabilishments_estabilishmentId",
                table: "Events",
                column: "estabilishmentId",
                principalTable: "Estabilishments",
                principalColumn: "estabilishmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
