using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}