using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class PackContent
    {
        public int PackId { get; set; }
        public virtual Pack Pack { get; set; }
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
        public int Count { get; set; } = 1;

    }
}
