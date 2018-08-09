using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GodsArenaApi.Entities;
using GodsArenaApi.Models;
using GodsArenaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GodsArenaApi.Controllers
{
    [Route("godsArena/deck")]
    public class DeckController : Controller
    {
        private IDeckRepository _deckRepository;
        private IPlayerRepository _playerRepository;
        private ILevelSlotRepository _levelSlotRepository;

        public DeckController(IPlayerRepository playerRepository, IDeckRepository deckRepository, ILevelSlotRepository levelSlotRepository)
        {
            _playerRepository = playerRepository;
            _deckRepository = deckRepository;
            _levelSlotRepository = levelSlotRepository;
        }

        [HttpGet("{playerId}")]
        public IActionResult GetDecks(int playerId)
        {
            if (!_playerRepository.Exists(playerId))
            {
                return NotFound();
            }

            List<Deck> decks = _deckRepository.FindBy(d => d.PlayerId == playerId).ToList();

            foreach (var deck in decks)
            {
                deck.LevelSlots = _levelSlotRepository.GetMultipleInclude<LevelSlot>(ls => ls.DeckId == deck.Id, ls => ls.Card).ToList();
            }

            List<DeckWithoutCardInLevelSlotDto> decksResult = Mapper.Map<List<DeckWithoutCardInLevelSlotDto>>(decks);
            foreach (var deck in decksResult)
            {
                deck.LevelSlots.OrderBy(ls => ls.Level);
            }

            return Ok(decksResult);

        }

        [HttpPost("{playerId}")]
        public IActionResult UpdateDecks(int playerId,
            [FromBody] List<DeckWithoutCardInLevelSlotDto> decks)
        {
            if (decks == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_playerRepository.Exists(playerId))
            {
                return NotFound();
            }

            List<Deck> decksToUpdate = Mapper.Map<List<Deck>>(decks);
            
            if(_deckRepository.UpdateMultiple(playerId, decksToUpdate))
            {
                if (!_deckRepository.Save())
                {
                    return StatusCode(500, "A problem happened while handling your request");
                }
            }
            else
            {
                return StatusCode(500, "Update Was Not valid !");
            }

            return NoContent();
        }
    }
}