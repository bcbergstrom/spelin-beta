using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGame>()
            .HasKey(x => new {x.UserId, x.GameId});

            modelBuilder.Entity<UserGame>()
            .HasOne(x => x.User)
            .WithMany(y => y.UserGames)
            .HasForeignKey(z => z.UserId);

            modelBuilder.Entity<UserGame>()
            .HasOne(x => x.Game)
            .WithMany(y => y.UserGames)
            .HasForeignKey(z => z.GameId);
        }
    }
}