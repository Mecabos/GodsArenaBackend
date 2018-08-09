using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class DropRepository : Repository<Drop>, IDropRepository
    {
        public DropRepository(GodsArenaApiContext context)
            : base(context)
        {
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }
    }
}
