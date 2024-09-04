using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.GameGenre;
using api.Dtos.Genre;
using api.Models;

namespace api.Interfaces
{
    public interface IGameGenreRepository
    {
        Task<GameGenre> CreateAsync(GameGenre genre);
        Task<GameGenre?> DeleteByIdAsync(int gameId, int GenreId);
        Task<List<GenreDTO>> GetGameGenres(int gameId);
        
    }
}