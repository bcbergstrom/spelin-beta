using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Review
{
    public class ReviewDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Description { get; set; }

    }
}