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
    [Route("godsarena/player")]
    public class PlayerController : Controller
    {
        private IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet()]
        public IActionResult GetPlayers()
        {
            var playerEntities = _playerRepository.GetAll();
            var results = Mapper.Map<IEnumerable<PlayerDto>>(playerEntities);

            return Ok(results);
        }

        [HttpPost("")]
        public IActionResult CreatePlayer(
            [FromBody] PlayerForCreationDto newPlayer)
        {
            if (newPlayer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finalNewPlayer = Mapper.Map<Player>(newPlayer);

            bool hasAdded= _playerRepository.AddWithCheck(finalNewPlayer);

            if (!_playerRepository.Save() || !hasAdded)
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return Ok(Mapper.Map<PlayerDto>(finalNewPlayer));
        }
    }
}