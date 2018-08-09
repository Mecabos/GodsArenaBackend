using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GodsArenaApi.Migrations
{
    public partial class LootTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LootTableId",
                table: "Chests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LootTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LootCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootTables", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chests_LootTableId",
                table: "Chests",
                column: "LootTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chests_LootTables_LootTableId",
                table: "Chests",
                column: "LootTableId",
                principalTable: "LootTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chests_LootTables_LootTableId",
                table: "Chests");

            migrationBuilder.DropTable(
                name: "LootTables");

            migrationBuilder.DropIndex(
                name: "IX_Chests_LootTableId",
                table: "Chests");

            migrationBuilder.DropColumn(
                name: "LootTableId",
                table: "Chests");
        }
    }
}
