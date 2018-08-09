using GodsArenaApi.Entities;
using GodsArenaApi.Models;
using Random_Distribution_System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class LootTableRepository : Repository<LootTable>, ILootTableRepository
    {
        private IGoldLootRepository _goldLootRepository;
        private ILootRepository _lootRepository;
        private IWalletRepository _walletRepository;
        private IPackRepository _packRepository;


        public LootTableRepository(GodsArenaApiContext context, IGoldLootRepository goldLootRepository, ILootRepository lootRepository, IWalletRepository walletRepository, IPackRepository packRepository)
            : base(context)
        {
            _goldLootRepository = goldLootRepository;
            _lootRepository = lootRepository;
            _walletRepository = walletRepository;
            _packRepository = packRepository;
        }

        public List<LootDto> RollLoot(int lootTableId, int playerId)
        {
            LootTable lootTable = GetInclude<LootTable>(l => l.Id == lootTableId, l => l.Drops);
            DropTable dropTable = new DropTable(lootTable);
            foreach (Drop drop in lootTable.Drops)
            {
                Loot loot = _lootRepository.Get(drop.LootId);
                if (loot is GoldLoot goldLoot)
                {
                    GoldDropItem valueDropItem = new GoldDropItem(drop, goldLoot);
                    dropTable.AddEntry(valueDropItem);
                }
                else if (loot is Card)
                {
                    Card card = (Card)loot;
                    CardDropItem dropItem = new CardDropItem(drop, card);
                    dropTable.AddEntry(dropItem);
                }
            }

            IEnumerable<IRDSObject> result = dropTable.rdsResult;
            List<LootDto> rolledLoot = new List<LootDto>();
            foreach (var loot in result)
            {
                if (loot is CardDropItem cardDropItem)
                {
                    _packRepository.AddCard(playerId, cardDropItem.CardDto.LootId);
                    rolledLoot.Add(cardDropItem.CardDto);
                }
                else if (loot is GoldDropItem goldDropItem)
                {
                    _walletRepository.UpdateCoinsWithAmount(playerId, goldDropItem.rdsValue);
                    rolledLoot.Add(goldDropItem.GoldLootDto);
                }
            }



            return rolledLoot;
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }

        
    }
}
