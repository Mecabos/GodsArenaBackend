using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GodsArenaApi.Entities;
using Random_Distribution_System;

namespace GodsArenaApi.Models
{
    public class CardDropItem : RDSObject
    {
        public CardDto CardDto { get;}

        public CardDropItem(Drop drop,Loot loot)
            : base(drop.Probability,drop.Unique, drop.Always, drop.Enabled)
        {
            if (loot is Card card)
                CardDto = Mapper.Map<CardDto>(card);
        }


    }
}
