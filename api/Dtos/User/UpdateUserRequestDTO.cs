using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;

namespace api.Dtos.User
{
    public class UpdateUserRequestDTO
    {
        public string Name { get; set; }  = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public List<GameDTO>? Games { get; set; }
    }
}