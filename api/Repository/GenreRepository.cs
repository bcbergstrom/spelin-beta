using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Genre> DeleteAsync(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x =>x.Id == id);

            if (genre == null)
            {
                return null;
            }
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public Task<Genre> GetByIdAync(int id)
        {
            throw new NotImplementedException();
        }
    }
}