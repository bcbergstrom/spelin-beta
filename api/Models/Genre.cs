using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace api.Models
{
    public class Genre
    {
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<GameGenre> GameGenres { get; set; } = [];
        public List<Game> Games { get; set; } = [];
    }
}