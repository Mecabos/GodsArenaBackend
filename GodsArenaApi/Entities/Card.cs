using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class Card : Loot
    {
        public string Name { get; set; } = "Default_card_name";
        public string Description { get; set; } = "Default_card_description";
        public int Level { get; set; } = 0;
        public int Health { get; set; } = 100;
        public float Speed { get; set; } = 5;
        public MythologyType MythologyType { get; set; } = MythologyType.Generic;
        public bool IsInDefaultDeck { get; set; } = false;

        public virtual List<LevelSlot> LevelsSlots { get; set; }
        public virtual List<PackContent> PackContents { get; set; }
    }
}
