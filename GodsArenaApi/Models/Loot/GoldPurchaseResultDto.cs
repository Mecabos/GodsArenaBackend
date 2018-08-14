using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Models
{
    public class GoldPurchaseResultDto : LootPurchaseResultDto
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int RolledValue { get; set; }

        public GoldPurchaseResultDto()
            : base()
        {
            Type = "GoldPurchaseResultDto";
        }

    }
}
