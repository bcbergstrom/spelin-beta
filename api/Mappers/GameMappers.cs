using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Models;

namespace api.Mappers
{
    public static class GameMappers
    {
        public static GameDTO ToGameDTO(this Game game)
        {
            return new GameDTO{
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price
            };
        }
        public static Game ToGameFromCreateDTO(this CreateGameRequestDTO gameDTO)
        {
            return new Game
            {
                Name = gameDTO.Name,
                Description = gameDTO.Description,
                Price = gameDTO.Price

            };
        }
    }
}