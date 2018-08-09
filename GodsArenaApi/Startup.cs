using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GodsArenaApi.Entities;
using GodsArenaApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GodsArenaApi
{
    public class Startup
    {
        public static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=GodsArenaDb;Trusted_Connection=True;";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //****** DataBase
            services.AddDbContext<GodsArenaApiContext>(o => o.UseSqlServer(connectionString));

            //****** Repository
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerStatsRepository, PlayerStatsRepository>();
            services.AddScoped<IDeckRepository, DeckRepository>();
            services.AddScoped<ILevelSlotRepository, LevelSlotRepository>();
            services.AddScoped<ILootRepository, LootRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IGoldLootRepository, GoldLootRepository>();
            services.AddScoped<IPackRepository, PackRepository>();
            services.AddScoped<IPackContentRepository, PackContentRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IChestRepository, ChestRepository>();
            services.AddScoped<ILootTableRepository, LootTableRepository>();
            services.AddScoped<IDropRepository, DropRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GodsArenaApiContext godsArenaApiContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            godsArenaApiContext.EnsureSeedDataForContext();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                //Player
                cfg.CreateMap<Models.PlayerForCreationDto, Entities.Player>();
                cfg.CreateMap<Entities.Player, Models.PlayerDto>();
                cfg.CreateMap<Models.PlayerDto, Entities.Player>();
                //Loot
                cfg.CreateMap<Entities.Loot, Models.LootDto>();
                cfg.CreateMap<Entities.Card, Models.CardDto>();
                cfg.CreateMap<Entities.GoldLoot, Models.GoldLootDto>();
                //PackContent
                cfg.CreateMap<Entities.PackContent, Models.PackContentDto>();
                cfg.CreateMap<Entities.PackContent, Models.PackContentWithoutCardDto>();
                //Deck
                cfg.CreateMap<Entities.Deck, Models.DeckDto>();
                cfg.CreateMap<Entities.Deck, Models.DeckWithoutCardInLevelSlotDto>();
                cfg.CreateMap<Models.DeckWithoutCardInLevelSlotDto, Entities.Deck>();
                
                //LevelSlot
                cfg.CreateMap<Entities.LevelSlot, Models.LevelSlotDto>();
                cfg.CreateMap<Entities.LevelSlot, Models.LevelSlotWithoutCardDto>();
                cfg.CreateMap<Models.LevelSlotWithoutCardDto, Entities.LevelSlot>();

            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
