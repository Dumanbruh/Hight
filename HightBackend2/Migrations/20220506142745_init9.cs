using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HightBackend.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usersFavourites",
                columns: table => new
                {
                    favID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userID = table.Column<int>(type: "integer", nullable: false),
                    estabilishmentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersFavourites", x => x.favID);
                    table.ForeignKey(
                        name: "FK_usersFavourites_Estabilishments_estabilishmentID",
                        column: x => x.estabilishmentID,
                        principalTable: "Estabilishments",
                        principalColumn: "estabilishmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usersFavourites_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usersFavourites_estabilishmentID",
                table: "usersFavourites",
                column: "estabilishmentID");

            migrationBuilder.CreateIndex(
                name: "IX_usersFavourites_userID",
                table: "usersFavourites",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usersFavourites");
        }
    }
}
