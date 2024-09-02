using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Game;
using api.Dtos.User;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.Games).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<User?> LoginAsync(LoginDTO login)
        {
            return _context.Users.FirstOrDefaultAsync<User>(x => x.Email == login.Email && x.Password == login.Password);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDTO user)
        {
            var userToUpdate = _context.Users.Include(x => x.Games).FirstOrDefault(x => x.Id == id);
            if (userToUpdate == null)
            {
                return null;
            }
            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
            
            await _context.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(x => x.Id == id);
        }
    }


}
