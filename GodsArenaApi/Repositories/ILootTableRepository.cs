using GodsArenaApi.Entities;
using GodsArenaApi.Models;
using Random_Distribution_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface ILootTableRepository : IRepository<LootTable>
    {
        List<LootDto> RollLoot(int lootTableId, int playerId);
    }
}
