using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GodsArenaApi.Entities;
using Random_Distribution_System;

namespace GodsArenaApi.Models
{
    public class GoldDropItem : RDSValue<int>, IRDSObjectCreator
    {
        public GoldLootDto GoldLootDto { get;}

        public GoldDropItem(Drop drop,GoldLoot goldLoot)
            : base(0,drop.Probability, drop.Unique, drop.Always, drop.Enabled)
        {
            GoldLootDto = Mapper.Map<GoldLootDto>(goldLoot);
            rdsValue = RDSRandom.GetIntValue(GoldLootDto.MinValue, GoldLootDto.MaxValue);
            GoldLootDto.RolledValue = rdsValue;
        }


        public GoldDropItem(GoldDropItem goldDropItem)
            : base(0, goldDropItem.rdsProbability, goldDropItem.rdsUnique, goldDropItem.rdsAlways, goldDropItem.rdsEnabled)
        {
            GoldLootDto = new GoldLootDto(goldDropItem.GoldLootDto);
            rdsValue = RDSRandom.GetIntValue(GoldLootDto.MinValue, GoldLootDto.MaxValue);
            GoldLootDto.RolledValue = rdsValue;
        }

        public virtual IRDSObject rdsCreateInstance()
        {
            return new GoldDropItem(this);
        }
    }
}
