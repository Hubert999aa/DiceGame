using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiceGameAPI.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    IdGame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.IdGame);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.IdPlayer);
                });

            migrationBuilder.CreateTable(
                name: "PointsTables",
                columns: table => new
                {
                    IdPointsTable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aces = table.Column<int>(type: "int", nullable: false),
                    Twos = table.Column<int>(type: "int", nullable: false),
                    Threes = table.Column<int>(type: "int", nullable: false),
                    Fours = table.Column<int>(type: "int", nullable: false),
                    Fives = table.Column<int>(type: "int", nullable: false),
                    Sixes = table.Column<int>(type: "int", nullable: false),
                    Pair = table.Column<int>(type: "int", nullable: false),
                    TwoPairs = table.Column<int>(type: "int", nullable: false),
                    ThreeOfKind = table.Column<int>(type: "int", nullable: false),
                    FourOfKind = table.Column<int>(type: "int", nullable: false),
                    FullHouse = table.Column<int>(type: "int", nullable: false),
                    SmallStraight = table.Column<int>(type: "int", nullable: false),
                    LargeStraight = table.Column<int>(type: "int", nullable: false),
                    General = table.Column<int>(type: "int", nullable: false),
                    Chance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsTables", x => x.IdPointsTable);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameHistories",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdPointsTable = table.Column<int>(type: "int", nullable: false),
                    Won = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameHistories", x => new { x.IdPlayer, x.IdGame });
                    table.ForeignKey(
                        name: "FK_PlayerGameHistories_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameHistories_Players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Players",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameHistories_PointsTables_IdPointsTable",
                        column: x => x.IdPointsTable,
                        principalTable: "PointsTables",
                        principalColumn: "IdPointsTable",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameHistories_IdGame",
                table: "PlayerGameHistories",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameHistories_IdPointsTable",
                table: "PlayerGameHistories",
                column: "IdPointsTable",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGameHistories");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PointsTables");
        }
    }
}
