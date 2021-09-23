﻿// <auto-generated />
using System;
using DiceGameAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiceGameAPI.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20210923192818_ChangeWonPropOnGameResult")]
    partial class ChangeWonPropOnGameResult
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiceGameAPI.Models.Game", b =>
                {
                    b.Property<int>("IdGame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PlayDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdGame");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DiceGameAPI.Models.Player", b =>
                {
                    b.Property<int>("IdPlayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdPlayer");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DiceGameAPI.Models.PlayerGameHistory", b =>
                {
                    b.Property<int>("IdPlayer")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int>("GameResult")
                        .HasColumnType("int");

                    b.Property<int>("IdPointsTable")
                        .HasColumnType("int");

                    b.HasKey("IdPlayer", "IdGame");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdPointsTable")
                        .IsUnique();

                    b.ToTable("PlayerGameHistories");
                });

            modelBuilder.Entity("DiceGameAPI.Models.PointsTable", b =>
                {
                    b.Property<int>("IdPointsTable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Aces")
                        .HasColumnType("int");

                    b.Property<int?>("Chance")
                        .HasColumnType("int");

                    b.Property<int?>("Fives")
                        .HasColumnType("int");

                    b.Property<int?>("FourOfKind")
                        .HasColumnType("int");

                    b.Property<int?>("Fours")
                        .HasColumnType("int");

                    b.Property<int?>("FullHouse")
                        .HasColumnType("int");

                    b.Property<int?>("General")
                        .HasColumnType("int");

                    b.Property<int?>("LargeStraight")
                        .HasColumnType("int");

                    b.Property<int?>("Pair")
                        .HasColumnType("int");

                    b.Property<int?>("Sixes")
                        .HasColumnType("int");

                    b.Property<int?>("SmallStraight")
                        .HasColumnType("int");

                    b.Property<int?>("ThreeOfKind")
                        .HasColumnType("int");

                    b.Property<int?>("Threes")
                        .HasColumnType("int");

                    b.Property<int?>("TwoPairs")
                        .HasColumnType("int");

                    b.Property<int?>("Twos")
                        .HasColumnType("int");

                    b.HasKey("IdPointsTable");

                    b.ToTable("PointsTables");
                });

            modelBuilder.Entity("DiceGameAPI.Models.PlayerGameHistory", b =>
                {
                    b.HasOne("DiceGameAPI.Models.Game", "Game")
                        .WithMany("PlayerGameHistory")
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiceGameAPI.Models.Player", "Player")
                        .WithMany("GamesHistory")
                        .HasForeignKey("IdPlayer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiceGameAPI.Models.PointsTable", "PointsTable")
                        .WithOne("PlayerGameHistory")
                        .HasForeignKey("DiceGameAPI.Models.PlayerGameHistory", "IdPointsTable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");

                    b.Navigation("PointsTable");
                });

            modelBuilder.Entity("DiceGameAPI.Models.Game", b =>
                {
                    b.Navigation("PlayerGameHistory");
                });

            modelBuilder.Entity("DiceGameAPI.Models.Player", b =>
                {
                    b.Navigation("GamesHistory");
                });

            modelBuilder.Entity("DiceGameAPI.Models.PointsTable", b =>
                {
                    b.Navigation("PlayerGameHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
