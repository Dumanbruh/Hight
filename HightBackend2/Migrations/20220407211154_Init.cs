using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HightBackend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estabilishments",
                columns: table => new
                {
                    estabilishmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    website = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "text", nullable: true),
                    reviewNum = table.Column<float>(type: "real", nullable: false),
                    overallRating = table.Column<float>(type: "real", nullable: false),
                    locationRating = table.Column<float>(type: "real", nullable: false),
                    serviceRating = table.Column<float>(type: "real", nullable: false),
                    price_qualityRating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabilishments", x => x.estabilishmentId);
                });

            migrationBuilder.CreateTable(
                name: "EstabilishmentImages",
                columns: table => new
                {
                    imageID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    estabilishmentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabilishmentImages", x => x.imageID);
                    table.ForeignKey(
                        name: "FK_EstabilishmentImages_Estabilishments_estabilishmentId",
                        column: x => x.estabilishmentId,
                        principalTable: "Estabilishments",
                        principalColumn: "estabilishmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    eventID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    location = table.Column<string>(type: "text", nullable: true),
                    eventImage = table.Column<string>(type: "text", nullable: true),
                    estabilishmentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.eventID);
                    table.ForeignKey(
                        name: "FK_Events_Estabilishments_estabilishmentId",
                        column: x => x.estabilishmentId,
                        principalTable: "Estabilishments",
                        principalColumn: "estabilishmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstabilishmentImages_estabilishmentId",
                table: "EstabilishmentImages",
                column: "estabilishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_estabilishmentId",
                table: "Events",
                column: "estabilishmentId");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstabilishmentImages");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Estabilishments");
        }
    }
}
