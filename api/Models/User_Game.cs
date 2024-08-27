using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

using api.Models;

namespace api.Models
{
    public class User_Game
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }

        public User? User { get; set; }
        public Game? Game { get; set; }
        public enum GameState { NotStarted = 0, InProgress = 1, Completed = 2 }
        public GameState? gameState { get; set; }
    }
}