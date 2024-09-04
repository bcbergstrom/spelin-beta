using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.GameGenre;
using api.Models;

namespace api.Mappers
{
    public static class GameGenreMapper
    {
        public static GameGenre ToGame(this GameGenreDTO gameGenre)
        {
            return new GameGenre
            {
                GameId = gameGenre.GameId,
                GenreId = gameGenre.GenreId
            };
        }
    }
}