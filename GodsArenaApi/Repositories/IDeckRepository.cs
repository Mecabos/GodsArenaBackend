using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface IDeckRepository : IRepository<Deck>
    {
        List<int> GetDeckCardsIds(int playerId);
        bool UpdateMultiple(int playerId, List<Deck> newDecks);
    }
}
