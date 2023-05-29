using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Services.Movies;
using MovieLibrary.Data;
using MovieLibrary.Data.Dtos.Movies;
using MovieLibrary.Data.Repositories.Movies;
using MovieLibrary.IntegrationTests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MovieLibrary.IntegrationTests.ServiceTests
{
    public class MovieServiceTests
    {
        private readonly MovieRepository _movieRepository;
        private readonly MovieService _movieService;

        public MovieServiceTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<MovieLibraryContext>().Options;
            var dbContext = new TestMovieLibraryContext(dbContextOptions);
            _movieRepository = new MovieRepository(dbContext);
            _movieService = new MovieService(_movieRepository);
        }

        [Fact]
        public async Task GetFilteredMoviesAsync_WithNoFilters_ReturnsAllMovies()
        {
            // Arrange
            var movieFilters = new MovieFiltersDto();

            // Act
            var result = await _movieService.GetFilteredMoviesAsync(movieFilters);

            // Assert
            Assert.Equal(movieFilters.PageSize, result.Count());
            Assert.Equal(result.Select(x => x.ImdbRating), result.Select(x => x.ImdbRating).OrderByDescending(x => x));
        }

        [Fact]
        public async Task GetFilteredMoviesAsync_WithTextFilter_ReturnsMatchingMovies()
        {
            // Arrange
            var movieFilters = new MovieFiltersDto
            {
                Text = "harry"
            };

            // Act
            var result = await _movieService.GetFilteredMoviesAsync(movieFilters);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.True(result.All(x => x.Title.Contains(movieFilters.Text, StringComparison.OrdinalIgnoreCase)));
        }

        [Fact]
        public async Task GetFilteredMoviesAsync_WithImdbMax_ReturnsMatchingMovies()
        {
            // Arrange
            var movieFilters = new MovieFiltersDto
            {
                MaxImdb = 8
            };

            // Act
            var result = await _movieService.GetFilteredMoviesAsync(movieFilters);

            // Assert
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetFilteredMoviesAsync_WithCategories_ReturnsMatchingMovies()
        {
            // Arrange
            var movieFilters = new MovieFiltersDto
            {
                CategoryIds = new List<int>() { 3, 11 }
            };

            // Act
            var result = await _movieService.GetFilteredMoviesAsync(movieFilters);

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}