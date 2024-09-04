using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllAsync();
        Task<Game?> GetByIdAsync(int id);
        Task<bool> GameExists(int id);
        Task<Game> CreateAsync(Game game);
        Task<Game?> UpdateAsync(int id, Game game);
        Task<Game?> DeleteAsync(int id);
    }
}