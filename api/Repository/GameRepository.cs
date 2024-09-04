using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Game;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GameRepository: IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Game> CreateAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game?> DeleteAsync(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (game == null)
            {
                return null;
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> GameExists(int id)
        {
            return await _context.Games.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Game?> UpdateAsync(int id, Game game)
        {
            var gameToUpdate = _context.Games.FirstOrDefault(x => x.Id == id);
            if (gameToUpdate == null)
            {
                return null;
            }
            gameToUpdate.Name = game.Name;
            gameToUpdate.Description = game.Description;
            gameToUpdate.Price = game.Price;
            _context.Games.Update(gameToUpdate);
            await _context.SaveChangesAsync();
            return game;
        }


    }
}