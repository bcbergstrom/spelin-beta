using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> CreateAsync(Review review);
        Task<List<Review>> GetByGameIdAsync(int gameId);
        Task<Review?> GetByIdAsync(int id);
        Task<Review?> UpdateAsync(int id, Review review);
    }
}