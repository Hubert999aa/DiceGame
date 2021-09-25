using System;
using System.Linq;
using DiceGameAPI.Models;
using Microsoft.EntityFrameworkCore;
using DiceGameAPI.Enumerators;

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

        public int ChangePlayerName(int playerId, string newName)
        {
            var player = _context.Players
                                 .Where(p => p.IdPlayer == playerId)
                                 .Single();

            player.Name = newName;

            _context.SaveChanges();

            return player.IdPlayer;
        }

        public Player GetPlayer(int playerId)
        {
            var player = _context.Players
                                 .Where(p => p.IdPlayer == playerId)
                                 .Single();

            return player;
        }
        public Game GetGame(int gameId)
        {
            var game = _context.Games
                               .Where(p => p.IdGame == gameId)
                               .Single();

            return game;
        }
        public PointsTable GetPointsTable(int pointsTableId)
        {
            var pointsTable = _context.PointsTables
                                      .Where(p => p.IdPointsTable == pointsTableId)
                                      .Single();

            return pointsTable;
        }
        public PlayerGameHistory GetPlayerGameHistory(int playerId, int gameId)
        {
            var history = _context.PlayerGameHistories
                                  .Where(p => p.IdGame == gameId)
                                  .Where(p => p.IdPlayer == playerId)
                                  .Single();

            return history;
        }

        public void AddPointsToTable(int pointsTableId, int points, string field)
        {
            var pointsTable = _context.PointsTables
                                      .Where(p => p.IdPointsTable == pointsTableId)
                                      .Single();

            var properties = pointsTable.GetType().GetProperties().ToList();
            foreach(var prop in properties)
            {
                if (prop.Name.Equals(field))
                {
                    prop.SetValue(pointsTable, points);
                    break;
                }
            }

            _context.SaveChanges();
        }
        public void ChangePoints(int pointsTableId, int oldValue, int newValue, string field)
        {
            AddPointsToTable(pointsTableId, newValue, field);
            var pointsTable = _context.PointsTables
                                      .Where(p => p.IdPointsTable == pointsTableId)
                                      .Single();

            var properties = pointsTable.GetType().GetProperties().ToList();
            foreach (var prop in properties)
            {
                if (prop.Name.Equals(field))
                {
                    if ((int)prop.GetValue(pointsTable) == oldValue)
                    {
                        throw new Exception("Change value failied");
                    }
                    break;
                }
            }
        }
        public int GetAllPoints(int pointsTableId)
        {
            var pointsTable = _context.PointsTables
                                      .Where(p => p.IdPointsTable == pointsTableId)
                                      .Single();

            if (!CheckIfSchoolFieldsAreFilled(pointsTable) || !CheckIfSecondPartOfPointsFieldsAreFilled(pointsTable))
            {
                throw new Exception("To sum up all points, first you need to fill all fields with points.");
            }

            var schoolPoints = GetSummaryPointsFromSchool(pointsTableId);
            var secondPartOfPoints = pointsTable.Pair + pointsTable.TwoPairs + pointsTable.ThreeOfKind + pointsTable.FourOfKind
                + pointsTable.FullHouse + pointsTable.General + pointsTable.Chance + pointsTable.SmallStraight + pointsTable.LargeStraight;

            return schoolPoints + (int)secondPartOfPoints;
        }
        public int GetSummaryPointsFromSchool(int pointsTableId)
        {
            var pointsTable = _context.PointsTables.Where(p => p.IdPointsTable == pointsTableId).Single();

            if (CheckIfSchoolFieldsAreFilled(pointsTable))
            {
                throw new Exception("To sum up school points first you need to fill all school fields");
            }

            var schoolPoints = pointsTable.Aces + pointsTable.Twos + pointsTable.Threes + pointsTable.Fours + pointsTable.Fives + pointsTable.Sixes;
            if (schoolPoints >= 0)
            {
                return (int)(50 + schoolPoints);
            }
            else
            {
                return (int)(0 - schoolPoints - 50);
            }
        }

        public void FinishGame(int gameId, int firstPlayerId, int secondPlayerId)
        {
            var firstPlayerGameHistory = _context.PlayerGameHistories
                                                 .Include(p => p.PointsTable)
                                                 .Include(p => p.Game)
                                                 .Where(p => p.IdGame == gameId)
                                                 .Where(p => p.IdPlayer == firstPlayerId)
                                                 .Single();

            var secondPlayerGameHistory = _context.PlayerGameHistories
                                                  .Include(p => p.PointsTable)
                                                  .Include(p => p.Game)
                                                  .Where(p => p.IdGame == gameId)
                                                  .Where(p => p.IdPlayer == secondPlayerId)
                                                  .Single();

            var firstPlayerPoints = GetAllPoints(firstPlayerGameHistory.IdPointsTable);
            var secondPlayerPoints = GetAllPoints(firstPlayerGameHistory.IdPointsTable);

            if (firstPlayerPoints == secondPlayerPoints)
            {
                firstPlayerGameHistory.GameResult = GameResult.Draw;
                secondPlayerGameHistory.GameResult = GameResult.Draw;
            }
            else
            {
                if (firstPlayerPoints > secondPlayerPoints)
                {
                    firstPlayerGameHistory.GameResult = GameResult.Won;
                    secondPlayerGameHistory.GameResult = GameResult.Lost;
                }
                else
                {
                    firstPlayerGameHistory.GameResult = GameResult.Lost;
                    secondPlayerGameHistory.GameResult = GameResult.Won;
                }
            }

            firstPlayerGameHistory.Game.Finished = true;

            _context.SaveChanges();
        }

        private bool CheckIfSchoolFieldsAreFilled(PointsTable pointsTable)
        {
            if (pointsTable.Aces == null || pointsTable.Twos == null || pointsTable.Threes == null || pointsTable.Fours == null || pointsTable.Fives == null || pointsTable.Sixes == null)
            {
                return false;
            }
            return true;
        }
        private bool CheckIfSecondPartOfPointsFieldsAreFilled(PointsTable pointsTable)
        {
            if (pointsTable.Pair == null || pointsTable.TwoPairs == null || pointsTable.ThreeOfKind == null || pointsTable.FourOfKind == null || pointsTable.FullHouse == null
                || pointsTable.SmallStraight == null || pointsTable.LargeStraight == null || pointsTable.General == null || pointsTable.Chance == null)
            {
                return false;
            }
            return true;
        }
    }
}
