using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Genre;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;



namespace api.Controllers
{
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var genre = await _genreRepository.GetByIdAync(id);
            if (genre == null)
            {
                return NotFound(); ;
            }
            return Ok(genre.ToGenreDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try{
            await _genreRepository.DeleteAsync(id);
            return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GenreDTO genreDTO)
        {
            var genre = genreDTO.ToGenreFromCreateDTO();
            await _genreRepository.CreateAsync(genre);
            return Ok();
        }

    }
}