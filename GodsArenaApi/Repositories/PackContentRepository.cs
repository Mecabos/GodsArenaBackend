using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class PackContentRepository : Repository<PackContent>, IPackContentRepository
    {
        private IPackRepository _packRepository;
        private IDeckRepository _deckRepository;
        private ILevelSlotRepository _levelSlotRepository;

        public PackContentRepository(GodsArenaApiContext context/*, IPackRepository packRepository, IDeckRepository deckRepository*/, ILevelSlotRepository levelSlotRepository)
            : base(context)
        {
            _packRepository = new PackRepository(context,this);
            _deckRepository = new DeckRepository(context, levelSlotRepository, _packRepository, this);
        }

        public void AddCard(int packId, int cardId)
        {
            PackContent packContent = FindOneBy(pc => pc.PackId == packId, pc => pc.CardId == cardId);
            
            if (packContent == null)
                GodsArenaApiContext.PacksContents.Add(new PackContent() { PackId = packId, CardId = cardId });
            else
                packContent.Count++;
        }

        public void AddCardForNewPack(Pack newPack, int cardId)
        {
                GodsArenaApiContext.PacksContents.Add(new PackContent() { Pack = newPack, CardId = cardId });
        }

        public void RemoveCard(int packId, int cardId)
        {
            PackContent packContent = FindOneBy(pc => pc.PackId == packId, pc => pc.CardId == cardId);
            //TODO:MAYBE ADD EXCEPTION HERE For when pack content is null (can't remove card if it wasn't in pack !)
            if (packContent != null)
                if (packContent.Count == 1)
                    Remove(packContent);
                else
                    packContent.Count--;
        }

        public void RemoveCard(PackContent packContent)
        {
            //TODO:MAYBE ADD EXCEPTION HERE For when pack content is null (can't remove card if it wasn't in pack !)
            if (packContent != null)
                if (packContent.Count == 1)
                    Remove(packContent);
                else
                    packContent.Count--;
        }

        public List<PackContent> GetPackContents(int playerId)
        {
            int packId = _packRepository.FindOneBy(p => p.PlayerId == playerId).Id;
            List<PackContent> packContents = GetMultipleInclude<PackContent>(pc => pc.PackId == packId, pc => pc.Card).ToList();
            return packContents;
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }
    }
}
