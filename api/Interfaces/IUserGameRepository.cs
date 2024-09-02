using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Models;

namespace api.Interfaces
{
    public interface IUserGameRepository
    {
        Task<List<GameDTO>> GetUserGames(User user);
        Task<UserGame> CreateAsync(UserGame userGame);
    }
}