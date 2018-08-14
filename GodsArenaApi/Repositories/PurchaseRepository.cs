using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Random_Distribution_System;
using GodsArenaApi.Models;

namespace GodsArenaApi.Repositories
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        private IChestRepository _chestRepository;
        private IPlayerRepository _playerRepository;
        private ILootTableRepository _lootTableRepository;

        public PurchaseRepository(GodsArenaApiContext context, IChestRepository chestRepository, IPlayerRepository playerRepository, ILootTableRepository lootTableRepository)
            : base(context)
        {
            _chestRepository = chestRepository;
            _playerRepository = playerRepository;
            _lootTableRepository = lootTableRepository;
        }

        public bool Exists(int id)
        {
            return GodsArenaApiContext.Purchases.Any(p => p.Id == id);
        }

        public void MakePurchase(int playerId, int chestId)
        {
            Player buyerPlayer = _playerRepository.Get(playerId);
            Chest boughtChest = _chestRepository.Get(chestId);
            //TODO: check fusseau horaire
            Purchase newPurchase = new Purchase() { Date = DateTime.Now, IsConsumed = false, Player = buyerPlayer, Chest = boughtChest };
            Add(newPurchase);
        }

        public List<LootDto> ConsumePurchase(int playerId, int purchaseId)
        {
            Purchase purchaseToConsume = GetInclude<Purchase>(p => p.Id == purchaseId, p => p.Chest);
            if (purchaseToConsume.PlayerId == playerId)
            {
                Chest chestToOpen = purchaseToConsume.Chest;

                if (!purchaseToConsume.IsConsumed)
                {
                    purchaseToConsume.IsConsumed = true;
                    List<LootDto> lootResult = _lootTableRepository.RollLoot(chestToOpen.LootTableId, purchaseToConsume.PlayerId);
                    return lootResult;
                }
            }
            
            return null;
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }        
    }
}
