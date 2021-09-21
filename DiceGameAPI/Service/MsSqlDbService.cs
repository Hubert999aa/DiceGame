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
            Player newPlayer = new Player
            {
                Name = name
            };

            _context.Players.Add(newPlayer);
            _context.SaveChanges();

            return newPlayer.IdPlayer;
        }
        public int CreateNewGame()
        {
            Game newGame = new Game
            {
                PlayDate = DateTime.Now,
                Finished = false
            };

            _context.Games.Add(newGame);
            _context.SaveChanges();

            return newGame.IdGame;
        }
        public int CreateNewPointsTable(int playerId, int gameId)
        {
            PointsTable newPointsTable = new PointsTable();

            _context.PointsTables.Add(newPointsTable);
            _context.SaveChanges();

            return newPointsTable.IdPointsTable;
        }
        public void CreatePlayerGameHistory(int playerId, int gameId)
        {
            PlayerGameHistory newGameHistory = new PlayerGameHistory
            {
                IdGame = gameId,
                IdPlayer = playerId
            };

            _context.PlayerGameHistories.Add(newGameHistory);
            _context.SaveChanges();
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
