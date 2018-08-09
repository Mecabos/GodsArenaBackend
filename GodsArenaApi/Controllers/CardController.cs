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
    [Route("godsarena/card")]
    public class CardController : Controller
    {

        private ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet("")]
        public IActionResult GetAllCards()
        {
            List<Card> cards = _cardRepository.GetAll().ToList();

            List<CardDto> cardsResult = Mapper.Map<List<CardDto>>(cards);

            return Ok(cardsResult);

        }


    }
}