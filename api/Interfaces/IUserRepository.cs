using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Dtos.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User?> UpdateAsync(int id, UpdateUserRequestDTO user);
        Task<User?> DeleteAsync(int id);
        Task<bool> UserExists(int id);
        Task<User?> LoginAsync(LoginDTO login);
        }
}