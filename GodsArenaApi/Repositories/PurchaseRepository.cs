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

        public bool MakePurchase(int playerId, int chestId, bool isPayedInGold, int quantity)
        {
            Player buyerPlayer = _playerRepository.GetInclude<Player>(p => p.Id == playerId, p => p.Wallet);
            Chest boughtChest = _chestRepository.Get(chestId);
            if (isPayedInGold)
            {
                int finalPrice = quantity * boughtChest.PriceInGold;
                if (buyerPlayer.Wallet.GoldEarned >= finalPrice)
                    buyerPlayer.Wallet.GoldEarned -= finalPrice;
                else
                    return false;
            }
            else
            {
                int finalPrice = quantity * boughtChest.PriceInCoins;
                if (buyerPlayer.Wallet.CoinsEarned >= finalPrice)
                    buyerPlayer.Wallet.CoinsEarned -= finalPrice;
                else
                    return false;
            }

            for (int i = 0; i < quantity; i++)
            {
                //TODO: check fusseau horaire
                Purchase newPurchase = new Purchase() { Date = DateTime.Now, IsConsumed = false, Player = buyerPlayer, Chest = boughtChest };
                Add(newPurchase);
            }

            return true;
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
