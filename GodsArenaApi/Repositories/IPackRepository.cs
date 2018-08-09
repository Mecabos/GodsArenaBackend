using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface IPackRepository : IRepository<Pack>
    {
        Pack GetByPlayer(int playerId);
        void AddCard(int playerId, int cardId);
    }
}
