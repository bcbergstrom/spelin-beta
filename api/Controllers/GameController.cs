using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepo;
        public GameController(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameRepo.GetAllAsync();
            return Ok(games.Select(s => s.ToGameDTO()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var game = await _gameRepo.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game.ToGameDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameRequestDTO gameDTO)
        {
            Console.WriteLine("hitting post");
            var game = gameDTO.ToGameFromCreateDTO();
            await _gameRepo.CreateAsync(game);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGameRequestDTO gameDTO)
        {
            var game = await _gameRepo.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            game = gameDTO.ToGameFromUpdateDTO();
            await _gameRepo.UpdateAsync(id,game);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var game = await _gameRepo.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            await _gameRepo.DeleteAsync(id);
            return Ok();
        }
    }
}