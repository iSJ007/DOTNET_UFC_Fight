using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UFCFantasyFight.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace UFCFantasyFight.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Fighter> Fighter { get; set; }
        public DbSet<Ranking> Ranking { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {

        // }
    }
}