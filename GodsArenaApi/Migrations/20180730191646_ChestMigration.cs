using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GodsArenaApi.Migrations
{
    public partial class ChestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChestId",
                table: "Purchases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Chests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<int>(nullable: false),
                    MythologyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ChestId",
                table: "Purchases",
                column: "ChestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Chests_ChestId",
                table: "Purchases",
                column: "ChestId",
                principalTable: "Chests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Chests_ChestId",
                table: "Purchases");

            migrationBuilder.DropTable(
                name: "Chests");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_ChestId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ChestId",
                table: "Purchases");
        }
    }
}
