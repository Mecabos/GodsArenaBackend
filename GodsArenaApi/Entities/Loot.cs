using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class Loot
    {
        public int LootId { get; set; }

        public virtual List<Drop> Drops { get; set; }
    }
}
