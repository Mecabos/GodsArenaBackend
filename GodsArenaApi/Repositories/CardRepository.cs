using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(GodsArenaApiContext context)
            : base(context)
        {
        }

        public Card GetDefaultLevelCard(int level)
        {
            return FindOneBy(c => c.Level == level, c => c.IsInDefaultDeck == true);
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }

    }
}
