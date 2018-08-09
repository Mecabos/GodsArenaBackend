using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GodsArenaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GodsArenaApi.Controllers
{
    [Route("godsarena/pack")]
    public class PackController : Controller
    {
        private IPlayerRepository _playerRepository;
        private IPackRepository _packRepository;

        public PackController(IPlayerRepository playerRepository, IPackRepository packRepository)
        {
            _playerRepository = playerRepository;
            _packRepository = packRepository;
        }

    }
}