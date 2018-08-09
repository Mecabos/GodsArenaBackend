using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public static class GodsArenaApiContextExtensions
    {
        public static void EnsureSeedDataForContext(this GodsArenaApiContext context)
        {
            if (context.Players.Any() && context.Wallets.Any() && context.PlayersStats.Any() &&
                context.Packs.Any() && context.Decks.Any() && context.GoldLoots.Any() &&
                context.Cards.Any() && context.PacksContents.Any() && context.LevelsSlots.Any() &&
                context.LootTables.Any() && context.Drops.Any() && context.Chests.Any())
            {
                return;
            }

            //1.Player
            var Players = new List<Player>()
            {
                new Player(){ Username = "Mecab" }
            };
            context.Players.AddRange(Players);

            //2.Wallet
            var Wallets = new List<Wallet>()
            {
                new Wallet(){ CoinsEarned = 5000, GoldEarned = 0 ,Player = Players[0]}
            };
            context.Wallets.AddRange(Wallets);

            //3.PlayerStats
            var PlayersStats = new List<PlayerStats>()
            {
                new PlayerStats(){ KillCount = 5, RecievedDmg = 550, AppliedDmg = 1050, Player = Players[0]}
            };
            context.PlayersStats.AddRange(PlayersStats);

            //4.Pack
            var Packs = new List<Pack>()
            {
                new Pack(){ Player = Players[0]}
            };
            context.Packs.AddRange(Packs);

            //5.Deck
            var Decks = new List<Deck>()
            {
                new Deck(){Name = "First deck", IsActive = true,  Player = Players[0]},
                new Deck(){Name = "Second deck", IsActive = false,  Player = Players[0]},
                new Deck(){Name = "Third deck", IsActive = false,  Player = Players[0]}
            };
            context.Decks.AddRange(Decks);

            //6.GoldLoot
            var GoldLoots = new List<GoldLoot>()
            {
                new GoldLoot(){MinValue=50, MaxValue= 100},
                new GoldLoot(){MinValue=500, MaxValue= 1000}
            };
            context.GoldLoots.AddRange(GoldLoots);

            //7.Card
            var Cards = new List<Card>()
            {
                new Card(){Name= "Iris", Description  = "Messenger of the gods",Level = 1, Health = 100, Speed = 5, MythologyType = MythologyType.Greek, IsInDefaultDeck = true},
                new Card(){Name= "Hermes", Description  = "God of thieves",Level = 2, Health = 200, Speed = 7, MythologyType = MythologyType.Greek, IsInDefaultDeck = true},
                new Card(){Name= "Athena", Description  = "Goddess of victory",Level = 3, Health = 350, Speed = 5, MythologyType = MythologyType.Greek, IsInDefaultDeck = true},
                new Card(){Name= "Zeus", Description  = "God of the sky",Level = 4, Health = 500, Speed = 5, MythologyType = MythologyType.Greek, IsInDefaultDeck = true},
                new Card(){Name= "Nemesis", Description  = "Goddess of Revenge",Level = 2, Health = 300, Speed = 5, MythologyType = MythologyType.Greek, IsInDefaultDeck = false}
            };
            context.Cards.AddRange(Cards);

            //8.PackContent
            var PacksContents = new List<PackContent>()
            {
                new PackContent(){Pack = Packs[0], Card = Cards[4] }
            };
            context.PacksContents.AddRange(PacksContents);

            //9.LevelSlot
            var LevelsSlots = new List<LevelSlot>()
            {
                new LevelSlot() { Level = 1, Deck = Decks[0], Card = Cards[0] },
                new LevelSlot() { Level = 2, Deck = Decks[0], Card = Cards[1] },
                new LevelSlot() { Level = 3, Deck = Decks[0], Card = Cards[2] },
                new LevelSlot() { Level = 4, Deck = Decks[0], Card = Cards[3] },
                new LevelSlot() { Level = 1, Deck = Decks[1], Card = Cards[0] },
                new LevelSlot() { Level = 2, Deck = Decks[1], Card = Cards[1] },
                new LevelSlot() { Level = 3, Deck = Decks[1], Card = Cards[2] },
                new LevelSlot() { Level = 4, Deck = Decks[1], Card = Cards[3] },
                new LevelSlot() { Level = 1, Deck = Decks[2], Card = Cards[0] },
                new LevelSlot() { Level = 2, Deck = Decks[2], Card = Cards[1] },
                new LevelSlot() { Level = 3, Deck = Decks[2], Card = Cards[2] },
                new LevelSlot() { Level = 4, Deck = Decks[2], Card = Cards[3] }
            };
            context.LevelsSlots.AddRange(LevelsSlots);

            //10.LootTable
            var LootTables = new List<LootTable>()
            {
                new LootTable () {LootCount = 2}
            };
            context.LootTables.AddRange(LootTables);

            //11.Drop
            var Drops = new List<Drop>()
            {
                new Drop() {LootTable = LootTables[0], Loot = Cards[0], Probability = 0.5f, Enabled = true, Always = false, Unique = false },
                new Drop() {LootTable = LootTables[0], Loot = Cards[1], Probability = 0.2f, Enabled = true, Always = false, Unique = false },
                new Drop() {LootTable = LootTables[0], Loot = Cards[2], Probability = 0.1f, Enabled = true, Always = false, Unique = false },
                new Drop() {LootTable = LootTables[0], Loot = Cards[3], Probability = 0.025f, Enabled = true, Always = false, Unique = false },
                new Drop() {LootTable = LootTables[0], Loot = Cards[4], Probability = 0.15f, Enabled = true, Always = false, Unique = false },
                new Drop() {LootTable = LootTables[0], Loot = GoldLoots[0], Probability = 0.7f, Enabled = true, Always = false, Unique = false },
                new Drop() {LootTable = LootTables[0], Loot = GoldLoots[1], Probability = 0.4f, Enabled = true, Always = false, Unique = false }
            };
            context.Drops.AddRange(Drops);

            //12.Chest
            var Chests = new List<Chest>()
            {
                new Chest(){Name = "Greek Worshiper Chest", Price=750, MythologyType = MythologyType.Greek, LootTable = LootTables[0]}
            };
            context.Chests.AddRange(Chests);

            context.SaveChanges();
        }
    }
}
