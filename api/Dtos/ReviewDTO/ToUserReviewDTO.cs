using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ReviewDTO
{
    public class ToUserReviewDTO
    {
        
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }

    }
}