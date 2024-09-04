using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    

    [Route("api/usergame")]
    [ApiController]
    [Authorize]
    public class UserGameController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IGameRepository _gameRepo;
        private readonly IUserGameRepository _userGameRepo;
        public UserGameController( IUserRepository userRepo, IGameRepository gameRepo, IUserGameRepository userGameRepo)
        {
            _userRepo = userRepo;
            _gameRepo = gameRepo;
            _userGameRepo = userGameRepo;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserByGame([FromRoute] int id)
        {
            //Setup user Auth;
            var appUser = await _userRepo.GetByIdAsync(id);
            var userGames = await _userGameRepo.GetUserGames(appUser);
            return Ok(userGames);
        }
    
        [HttpPost("{gameId}")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] int userId, int gameId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            var games = await _gameRepo.GetByIdAsync(gameId);

            if (user == null || games == null)
            {
                return NotFound();
            }
            var UserGameIsFilled = await _userGameRepo.GetUserGames(user);
            if(UserGameIsFilled.Any(e => e.Id == gameId))
            {
                return BadRequest("Cannot add same game twice");
            }

            var usergameModel = new UserGame
            {
                UserId =  Convert.ToInt32(user.Id),
                GameId = games.Id
            };
            await _userGameRepo.CreateAsync(usergameModel);
            if (usergameModel == null)
            {
                return StatusCode(500, "Couldn't create UserGame");
            }else {
                return Created();
            }
        }
    }
}