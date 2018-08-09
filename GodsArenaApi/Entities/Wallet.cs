using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public int CoinsEarned { get; set; } = 0;
        public int GoldEarned { get; set; } = 0;

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
