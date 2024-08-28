using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;

namespace api.Dtos.Game
{
    public class UpdateGameRequestDTO
    {
        public string Name { get; set; }  = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}