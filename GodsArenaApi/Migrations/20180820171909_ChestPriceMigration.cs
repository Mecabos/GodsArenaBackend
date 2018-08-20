using Microsoft.EntityFrameworkCore.Migrations;

namespace GodsArenaApi.Migrations
{
    public partial class ChestPriceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Chests",
                newName: "PriceInGold");

            migrationBuilder.AddColumn<int>(
                name: "PriceInCoins",
                table: "Chests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceInCoins",
                table: "Chests");

            migrationBuilder.RenameColumn(
                name: "PriceInGold",
                table: "Chests",
                newName: "Price");
        }
    }
}
