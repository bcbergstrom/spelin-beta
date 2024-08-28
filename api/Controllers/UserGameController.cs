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
        public async Task<IActionResult> GetUserGames([FromRoute] int id)
        {
            //Setup user Auth;
            var appUser = await _userRepo.GetByIdAsync(id);
            var userGames = await _userGameRepo.GetUserGames(appUser);
            return Ok(userGames);
        }
    }
}