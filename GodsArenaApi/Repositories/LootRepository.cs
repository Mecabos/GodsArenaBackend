using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class LootRepository : Repository<Loot>, ILootRepository
    {
        public LootRepository(GodsArenaApiContext context)
            : base(context)
        {
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }
    }
}
