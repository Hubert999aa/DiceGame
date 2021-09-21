namespace DiceGameAPI.Models
{
    public class PointsTable
    {
        public int IdPointsTable { get; set; }

        public int? Aces { get; set; }
        public int? Twos { get; set; }
        public int? Threes { get; set; }
        public int? Fours { get; set; }
        public int? Fives { get; set; }
        public int? Sixes { get; set; }
        public int? Pair { get; set; }
        public int? TwoPairs { get; set; }
        public int? ThreeOfKind { get; set; }
        public int? FourOfKind { get; set; }
        public int? FullHouse { get; set; }
        public int? SmallStraight { get; set; }
        public int? LargeStraight { get; set; }
        public int? General { get; set; }
        public int? Chance { get; set; }

        public PlayerGameHistory PlayerGameHistory { get; set; }
    }
}
