using GodsArenaApi.Entities;
using GodsArenaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Models
{
    public class GoldLootDto : LootDto
    {
        public int MinValue { get; set; } = 100;
        public int MaxValue { get; set; } = 200;
        public int RolledValue { get; set; }

        public GoldLootDto() {}

        public GoldLootDto(GoldLootDto otherGoldLootDto)
            :base()
        {
            LootId = otherGoldLootDto.LootId;
            MinValue = otherGoldLootDto.MinValue;
            MaxValue = otherGoldLootDto.MaxValue;
            MinValue = otherGoldLootDto.MinValue;
        }
    }
}
