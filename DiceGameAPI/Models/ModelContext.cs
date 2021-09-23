using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiceGameAPI.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PointsTable> PointsTables { get; set; }
        public DbSet<PlayerGameHistory> PlayerGameHistories { get; set; }

        public ModelContext() { }
        public ModelContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.Property(p => p.IdPlayer).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(20)
                   .IsRequired();
            });

            modelBuilder.Entity<Game>(opt =>
            {
                opt.HasKey(p => p.IdGame);
                opt.Property(p => p.IdGame).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PointsTable>(opt =>
            {
                opt.HasKey(p => p.IdPointsTable);
                opt.Property(p => p.IdPointsTable).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PlayerGameHistory>(opt =>
            {
                opt.HasKey(p => new { p.IdPlayer, p.IdGame});

                opt.HasOne(p => p.Player)
                   .WithMany(p => p.GamesHistory)
                   .HasForeignKey(p => p.IdPlayer);

                opt.HasOne(p => p.Game)
                   .WithMany(p => p.PlayerGameHistory)
                   .HasForeignKey(p => p.IdGame);

                opt.Property(p => p.GameResult)
                   .HasConversion<int>();

                opt.HasOne(p => p.PointsTable)
                   .WithOne(p => p.PlayerGameHistory)
                   .HasForeignKey<PlayerGameHistory>(p => p.IdPointsTable);
            });
        }
    }
}
