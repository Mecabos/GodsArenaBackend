using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class GodsArenaApiContext : DbContext
    {
        public GodsArenaApiContext(DbContextOptions<GodsArenaApiContext> options)
            : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<PlayerStats> PlayersStats { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<LevelSlot> LevelsSlots { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<GoldLoot> GoldLoots { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<PackContent> PacksContents { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Chest> Chests { get; set; }
        public DbSet<LootTable> LootTables { get; set; }
        public DbSet<Drop> Drops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //Loot
            modelBuilder.Entity<Card>().HasBaseType<Loot>();
            modelBuilder.Entity<GoldLoot>().HasBaseType<Loot>();

            //Player <=> Wallet
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Wallet)
                .WithOne(w => w.Player)
                .HasForeignKey<Wallet>(w => w.PlayerId);

            //Player <=> Stats
            modelBuilder.Entity<Player>()
                .HasOne(p => p.PlayerStats)
                .WithOne(s => s.Player)
                .HasForeignKey<PlayerStats>(s => s.PlayerId);

            //Player <=> Deck
            modelBuilder.Entity<Deck>()
            .HasOne(d => d.Player)
            .WithMany(p => p.Decks);

            //Deck <=> LevelSlot
            modelBuilder.Entity<LevelSlot>()
            .HasOne(l => l.Deck)
            .WithMany(d => d.LevelSlots);

            //Card <=> LevelSlot  
            modelBuilder.Entity<LevelSlot>()
            .HasOne(l => l.Card)
            .WithMany(c => c.LevelsSlots);

            //Pack => PackContent <= Card
            modelBuilder.Entity<PackContent>().HasKey(p => new { p.PackId, p.CardId });
            modelBuilder.Entity<Pack>().HasMany(p => p.PackContents).WithOne(pc => pc.Pack).HasForeignKey(pc => pc.PackId);
            modelBuilder.Entity<Card>().HasMany(c => c.PackContents).WithOne(pc => pc.Card).HasForeignKey(pc => pc.CardId);

            //Player <=> Pack
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Pack)
                .WithOne(pa => pa.Player)
                .HasForeignKey<Pack>(pa => pa.PlayerId);

            //Player <=> Purchase
            modelBuilder.Entity<Purchase>()
            .HasOne(p => p.Player)
            .WithMany(pl => pl.Purchases);

            //Purchase => Chest
            modelBuilder.Entity<Purchase>()
            .HasOne(p => p.Chest);

            //LootTable <=> Chest
            modelBuilder.Entity<Chest>()
            .HasOne(c => c.LootTable)
            .WithMany(l => l.Chests);

            //Loot => Drop <= LootTable
            modelBuilder.Entity<Drop>().HasKey(d => new { d.LootId, d.LootTableId });
            modelBuilder.Entity<Loot>().HasMany(l => l.Drops).WithOne(d => d.Loot).HasForeignKey(d => d.LootId);
            modelBuilder.Entity<LootTable>().HasMany(l => l.Drops).WithOne(d => d.LootTable).HasForeignKey(d => d.LootTableId);
        }
    }
}
