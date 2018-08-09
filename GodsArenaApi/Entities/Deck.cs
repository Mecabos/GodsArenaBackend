using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; } = "My Deck";
        public bool IsActive { get; set; } = true;

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public virtual List<LevelSlot> LevelSlots { get; set; }
    }
}
