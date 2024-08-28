using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class GameReview
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}