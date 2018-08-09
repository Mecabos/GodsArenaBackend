using System;
using System.Collections.Generic;
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
    [Route("godsArena/packContent")]
    public class PackContentController : Controller
    {

        private IPlayerRepository _playerRepository;
        private IPackRepository _packRepository;
        private IPackContentRepository _packContentRepository;

        public PackContentController(IPlayerRepository playerRepository, IPackContentRepository packContentRepository, IPackRepository packRepository)
        {
            _playerRepository = playerRepository;
            _packContentRepository = packContentRepository;
            _packRepository = packRepository;
        }

        [HttpGet("{playerId}")]
        public IActionResult GetPackContent(int playerId)
        {
            if (!_playerRepository.Exists(playerId))
            {
                return NotFound();
            }

            List<PackContent> packContents = _packContentRepository.GetPackContents(playerId);

            List<PackContentWithoutCardDto> packContentsResult = Mapper.Map<List<PackContentWithoutCardDto>>(packContents);

            return Ok(packContentsResult);

        }

        //[HttpPost("{playerId}")]
        //public IActionResult UpdatePackContent(int playerId,
        //    [FromBody] List<PackContentForUpdateDto> packContents)
        //{
        //    if (packContents == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!_playerRepository.Exists(playerId))
        //    {
        //        return NotFound();
        //    }

        //    List<Deck> decksToUpdate = Mapper.Map<List<Deck>>(decks);
        //    _deckRepository.UpdateMultiple(decksToUpdate);

        //    if (!_deckRepository.Save())
        //    {
        //        return StatusCode(500, "A problem happened while handling your request");
        //    }

        //    return NoContent();
        //}
    }
}