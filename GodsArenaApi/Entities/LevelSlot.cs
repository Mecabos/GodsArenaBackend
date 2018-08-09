using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class LevelSlot
    {
        public int Id { get; set; }
        public int Level { get; set; }

        public int DeckId { get; set; }
        public virtual Deck Deck { get; set; }

        public int CardId { get; set; }
        public virtual Card Card { get; set; }

    }
}
