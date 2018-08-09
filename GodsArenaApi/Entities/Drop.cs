using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class Drop
    {
        
        public int LootId { get; set; }
        public virtual Loot Loot { get; set; }
        public int LootTableId { get; set; }
        public virtual LootTable LootTable { get; set; }
        public float Probability { get; set; }
        public bool Always { get; set; } = false;
        public bool Enabled { get; set; } = true;
        public bool Unique { get; set; } = false;
    }
}
