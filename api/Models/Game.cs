using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Game
    {
        //General Data
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string ImageLink { get; set; } = string.Empty;
        public decimal Price { get; set; }

        //Relationships
        public List<UserGame> UserGames { get; set; } = [];
        public List<User> User { get; set; } = [];
        public List<GameGenre> GameGenres { get; set; } = [];
        public List <Genre> Genres { get; set; } = [];
        public List<GameReview> GameReviews { get; set; } = [];
        public List<Review> Reviews { get; set; } = [];
        

    }
}