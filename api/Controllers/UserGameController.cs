using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Dtos.UserGame;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager; 
        private readonly SignInManager<User> _signInManager;
        public UserGameController( IUserRepository userRepo, IGameRepository gameRepo, IUserGameRepository userGameRepo, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userRepo = userRepo;
            _gameRepo = gameRepo;
            _userGameRepo = userGameRepo;
            _userManager = userManager;
            _signInManager = signInManager;
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

        [HttpGet]
        
        public async Task<IActionResult> GetOneUsersManyGames()
        {
            //Setup user Auth;
            try
            {
                var currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
                var userGames = await _userGameRepo.GetUserGames(currentUser);
                return Ok(userGames);
            }
            catch
            {
                return BadRequest(error: "User not found");
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] UserGameDTO userGame)
        {
            var user = await _userRepo.GetByIdAsync(userGame.UserId);
            var games = await _gameRepo.GetByIdAsync(userGame.GameId);

            if (user == null || games == null)
            {
                return NotFound();
            }
            var UserGameIsFilled = await _userGameRepo.GetUserGames(user);
            if(UserGameIsFilled.Any(e => e.Id == games.Id))
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