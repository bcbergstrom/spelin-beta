using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Review;
using api.Models;

namespace api.Mappers
{
    public static class ReviewMapper
    {
        public static Review toReview(this ReviewDTO reviewDTO)
        {
            return new Review
            {
                UserId = reviewDTO.UserId,
                GameId = reviewDTO.GameId,
                Description = reviewDTO.Description,
                Rating = reviewDTO.Rating,
                Date = DateTime.Now
            };
        }
        public static ReviewDTO toReviewDTO(this Review review)
        {
            return new ReviewDTO
            {
                UserId = review.UserId,
                GameId = review.GameId,
                Description = review.Description,
                Rating = review.Rating,
                };
        }
    }
}