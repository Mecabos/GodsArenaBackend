using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GodsArenaApi.Entities;
using GodsArenaApi.Models;
using GodsArenaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Random_Distribution_System;

namespace GodsArenaApi.Controllers
{
    [Route("godsarena/purchase")]
    public class PurchaseController : Controller
    {
        private IPurchaseRepository _purchaseRepository;
        private IPlayerRepository _playerRepository;
        private IChestRepository _chestRepository;


        public PurchaseController(IPlayerRepository playerRepository, IPurchaseRepository purchaseRepository, IChestRepository chestRepository)
        {
            _playerRepository = playerRepository;
            _purchaseRepository = purchaseRepository;
            _chestRepository = chestRepository;
        }

        [HttpPost("makePurchase")]
        public IActionResult MakePurchase(
            [FromBody] PurchaseForCreationDto newPurchase)
        {
            if (newPurchase == null)
            {
                return BadRequest();
            }

            if (!_playerRepository.Exists(newPurchase.PlayerId) || !_chestRepository.Exists(newPurchase.ChestId))
            {
                return NotFound();
            }

            _purchaseRepository.MakePurchase(newPurchase.PlayerId, newPurchase.ChestId);

            if (!_purchaseRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return Ok("Purchase validated with success");

            //var createdPointOfInterestToReturn = Mapper.Map<PointOfInterestDto>(finalPointOfInterest);

            //return CreatedAtRoute("GetPointOfInterest", new
            //{ cityId = cityId, id = createdPointOfInterestToReturn.Id }, createdPointOfInterestToReturn);

        }

        [HttpPost("consumePurchase")]
        public IActionResult ConsumePurchase(
            [FromBody] PurchaseForConsumptionDto purchaseToConsume)
        {
            if (purchaseToConsume == null)
            {
                return BadRequest();
            }

            if (!_purchaseRepository.Exists(purchaseToConsume.Id))
            {
                return NotFound();
            }

            List<LootDto> rollResult = _purchaseRepository.ConsumePurchase(purchaseToConsume.Id);

            if(rollResult != null)
            {
                if (!_purchaseRepository.Save())
                {
                    return StatusCode(500, "A problem happened while handling your request");
                }

                return Ok(rollResult);
            }

            return StatusCode(500, "Purchase of Id " + purchaseToConsume.Id + " already consumed");

            //var createdPointOfInterestToReturn = Mapper.Map<PointOfInterestDto>(finalPointOfInterest);

            //return CreatedAtRoute("GetPointOfInterest", new
            //{ cityId = cityId, id = createdPointOfInterestToReturn.Id }, createdPointOfInterestToReturn);

        }
    }
}