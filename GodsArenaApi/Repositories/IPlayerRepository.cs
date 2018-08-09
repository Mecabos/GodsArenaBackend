using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        bool Exists(int id);
        bool AddWithCheck(Player newPlayer);
    }
}
