using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Identity;
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
        public UserController(IUserRepository userRepo, IGameRepository gameRepo)
        {
            _userRepo = userRepo;
            _gameRepo = gameRepo;
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
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDTO userDTO)
        {
            var userModel = userDTO.ToUserFromCreateDTO();
            await _userRepo.CreateAsync(userModel);
            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDTO());
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var user = await _userRepo.LoginAsync(userDTO.ToLoginDTOFromUserDTO());
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDTO());
        }
        

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDTO userDTO)
        {
            var user = await _userRepo.UpdateAsync(id, userDTO);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDTO());
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