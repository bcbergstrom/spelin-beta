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
    public class ReviewRepository: IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Review> CreateAsync(Review review)
        {
            Console.WriteLine("hitting Post");
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;

        }


        public async Task<List<Review>> GetByGameIdAsync(int gameId)
        {
            return await _context.Reviews.Where(x => x.GameId == gameId).ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Review?> UpdateAsync(int id, Review review)
        {
            var reviewToUptdate = _context.Reviews.FirstOrDefault(x => x.Id == id);
            if (reviewToUptdate == null)
            {
                return null;
            }
            reviewToUptdate.Rating = review.Rating;
            reviewToUptdate.Description = review.Description;
            reviewToUptdate.Date = DateTime.Now;

            _context.Reviews.Update(reviewToUptdate);
            await _context.SaveChangesAsync();
            return review;
        }
    }
}