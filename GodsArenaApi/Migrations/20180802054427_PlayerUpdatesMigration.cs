using Microsoft.EntityFrameworkCore.Migrations;

namespace GodsArenaApi.Migrations
{
    public partial class PlayerUpdatesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Decks",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 35);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Decks",
                newName: "isActive");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Players",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
