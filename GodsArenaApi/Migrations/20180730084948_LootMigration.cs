using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GodsArenaApi.Migrations
{
    public partial class LootMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deck_Players_PlayerId",
                table: "Deck");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSlot_Deck_DeckId",
                table: "LevelSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LevelSlot",
                table: "LevelSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deck",
                table: "Deck");

            migrationBuilder.RenameTable(
                name: "LevelSlot",
                newName: "LevelsSlots");

            migrationBuilder.RenameTable(
                name: "Deck",
                newName: "Decks");

            migrationBuilder.RenameIndex(
                name: "IX_LevelSlot_DeckId",
                table: "LevelsSlots",
                newName: "IX_LevelsSlots_DeckId");

            migrationBuilder.RenameIndex(
                name: "IX_Deck_PlayerId",
                table: "Decks",
                newName: "IX_Decks_PlayerId");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "LevelsSlots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LevelsSlots",
                table: "LevelsSlots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Decks",
                table: "Decks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Loot",
                columns: table => new
                {
                    LootId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: true),
                    Health = table.Column<int>(nullable: true),
                    Speed = table.Column<float>(nullable: true),
                    MythologyType = table.Column<int>(nullable: true),
                    MinValue = table.Column<int>(nullable: true),
                    MaxValue = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loot", x => x.LootId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LevelsSlots_CardId",
                table: "LevelsSlots",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Players_PlayerId",
                table: "Decks",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelsSlots_Loot_CardId",
                table: "LevelsSlots",
                column: "CardId",
                principalTable: "Loot",
                principalColumn: "LootId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelsSlots_Decks_DeckId",
                table: "LevelsSlots",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Players_PlayerId",
                table: "Decks");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelsSlots_Loot_CardId",
                table: "LevelsSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelsSlots_Decks_DeckId",
                table: "LevelsSlots");

            migrationBuilder.DropTable(
                name: "Loot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LevelsSlots",
                table: "LevelsSlots");

            migrationBuilder.DropIndex(
                name: "IX_LevelsSlots_CardId",
                table: "LevelsSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Decks",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "LevelsSlots");

            migrationBuilder.RenameTable(
                name: "LevelsSlots",
                newName: "LevelSlot");

            migrationBuilder.RenameTable(
                name: "Decks",
                newName: "Deck");

            migrationBuilder.RenameIndex(
                name: "IX_LevelsSlots_DeckId",
                table: "LevelSlot",
                newName: "IX_LevelSlot_DeckId");

            migrationBuilder.RenameIndex(
                name: "IX_Decks_PlayerId",
                table: "Deck",
                newName: "IX_Deck_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LevelSlot",
                table: "LevelSlot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deck",
                table: "Deck",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deck_Players_PlayerId",
                table: "Deck",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSlot_Deck_DeckId",
                table: "LevelSlot",
                column: "DeckId",
                principalTable: "Deck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
