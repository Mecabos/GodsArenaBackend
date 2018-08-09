using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class PackRepository : Repository<Pack>, IPackRepository
    {
        public static int DEFAULT_LEVEL_0_CARD_ID = 3;
        public static int DEFAULT_LEVEL_1_CARD_ID = 4;
        public static int DEFAULT_LEVEL_2_CARD_ID = 5;
        public static int DEFAULT_LEVEL_3_CARD_ID = 6;

        private IPackContentRepository _packContentRepository;

        public PackRepository(GodsArenaApiContext context, IPackContentRepository packContentRepository)
            : base(context)
        {
            _packContentRepository = packContentRepository;
        }

        public Pack GetByPlayer(int playerId)
        {
            return GodsArenaApiContext.Packs.Where(p => p.PlayerId == playerId).FirstOrDefault();
        }

        public override void Add(Pack newPack)
        {
            GodsArenaApiContext.Packs.Add(newPack);
        }

        public void AddCard(int playerId, int cardId)
        {
            Pack pack = GetByPlayer(playerId);
            if(pack != null)
            {
                _packContentRepository.AddCard(pack.Id, cardId);
            }
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }
    }
}
