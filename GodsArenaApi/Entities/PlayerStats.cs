using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class PlayerStats
    {
        public int Id { get; set; }
        public int KillCount { get; set; } = 0;
        public float RecievedDmg { get; set; } = 0;
        public float AppliedDmg { get; set; } = 0;

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        
    }
}
