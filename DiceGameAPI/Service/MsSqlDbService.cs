using System;
using System.Linq;
using DiceGameAPI.Models;
using System.Collections.Generic;

namespace DiceGameAPI.Service
{
    public class MsSqlDbService : IDbService
    {
        private readonly ModelContext _context;
        public MsSqlDbService(ModelContext context)
        {
            this._context = context;
        }

        public int CreateNewPlayer(string name)
        {
            throw new NotImplementedException();
        }
        public int CreateNewGame()
        {
            throw new NotImplementedException();
        }
        public int CreateNewPointsTable(int playerId, int gameId)
        {
            throw new NotImplementedException();
        }
        public void CreatePlayerGameHistory(int playerId, int gameId)
        {
            throw new NotImplementedException();
        }

        public int ChangePlayerName(int playerId)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(int playerId)
        {
            throw new NotImplementedException();
        }
        public Game GetGame(int gameId)
        {
            throw new NotImplementedException();
        }
        public PointsTable GetPointsTable(int pointsTableId)
        {
            throw new NotImplementedException();
        }
        public PlayerGameHistory GetPlayerGameHistory(int playerId, int gameId)
        {
            throw new NotImplementedException();
        }

        public void AddPointsToTable(int pointsTableId, int points, string field)
        {
            throw new NotImplementedException();
        }
        public void ChangePoints(int pointsTableId, int oldValue, int newValue, string field)
        {
            throw new NotImplementedException();
        }
        public int GetAllPoints(int pointsTableId)
        {
            throw new NotImplementedException();
        }
        public int GetSummaryPointsFromSchool(int pointsTableId)
        {
            throw new NotImplementedException();
        }

        public void FinishGame(int gameId)
        {
            throw new NotImplementedException();
        }
        public void SetLooser(int playerId)
        {
            throw new NotImplementedException();
        }
        public void SetWinner(int playerId)
        {
            throw new NotImplementedException();
        }
    }
}
