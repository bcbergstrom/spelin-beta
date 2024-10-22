using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Dtos.ReviewDTO;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDTO ToUserDTO(this User user)
        {
            return new UserDTO{
                Id = Convert.ToInt32(user.Id),
                Name = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty
        };
        }
        public static User ToUserFromCreateDTO(this CreateUserRequestDTO userDTO)
        {
            return new User
            {
                UserName = userDTO.Name,
                Email = userDTO.Email,
            };
        }
        public static User ToUserFromUpdateDTO(this UpdateUserRequestDTO userDTO)
        {
            return new User
            {
                UserName = userDTO.Name,
                Email = userDTO.Email,
            };
        }

        public static LoginDTO ToLoginDTOFromUserDTO(this UserDTO user){
            return new LoginDTO
            {
                Name = user.Name ?? string.Empty,
                Password = user.Password ?? string.Empty
            };
        }
        public static ToUserReviewDTO ToUserReviewDTO(this Review review, User user)
        {
            return new ToUserReviewDTO
            {
                Username = user.UserName ?? string.Empty,
                Description = review.Description,
                Rating = review.Rating,
            };

        }
    }
}