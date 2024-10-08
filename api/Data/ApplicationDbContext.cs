using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<GameReview> GameReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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

            modelBuilder.Entity<User>()
            .HasOne(e => e.Review)
            .WithOne(e => e.User)
            .HasForeignKey<Review>(e => e.UserId);     

            modelBuilder.Entity<GameGenre>()
            .HasKey(x => new {x.GameId, x.GenreId});

            modelBuilder.Entity<GameGenre>()
            .HasOne(x => x.Game)
            .WithMany(y => y.GameGenres)
            .HasForeignKey(z => z.GameId);

            modelBuilder.Entity<GameGenre>()
            .HasOne(x => x.Genre)
            .WithMany(y => y.GameGenres)
            .HasForeignKey(z => z.GenreId);

            modelBuilder.Entity<GameReview>()
            .HasKey(x => new {x.GameId, x.ReviewId});

            modelBuilder.Entity<GameReview>()
            .HasOne(x => x.Game)
            .WithMany(y => y.GameReviews)
            .HasForeignKey(z => z.GameId);

            modelBuilder.Entity<GameReview>()
            .HasOne(x => x.Review)
            .WithMany(y => y.GameReviews)
            .HasForeignKey(z => z.ReviewId);
            }
    }
}