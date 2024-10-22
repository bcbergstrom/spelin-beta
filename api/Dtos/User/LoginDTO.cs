using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class LoginDTO
    {
        public string Name { get; set; }  = string.Empty;


        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

    }}