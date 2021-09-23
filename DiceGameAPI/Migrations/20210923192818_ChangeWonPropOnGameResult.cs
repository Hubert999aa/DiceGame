using Microsoft.EntityFrameworkCore.Migrations;

namespace DiceGameAPI.Migrations
{
    public partial class ChangeWonPropOnGameResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Won",
                table: "PlayerGameHistories");

            migrationBuilder.AddColumn<int>(
                name: "GameResult",
                table: "PlayerGameHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameResult",
                table: "PlayerGameHistories");

            migrationBuilder.AddColumn<bool>(
                name: "Won",
                table: "PlayerGameHistories",
                type: "bit",
                nullable: true);
        }
    }
}
