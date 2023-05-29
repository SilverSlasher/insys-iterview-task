using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Data.Common;

namespace MovieLibrary.IntegrationTests.Base
{
    public class TestMovieLibraryContext : MovieLibraryContext
    {
        public TestMovieLibraryContext(DbContextOptions<MovieLibraryContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(CreateInMemoryDatabase());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private DbConnection CreateInMemoryDatabase()
        {
            SqliteConnection connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }

        private void SeedData(ModelBuilder builder)
        {
            var movies = new List<Movie>()
            {
                new Movie { Id = 1, Title = "Harry Potter and the Sorcerer's Stone", Description = "PlaceHolder", ImdbRating = 7.6m, Year = 2001 },
                new Movie { Id = 2, Title = "Harry Potter and the Chamber of Secrets", Description = "PlaceHolder", ImdbRating = 6.8m, Year = 2002 },
                new Movie { Id = 3, Title = "Forrest Gump", Description = "PlaceHolder", ImdbRating = 8.9m, Year = 1994 },
                new Movie { Id = 4, Title = "Interstellar", Description = "PlaceHolder", ImdbRating = 8.6m, Year = 2014 },
                new Movie { Id = 5, Title = "The Shawshank Redemption", Description = "PlaceHolder", ImdbRating = 9.3m, Year = 1994 },
                new Movie { Id = 6, Title = "Inception", Description = "PlaceHolder", ImdbRating = 8.8m, Year = 2010 },
                new Movie { Id = 7, Title = "The Matrix", Description = "PlaceHolder", ImdbRating = 8.7m, Year = 1999 },
                new Movie { Id = 8, Title = "La vita è bella", Description = "PlaceHolder", ImdbRating = 8.6m, Year = 1997 },
                new Movie { Id = 9, Title = "Whiplash", Description = "PlaceHolder", ImdbRating = 7.5m, Year = 2014 },
                new Movie { Id = 10, Title = "Intouchables", Description = "PlaceHolder", ImdbRating = 8.5m, Year = 2011 },
                new Movie { Id = 11, Title = "The Prestige", Description = "PlaceHolder", ImdbRating = 8.2m, Year = 2006 },
                new Movie { Id = 12, Title = "Joker", Description = "PlaceHolder", ImdbRating = 8.4m, Year = 2019 }
            };

            var categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Action" },
                new Category { Id = 2, Name = "Adventure" },
                new Category { Id = 3, Name = "Comedy" },
                new Category { Id = 4, Name = "Crime" },
                new Category { Id = 5, Name = "Drama" },
                new Category { Id = 6, Name = "Family" },
                new Category { Id = 7, Name = "Fantasy" },
                new Category { Id = 8, Name = "Romance" },
                new Category { Id = 9, Name = "Sci-Fi" },
                new Category { Id = 10, Name = "Thriller" },
                new Category { Id = 11, Name = "Horror" },
            };

            builder.Entity<Movie>().HasData(movies);
            builder.Entity<Category>().HasData(categories);
            var movieCategories = GetMovieCategories();
            builder.Entity<MovieCategory>().HasData(movieCategories);
        }

        //Movie 1 will have first category, Movie 2 will have first 2 etc
        private List<MovieCategory> GetMovieCategories()
        {
            var movieCategoriesSchema = new List<(int movieId, int[] categories)>()
            {
                (1, new[] {2, 6, 7}),
                (2, new[] {2, 6, 7}),
                (3, new[] {5, 8}),
                (4, new[] {2, 5, 9}),
                (5, new[] {5}),
                (6, new[] {1, 2, 9, 10}),
                (7, new[] {1, 9}),
                (8, new[] {3, 5, 8}),
                (9, new[] {5}),
                (10, new[] {3, 5}),
                (11, new[] {5, 9, 10}),
                (12, new[] {4, 5, 10})
            };

            List<MovieCategory> movieCategories = new List<MovieCategory>();
            int id = 1;

            foreach (var schema in movieCategoriesSchema)
            {
                foreach (var category in schema.categories)
                {
                    movieCategories.Add(new MovieCategory()
                    {
                        Id = id,
                        CategoryId = category,
                        MovieId = schema.movieId
                    });

                    id++;
                }
            }

            return movieCategories;
        }
    }
}