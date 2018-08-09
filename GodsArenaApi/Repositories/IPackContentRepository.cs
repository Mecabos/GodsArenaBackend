using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface IPackContentRepository : IRepository<PackContent>
    {
        void AddCard(int packId, int cardId);
        void AddCardForNewPack(Pack newPack, int cardId);
        void RemoveCard(int packId, int cardId);
        void RemoveCard(PackContent packContent);
        List<PackContent> GetPackContents(int playerId);
    }
}
