using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.GameGenre;
using api.Dtos.Genre;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GameGenreRepository : IGameGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GameGenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GameGenre> CreateAsync(GameGenre genre)
        {
            await _context.GameGenres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<GameGenre?> DeleteByIdAsync(int gameId, int GenreId)
        {

            var genre = await _context.GameGenres.FirstOrDefaultAsync(x => x.GameId == gameId && x.GenreId == GenreId);
            if (genre == null)
            {
                return null;
            }
            _context.GameGenres.Remove(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<List<GenreDTO>> GetGameGenres(int gameId)
        {
            return await _context.GameGenres.Where(x => x.GameId == gameId).Select(genre => new GenreDTO{
                Id = genre.GenreId,
                Name = genre.Genre.Name
            }).ToListAsync();
        }
    }
}