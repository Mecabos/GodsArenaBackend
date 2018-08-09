using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        Card GetDefaultLevelCard(int level);
    }
}
