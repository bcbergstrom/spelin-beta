using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.GameGenre;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/gamegenre")]
    public class GameGenreController : ControllerBase
    {
        private readonly IGameGenreRepository _gameGenreRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IGameRepository _gameRepository;
        public GameGenreController(
            IGameGenreRepository gameGenreRepository,
            IGenreRepository genreRepository,
            IGameRepository gameRepository
        )
        {
            _gameGenreRepository = gameGenreRepository;
            _genreRepository = genreRepository;
            _gameRepository = gameRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenresByGameId([FromRoute] int id)
        {
            var gameGenre = await _gameGenreRepository.GetGameGenres(id);
            if (gameGenre == null)
            {
                return NotFound(); ;
            }

            return Ok(gameGenre);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GameGenreDTO gameGenreDTO)
        {
            var game = await _gameRepository.GetByIdAsync(gameGenreDTO.GameId);
            if (game == null)
            {
                return NotFound();
            }
            var genre = await _genreRepository.GetByIdAync(gameGenreDTO.GenreId);
            if (genre == null)
            {
                return NotFound();
            }
            await _gameGenreRepository.CreateAsync(gameGenreDTO.ToGame());
            return Ok();
        }
    }
}