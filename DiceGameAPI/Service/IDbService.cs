using DiceGameAPI.Models;
using System.Collections.Generic;

namespace DiceGameAPI.Service
{
    public interface IDbService
    {
        public int CreateNewPlayer(string name);
        public int CreateNewGame();
        public int CreateNewPointsTable(int playerId, int gameId);
        public void CreatePlayerGameHistory(int playerId, int gameId);

        public int ChangePlayerName(int playerId, string newName);

        public Player GetPlayer(int playerId);
        public Game GetGame(int gameId);
        public PointsTable GetPointsTable(int pointsTableId);
        public PlayerGameHistory GetPlayerGameHistory(int playerId, int gameId);

        public List<Player> GetAllPlayers();
        public List<PlayerGameHistory> GetAllPlayerHistory(int playerId);

        public int GetSummaryPointsFromSchool(int pointsTableId);
        public int GetAllPoints(int pointsTableId);
        public void AddPointsToTable(int pointsTableId, int points, string field);
        public void ChangePoints(int pointsTableId, int oldValue, int newValue, string field);

        public void FinishGame(int gameId, int firstPlayerId, int secondPlayerId);
    }
}