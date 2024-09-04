using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser<int>
    {
        
        //Relationships
        public List<UserGame> UserGames { get; set; } = [];
        public List<Game> Games { get; set; } = [];
        public Review Review { get; set; } = null!; 
    }
}