using DiceGameAPI.Models;
using DiceGameAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DiceGameAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IDbService _service;
        public PlayerController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            var players = _service.GetAllPlayers();
            return Ok(players);
        }

        [HttpGet]
        public IActionResult GetPlayer(int id)
        {
            Player player;
            try
            {
                player = _service.GetPlayer(id);
                return Ok(player);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPut]
        public IActionResult ChangePlayerName(int id, string name)
        {
            try
            {
                _service.ChangePlayerName(id, name);
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateNewPlayer(string name)
        {
            var playerId = _service.CreateNewPlayer(name);
            return Ok(playerId);
        }
    }
}
