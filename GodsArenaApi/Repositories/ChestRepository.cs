using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class ChestRepository : Repository<Chest>, IChestRepository
    {
        public ChestRepository(GodsArenaApiContext context)
            : base(context)
        {
        }

        public bool Exists(int id)
        {
            return GodsArenaApiContext.Chests.Any(p => p.Id == id);
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }
    }
}
