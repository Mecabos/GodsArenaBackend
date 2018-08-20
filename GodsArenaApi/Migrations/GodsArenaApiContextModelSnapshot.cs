﻿// <auto-generated />
using System;
using GodsArenaApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GodsArenaApi.Migrations
{
    [DbContext(typeof(GodsArenaApiContext))]
    partial class GodsArenaApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GodsArenaApi.Entities.Chest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("LootTableId");

                    b.Property<int>("MythologyType");

                    b.Property<string>("Name");

                    b.Property<int>("PriceInCoins");

                    b.Property<int>("PriceInGold");

                    b.HasKey("Id");

                    b.HasIndex("LootTableId");

                    b.ToTable("Chests");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Drop", b =>
                {
                    b.Property<int>("LootId");

                    b.Property<int>("LootTableId");

                    b.Property<bool>("Always");

                    b.Property<bool>("Enabled");

                    b.Property<float>("Probability");

                    b.Property<bool>("Unique");

                    b.HasKey("LootId", "LootTableId");

                    b.HasIndex("LootTableId");

                    b.ToTable("Drops");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.LevelSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId");

                    b.Property<int>("DeckId");

                    b.Property<int>("Level");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("DeckId");

                    b.ToTable("LevelsSlots");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Loot", b =>
                {
                    b.Property<int>("LootId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("LootId");

                    b.ToTable("Loot");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Loot");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.LootTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LootCount");

                    b.HasKey("Id");

                    b.ToTable("LootTables");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Pack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Packs");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.PackContent", b =>
                {
                    b.Property<int>("PackId");

                    b.Property<int>("CardId");

                    b.Property<int>("Count");

                    b.HasKey("PackId", "CardId");

                    b.HasIndex("CardId");

                    b.ToTable("PacksContents");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.PlayerStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AppliedDmg");

                    b.Property<int>("KillCount");

                    b.Property<int>("PlayerId");

                    b.Property<float>("RecievedDmg");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("PlayersStats");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChestId");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsConsumed");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("ChestId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoinsEarned");

                    b.Property<int>("GoldEarned");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Card", b =>
                {
                    b.HasBaseType("GodsArenaApi.Entities.Loot");

                    b.Property<string>("Description");

                    b.Property<int>("Health");

                    b.Property<bool>("IsInDefaultDeck");

                    b.Property<int>("Level");

                    b.Property<int>("MythologyType");

                    b.Property<string>("Name");

                    b.Property<float>("Speed");

                    b.ToTable("Card");

                    b.HasDiscriminator().HasValue("Card");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.GoldLoot", b =>
                {
                    b.HasBaseType("GodsArenaApi.Entities.Loot");

                    b.Property<int>("MaxValue");

                    b.Property<int>("MinValue");

                    b.ToTable("GoldLoot");

                    b.HasDiscriminator().HasValue("GoldLoot");
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Chest", b =>
                {
                    b.HasOne("GodsArenaApi.Entities.LootTable", "LootTable")
                        .WithMany("Chests")
                        .HasForeignKey("LootTableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Deck", b =>
                {
                    b.HasOne("GodsArenaApi.Entities.Player", "Player")
                        .WithMany("Decks")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Drop", b =>
                {
                    b.HasOne("GodsArenaApi.Entities.Loot", "Loot")
                        .WithMany("Drops")
                        .HasForeignKey("LootId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GodsArenaApi.Entities.LootTable", "LootTable")
                        .WithMany("Drops")
                        .HasForeignKey("LootTableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GodsArenaApi.Entities.LevelSlot", b =>
                {
                    b.HasOne("GodsArenaApi.Entities.Card", "Card")
                        .WithMany("LevelsSlots")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GodsArenaApi.Entities.Deck", "Deck")
                        .WithMany("LevelSlots")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Pack", b =>
                {
                    b.HasOne("GodsArenaApi.Entities.Player", "Player")
                        .WithOne("Pack")
                        .HasForeignKey("GodsArenaApi.Entities.Pack", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GodsArenaApi.Entities.PackContent", b =>
                {
                    b.HasOne("GodsArenaApi.Entities.Card", "Card")
                        .WithMany("PackContents")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GodsArenaApi.Entities.Pack", "Pack")
                        .WithMany("PackContents")
                        .HasForeignKey("PackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GodsArenaApi.Entities.PlayerStats", b =>
                {
                    b.HasOne("GodsArenaApi.Entities.Player", "Player")
                        .WithOne("PlayerStats")
                        .HasForeignKey("GodsArenaApi.Entities.PlayerStats", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Purchase", b =>
                {
                    b.HasOne("GodsArenaApi.Entities.Chest", "Chest")
                        .WithMany()
                        .HasForeignKey("ChestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GodsArenaApi.Entities.Player", "Player")
                        .WithMany("Purchases")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GodsArenaApi.Entities.Wallet", b =>
                {
                    b.HasOne("GodsArenaApi.Entities.Player", "Player")
                        .WithOne("Wallet")
                        .HasForeignKey("GodsArenaApi.Entities.Wallet", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
