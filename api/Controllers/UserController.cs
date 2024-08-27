using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList()
            .Select(s => s.ToUserDTO());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDTO());
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateUserRequestDTO userDTO)
        {
            var userModel = userDTO.ToUserFromCreateDTO();
            _context.Users.Add(userModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDTO());
        }
    }
}