using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Genre;
using api.Models;

namespace api.Mappers
{
    public static class GenreMapper
    {
        public static GenreDTO ToGenreDTO(this Genre genre)
        {
            return new GenreDTO
            {
                Name = genre.Name,
                Description = genre.Description
            };
        }

        public static Genre ToGenreFromCreateDTO(this GenreDTO genreDTO)
        {
            return new Genre
            {
                Name = genreDTO.Name,
                Description = genreDTO.Description
            };
        }
    }
}