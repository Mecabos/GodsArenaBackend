using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsConsumed { get; set; } = false;

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int ChestId { get; set; }
        public Chest Chest { get; set; }

    }
}
