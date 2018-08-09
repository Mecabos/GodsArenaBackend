using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        Wallet GetByPlayer(int playerId);
        void UpdateCoinsWithAmount(int playerId ,int amount);
    }
}
