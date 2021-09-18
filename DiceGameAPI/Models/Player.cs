using System.Collections.Generic;

namespace DiceGameAPI.Models
{
    public class Player
    {
        public int IdPlayer { get; set; }
        public string Name { get; set; }

        public List<PlayerGameHistory> GamesHistory { get; set; }
    }
}
