using GodsArenaApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class DeckRepository : Repository<Deck>, IDeckRepository
    {
        private ILevelSlotRepository _levelSlotRepository;
        private IPackRepository _packRepository;
        private IPackContentRepository _packContentRepository;

        public DeckRepository(GodsArenaApiContext context, ILevelSlotRepository levelSlotRepository, IPackRepository packRepository, IPackContentRepository packContentRepository)
            : base(context)
        {
            _levelSlotRepository = levelSlotRepository;
            _packRepository = packRepository;
            _packContentRepository = packContentRepository;
        }

        public override void Add(Deck newDeck)
        {
            LevelSlot newLevelSlot1 = new LevelSlot() { Level = 0, Deck = newDeck, CardId = PackRepository.DEFAULT_LEVEL_0_CARD_ID };
            LevelSlot newLevelSlot2 = new LevelSlot() { Level = 1, Deck = newDeck, CardId = PackRepository.DEFAULT_LEVEL_1_CARD_ID };
            LevelSlot newLevelSlot3 = new LevelSlot() { Level = 2, Deck = newDeck, CardId = PackRepository.DEFAULT_LEVEL_2_CARD_ID };
            LevelSlot newLevelSlot4 = new LevelSlot() { Level = 3, Deck = newDeck, CardId = PackRepository.DEFAULT_LEVEL_3_CARD_ID };

            GodsArenaApiContext.Decks.Add(newDeck);

            _levelSlotRepository.Add(newLevelSlot1);
            _levelSlotRepository.Add(newLevelSlot2);
            _levelSlotRepository.Add(newLevelSlot3);
            _levelSlotRepository.Add(newLevelSlot4);
        }

        public List<int> GetDeckCardsIds(int playerId)
        {
            Deck deck = FindOneBy(d => d.PlayerId == playerId, d => d.IsActive == true);
            List<LevelSlot> levelSlots = _levelSlotRepository.GetMultipleInclude<LevelSlot>(ls => ls.DeckId == deck.Id, ls => ls.Card).ToList();
            return levelSlots.Select(ls => ls.CardId).ToList();
        }

        public bool UpdateMultiple(int playerId, List<Deck> newDecks)
        {
            bool updateIsValid = true;
            var optionsBuilder = new DbContextOptionsBuilder<GodsArenaApiContext>();
            optionsBuilder.UseSqlServer(Startup.connectionString);
            using (var context = new GodsArenaApiContext(optionsBuilder.Options))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Pack pack = _packRepository.GetInclude<Pack>(p => p.PlayerId == playerId, p => p.PackContents);
                    List<int> levelSlotIdTakenCardFromList = new List<int>();
                    //List of the Player old decks state
                    List<Deck> oldDecks = GetMultipleInclude<Deck>(d => d.PlayerId == playerId, d => d.LevelSlots).ToList();
                    Dictionary<int, Dictionary<int, LevelSlot>> levelTo_IdToLevelSlotDictionaryForLooping = new Dictionary<int, Dictionary<int, LevelSlot>>();
                    //Will be used as a cash to search in the old levelSlots
                    Dictionary<int, Dictionary<int, LevelSlot>> levelTo_IdToLevelSlotDictionaryForVerification = new Dictionary<int, Dictionary<int, LevelSlot>>();
                    Dictionary<int, Deck> idToDeckDictionary = new Dictionary<int, Deck>();

                    foreach (var deck in oldDecks)
                    {
                        idToDeckDictionary.Add(deck.Id, deck);

                        foreach (var levelSlot in deck.LevelSlots)
                        {
                            if (!levelTo_IdToLevelSlotDictionaryForVerification.ContainsKey(levelSlot.Level))
                            {
                                levelTo_IdToLevelSlotDictionaryForVerification.Add(levelSlot.Level, new Dictionary<int, LevelSlot>());
                                levelTo_IdToLevelSlotDictionaryForLooping.Add(levelSlot.Level, new Dictionary<int, LevelSlot>());
                            }

                            levelTo_IdToLevelSlotDictionaryForVerification[levelSlot.Level].Add(levelSlot.Id, levelSlot);
                            levelTo_IdToLevelSlotDictionaryForLooping[levelSlot.Level].Add(levelSlot.Id, levelSlot);
                        }
                    }


                    foreach (var newDeck in newDecks)
                    {
                        if (updateIsValid)
                        {
                            var oldDeck = idToDeckDictionary[newDeck.Id];
                            foreach (var oldLevelSlot in oldDeck.LevelSlots)
                            {
                                LevelSlot newLevelSlot = newDeck.LevelSlots.Find(ls => ls.Level == oldLevelSlot.Level);
                                if (oldLevelSlot.CardId != newLevelSlot.CardId)
                                {
                                    //Immediatly take it out of consideration as we won't look in itself for the card
                                    levelTo_IdToLevelSlotDictionaryForVerification[oldLevelSlot.Level].Remove(oldLevelSlot.Id);
                                    PackContent packContentContainingNewDeckCard = pack.PackContents.Find(pc => pc.CardId == newLevelSlot.CardId);
                                    if (packContentContainingNewDeckCard != null)
                                    {
                                        _packContentRepository.RemoveCard(packContentContainingNewDeckCard);
                                        if (!levelSlotIdTakenCardFromList.Contains(oldLevelSlot.Id))
                                            _packContentRepository.AddCard(pack.Id, oldLevelSlot.CardId);
                                        _packContentRepository.Save();                               
                                    }
                                    else
                                    {
                                        LevelSlot levelSlotContainingNewDeckCard = levelTo_IdToLevelSlotDictionaryForVerification[oldLevelSlot.Level].Where(p => p.Value.CardId == newLevelSlot.CardId).FirstOrDefault().Value;
                                        if (levelSlotContainingNewDeckCard != null)
                                        {
                                            levelSlotIdTakenCardFromList.Add(levelSlotContainingNewDeckCard.Id);
                                            levelTo_IdToLevelSlotDictionaryForVerification[oldLevelSlot.Level].Remove(levelSlotContainingNewDeckCard.Id);
                                            _packContentRepository.AddCard(pack.Id, oldLevelSlot.CardId);
                                            _packContentRepository.Save();
                                        }
                                        else
                                        {
                                            //Here it hasn't been found in pack neither in any old level slot so it came from nowhere and can't be added
                                            transaction.Rollback();
                                            updateIsValid = false;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    //Here if updateIsValid is till true it means that the update is valid and we can then modify the decks
                    if (updateIsValid)
                    {
                        foreach (var newDeck in newDecks)
                        {
                            var oldDeck = idToDeckDictionary[newDeck.Id];
                            foreach (var newLevelSlot in newDeck.LevelSlots)
                            {
                                //levelTo_IdToLevelSlotDictionaryForLooping[newLevelSlot.Level][newLevelSlot.Id].CardId = newLevelSlot.CardId;
                                oldDeck.LevelSlots.Where(ls => ls.Level == newLevelSlot.Level).FirstOrDefault().CardId = newLevelSlot.CardId;
                            }
                        }
                        transaction.Commit();
                    }
                }
            }

            return updateIsValid;
        }

        public GodsArenaApiContext GodsArenaApiContext
        {
            get { return Context as GodsArenaApiContext; }
        }
    }
}
