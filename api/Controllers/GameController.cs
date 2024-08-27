using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Game;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var games = _context.Games.ToList()
            .Select(s => s.ToGameDTO());
            return Ok(games);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game.ToGameDTO());
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateGameRequestDTO gameDTO)
        {
            var gameModel = gameDTO.ToGameFromCreateDTO();
            _context.Games.Add(gameModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = gameModel.Id }, gameModel.ToGameDTO());
        }
    }
}