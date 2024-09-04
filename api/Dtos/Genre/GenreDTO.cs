using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Genre
{
    public class GenreDTO
    {        
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}