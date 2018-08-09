using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class GoldLoot : Loot
    {
        public int MinValue { get; set; } = 100;
        public int MaxValue { get; set; } = 200;
    }
}
