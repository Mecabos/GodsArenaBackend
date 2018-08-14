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
    [Route("godsarena/chest")]
    public class ChestController : Controller
    {
        private IChestRepository _chestRepository;

        public ChestController(IChestRepository chestRepository)
        {
            _chestRepository = chestRepository;
        }

        [HttpGet("")]
        public IActionResult GetAllChests()
        {
            List<Chest> chests = _chestRepository.GetAll().ToList();

            List<ChestDto> chestsResult = Mapper.Map<List<ChestDto>>(chests);

            return Ok(chestsResult);

        }
    }
}