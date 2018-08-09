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
        public int Price { get; set; }
        public MythologyType MythologyType { get; set; } = MythologyType.Generic;

        public int LootTableId { get; set; }
        public virtual LootTable LootTable { get; set; }

    }
}
