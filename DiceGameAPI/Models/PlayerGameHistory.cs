namespace DiceGameAPI.Models
{
    public class PlayerGameHistory
    {
        public int IdPlayer { get; set; }
        public int IdGamme { get; set; }
        public int IdPointsTable { get; set; }
        public bool Won { get; set; }

        public PointsTable PointsTable { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
    }
}
