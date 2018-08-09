using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class LootTable
    {
        public int Id { get; set; }
        public int LootCount { get; set; } = 1;

        public virtual List<Chest> Chests { get; set; }

        public virtual List<Drop> Drops { get; set; }
    }
}
