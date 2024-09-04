using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Azure;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGameRepository _gameRepo;
        private readonly IUserRepository _userRepo;

        private readonly UserManager<User> _userManager; 
        private readonly SignInManager<User> _signInManager;
        public UserController(IUserRepository userRepo, IGameRepository gameRepo, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userRepo = userRepo;
            _gameRepo = gameRepo;
            _userManager = userManager;
            _signInManager = signInManager;

        } 
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllAsync();

            var usersDTO = users.Select(s => s.ToUserDTO());

            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDTO());
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Create([FromBody] LoginDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = new User {UserName = userDTO.Name, Email = userDTO.Email};
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO userDTO)
        {
        var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);        

        if (result.Succeeded)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
        

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _userRepo.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }


}