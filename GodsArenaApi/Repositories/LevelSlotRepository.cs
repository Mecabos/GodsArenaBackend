using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class LevelSlotRepository : Repository<LevelSlot>, ILevelSlotRepository
    {
        private ICardRepository _cardRepository;

        public LevelSlotRepository(GodsArenaApiContext context, ICardRepository cardRepository)
            : base(context)
        {
            _cardRepository = cardRepository;
        }

        public override void Add(LevelSlot levelSlot)
        {
            Card levelSlotDefaultCard = _cardRepository.GetDefaultLevelCard(levelSlot.Level);
            levelSlot.Card = levelSlotDefaultCard;

            GodsArenaApiContext.LevelsSlots.Add(levelSlot);
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }
    }
}
