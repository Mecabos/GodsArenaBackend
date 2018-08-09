using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface IChestRepository : IRepository<Chest>
    {
        bool Exists(int id);
    }
}
