using Microsoft.EntityFrameworkCore;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.DataAccess.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Description = "Dream infiltration thriller",
                    Genre = "Sci-Fi",
                    ReleaseYear = 2010,
                    PosterUrl = "https://image.tmdb.org/t/p/w500/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"
                },
                new Movie
                {
                    Id = 2,
                    Title = "Interstellar",
                    Description = "Journey beyond the stars",
                    Genre = "Sci-Fi",
                    ReleaseYear = 2014,
                    PosterUrl = "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg"
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Dark Knight",
                    Description = "Batman vs Joker",
                    Genre = "Action",
                    ReleaseYear = 2008,
                    PosterUrl = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg"
                }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = 1,
                    MovieId = 1,
                    RatingStars = 5
                },
                new Rating
                {
                    Id = 2,
                    MovieId = 1,
                    RatingStars = 4
                },
                new Rating
                {
                    Id = 3,
                    MovieId = 2,
                    RatingStars = 5
                },
                new Rating
                {
                    Id = 4,
                    MovieId = 3,
                    RatingStars = 4
                },
                new Rating
                {
                    Id = 5,
                    MovieId = 3,
                    RatingStars = 5
                }
            );

        }
    }
}
