using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Review;
using api.Dtos.ReviewDTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;
        public ReviewController(IGameRepository gameRepository, IReviewRepository reviewRepository, IUserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewDTO reviewDTO)
        {
            var game = await _gameRepository.GetByIdAsync(reviewDTO.GameId);
            if (game == null)
            {
                return NotFound();
            }
            var review = reviewDTO.toReview();
            await _reviewRepository.CreateAsync(review);
            return Ok(reviewDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByGameId([FromRoute] int id)
        {
            var review = await _reviewRepository.GetByGameIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            var reviewArray = new ToUserReviewDTO[review.Count];
            for (var i = 0; i < review.Count; i++)
            {
                var user = await _userRepository.GetByIdAsync(review[i].UserId);
                reviewArray[i] = review[i].ToUserReviewDTO(user);
            }

            return Ok(reviewArray);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ToUserReviewDTO reviewDTO)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            await _reviewRepository.UpdateAsync(id,review);
            return Ok(review);
        }
    }
}