using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Models
{
    public class DeckWithoutCardInLevelSlotDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "My Deck";
        public bool IsActive { get; set; } = true;
        public virtual List<LevelSlotWithoutCardDto> LevelSlots { get; set; }
    }
}
