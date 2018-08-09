using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        private IWalletRepository _walletRepository;
        private IPlayerStatsRepository _playerStatsRepository;
        private IDeckRepository _deckRepository;
        private IPackRepository _packRepository;

        public PlayerRepository(GodsArenaApiContext context, IWalletRepository walletRepository, IPlayerStatsRepository playerStatsRepository, IDeckRepository deckRepository, IPackRepository packRepository)
            : base(context)
        {
            _walletRepository = walletRepository;
            _playerStatsRepository = playerStatsRepository;
            _deckRepository = deckRepository;
            _packRepository = packRepository;
        }

        public bool AddWithCheck(Player newPlayer)
        {
            if (GodsArenaApiContext.Players.Where(p =>p.Username == newPlayer.Username).FirstOrDefault() == null)
            {
                Wallet newWallet = new Wallet() { Player = newPlayer };
                PlayerStats newPlayerStats = new PlayerStats() { Player = newPlayer };
                Deck newDeck1 = new Deck() { Player = newPlayer, Name = "First deck", IsActive = true };
                Deck newDeck2 = new Deck() { Player = newPlayer, Name = "Second deck", IsActive = false };
                Deck newDeck3 = new Deck() { Player = newPlayer, Name = "Third deck", IsActive = false };
                Pack newPack = new Pack() { Player = newPlayer };

                GodsArenaApiContext.Players.Add(newPlayer);

                _walletRepository.Add(newWallet);
                _playerStatsRepository.Add(newPlayerStats);
                _deckRepository.Add(newDeck1);
                _deckRepository.Add(newDeck2);
                _deckRepository.Add(newDeck3);
                _packRepository.Add(newPack);
                return true;
            }
            return false;
        }

        public bool Exists(int id)
        {
            return GodsArenaApiContext.Players.Any(p => p.Id == id);
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }
    }
}
