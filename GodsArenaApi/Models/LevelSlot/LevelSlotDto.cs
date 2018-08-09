using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Models
{
    public class LevelSlotDto
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public virtual CardDto Card { get; set; }
    }
}
