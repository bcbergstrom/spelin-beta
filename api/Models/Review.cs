using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int Rating { get; set; }

        public User User { get; set; } = null!;
        public List<Game> Games { get; set; } = []!;
        public List<GameReview> GameReviews { get; set; } = [];

    }
}