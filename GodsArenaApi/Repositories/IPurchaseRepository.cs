using GodsArenaApi.Entities;
using GodsArenaApi.Models;
using Random_Distribution_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        bool Exists(int id);
        bool MakePurchase(int playerId, int chestId, bool isPayedInGold, int quantity);
        List<LootDto> ConsumePurchase(int playerId, int purchaseId);
    }
}
