using System;
using System.Collections.Generic;

namespace DiceGameAPI.Models
{
    public class Game
    {
        public int IdGame { get; set; }
        public DateTime PlayDate { get; set; }
        public bool Finished { get; set; }

        public List<PlayerGameHistory> PlayerGameHistory { get; set; }
    }
}
