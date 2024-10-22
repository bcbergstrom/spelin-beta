using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.UserGame
{
    public class UserGameDTO
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }

    }
}