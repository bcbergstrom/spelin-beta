using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Models;

namespace api.Dtos.User
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        internal static LoginDTO ToLoginDTO(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}