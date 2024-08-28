using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        //General Data
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        //Security
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        //Relationships
        public List<UserGame> UserGames { get; set; } = [];
        public List<Game> Games { get; set; } = [];
        public Review Review { get; set; } = null!; 
    }
}