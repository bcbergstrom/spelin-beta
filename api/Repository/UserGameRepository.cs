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
    public class UserGameRepository : IUserGameRepository
    {
        private readonly ApplicationDbContext _context;
        public UserGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserGame> CreateAsync(UserGame userGame)
        {
            await _context.UserGames.AddAsync(userGame);
            await _context.SaveChangesAsync();
            return userGame;
        }

        public async Task<List<Game>> GetUserGames(User user)
        {
            if (user == null) return await Task.FromResult(new List<Game>());


            return await _context.UserGames.Where(u => u.UserId == user.Id)
            .Select(game => new Game{
                Id = game.GameId,
                Name = game.Game.Name,
                Description = game.Game.Description,
                Price = game.Game.Price

            }).ToListAsync();
        }
    }
}