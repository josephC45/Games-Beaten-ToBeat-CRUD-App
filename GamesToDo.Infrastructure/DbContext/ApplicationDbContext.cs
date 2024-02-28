using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Game> Games { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().ToTable("Games");

            //Seed Game Table with Mock game data
            string mockGameJson = System.IO.File.ReadAllText("MockGameData.json");
            List<Game> games = System.Text.Json.JsonSerializer.Deserialize<List<Game>>(mockGameJson)!;
            foreach(Game game in games)
            {
                modelBuilder.Entity<Game>().HasData(game);
            }
            
        }

    }
}
