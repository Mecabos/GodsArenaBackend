using Microsoft.EntityFrameworkCore.Migrations;

namespace GodsArenaApi.Migrations
{
    public partial class DropMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Chests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drops",
                columns: table => new
                {
                    LootId = table.Column<int>(nullable: false),
                    LootTableId = table.Column<int>(nullable: false),
                    Probability = table.Column<float>(nullable: false),
                    Always = table.Column<bool>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Unique = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drops", x => new { x.LootId, x.LootTableId });
                    table.ForeignKey(
                        name: "FK_Drops_Loot_LootId",
                        column: x => x.LootId,
                        principalTable: "Loot",
                        principalColumn: "LootId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drops_LootTables_LootTableId",
                        column: x => x.LootTableId,
                        principalTable: "LootTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drops_LootTableId",
                table: "Drops",
                column: "LootTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drops");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Chests");
        }
    }
}
