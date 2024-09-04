using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Game;
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

        public async Task<List<GameDTO>> GetUserGames(User user)
        {
            if (user == null) return  new List<GameDTO>();


            return await _context.UserGames.Where(u => (u.UserId) == Convert.ToInt32(user.Id))
            .Select(game => new GameDTO
            {
                Id = game.GameId,
                Name = game.Game.Name,
                Description = game.Game.Description,
                Price = game.Game.Price}).ToListAsync();
        }
    }
}