using DiceGameAPI.Models;

namespace DiceGameAPI.Service
{
    public interface IDbService
    {
        public int CreateNewPlayer(string name);
        public int CreateNewGame();
        public int CreateNewPointsTable(int playerId, int gameId);
        public void CreatePlayerGameHistory(int playerId, int gameId);

        public int ChangePlayerName(int playerId);

        public Player GetPlayer(int playerId);
        public Game GetGame(int gameId);
        public PointsTable GetPointsTable(int pointsTableId);
        public PlayerGameHistory GetPlayerGameHistory(int playerId, int gameId);

        public int GetSummaryPointsFromSchool(int pointsTableId);
        public int GetAllPoints(int pointsTableId);
        public void AddPointsToTable(int pointsTableId, int points, string field);
        public void ChangePoints(int pointsTableId, int oldValue, int newValue, string field);

        public void FinishGame(int gameId);
        public void SetWinner(int playerId);
        public void SetLooser(int playerId);
    }
}