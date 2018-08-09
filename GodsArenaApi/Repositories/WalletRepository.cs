using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class WalletRepository : Repository<Wallet>, IWalletRepository
    {
        public WalletRepository(GodsArenaApiContext context)
            : base(context)
        {
        }

        public Wallet GetByPlayer(int playerId)
        {
            return GodsArenaApiContext.Wallets.Where(w => w.PlayerId == playerId).FirstOrDefault();
        }

        public void UpdateCoinsWithAmount(int playerId, int amount)
        {
            Wallet wallet = GetByPlayer(playerId);
            if (wallet != null)
                wallet.CoinsEarned += amount;
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }
    }
}
