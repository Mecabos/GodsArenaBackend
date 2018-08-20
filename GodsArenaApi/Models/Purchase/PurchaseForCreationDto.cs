using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Models
{
    public class PurchaseForCreationDto
    {
        public int PlayerId { get; set; }
        public int ChestId { get; set; }
        public bool IsPayedInGold { get; set; } = false;
        public int Quantity { get; set; } = 1;
    }
}
