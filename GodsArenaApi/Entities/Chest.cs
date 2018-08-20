using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class Chest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PriceInGold { get; set; }
        public int PriceInCoins { get; set; }
        public MythologyType MythologyType { get; set; } = MythologyType.Generic;
        public string Description { get; set; }

        public int LootTableId { get; set; }
        public virtual LootTable LootTable { get; set; }

    }
}
