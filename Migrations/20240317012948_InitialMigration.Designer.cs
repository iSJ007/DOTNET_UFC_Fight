﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UFCFantasyFight.Data;

#nullable disable

namespace UFCFantasyFight.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240317012948_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UFCFantasyFight.Models.Fighter", b =>
                {
                    b.Property<int>("FighterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FighterId"));

                    b.Property<string>("FighterClass")
                        .IsRequired()
                        .HasColumnType("varchar(17)");

                    b.Property<string>("FighterCountry")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("FighterDob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FighterHeight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FighterLoc")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("FighterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FighterNick")
                        .IsRequired()
                        .HasColumnType("varchar(33)");

                    b.Property<string>("FighterReach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("FighterSlpm")
                        .HasColumnType("decimal(4,2)");

                    b.Property<string>("FighterStance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("FighterStracc")
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal?>("FighterStrdef")
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal?>("FighterSubavg")
                        .HasColumnType("decimal(3,1)");

                    b.Property<decimal?>("FighterTdacc")
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal?>("FighterTdavg")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal?>("FighterTddef")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("FighterWeight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OldFighterId")
                        .HasColumnType("int");

                    b.HasKey("FighterId");

                    b.ToTable("Fighter");
                });

            modelBuilder.Entity("UFCFantasyFight.Models.Ranking", b =>
                {
                    b.Property<int>("RankingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RankingId"));

                    b.Property<int>("FighterId")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OldRankingId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("RankingId");

                    b.HasIndex("FighterId");

                    b.ToTable("Ranking");
                });

            modelBuilder.Entity("UFCFantasyFight.Models.Ranking", b =>
                {
                    b.HasOne("UFCFantasyFight.Models.Fighter", "Fighter")
                        .WithMany()
                        .HasForeignKey("FighterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fighter");
                });
#pragma warning restore 612, 618
        }
    }
}
