using Moq;
using MovieLibrary.Core.Dtos.Movies;
using MovieLibrary.Core.Services.Movies;
using MovieLibrary.Data.Dtos.Movies;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories.Movies;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MovieLibrary.UnitTests.ServiceTests
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _movieRepositoryMock;
        private readonly MovieService _movieService;

        public MovieServiceTests()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _movieService = new MovieService(_movieRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllMoviesAsync_ShouldReturnAllMovies()
        {
            // Arrange
            var moviesFromRepository = new List<Movie>
        {
            new Movie { Id = 1, Title = "Movie 1" },
            new Movie { Id = 2, Title = "Movie 2" }
        };
            _movieRepositoryMock.Setup(repo => repo.GetAllMoviesAsync()).ReturnsAsync(moviesFromRepository);

            // Act
            var result = await _movieService.GetAllMoviesAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, m => m.Title == "Movie 1");
            Assert.Contains(result, m => m.Title == "Movie 2");
        }

        [Fact]
        public async Task GetMovieByIdAsync_ExistingId_ShouldReturnMovie()
        {
            // Arrange
            int movieId = 1;
            var movieFromRepository = new Movie { Id = movieId, Title = "Movie 1" };
            _movieRepositoryMock.Setup(repo => repo.GetMovieByIdAsync(movieId)).ReturnsAsync(movieFromRepository);

            // Act
            var result = await _movieService.GetMovieByIdAsync(movieId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(movieId, result.Id);
            Assert.Equal("Movie 1", result.Title);
        }

        [Fact]
        public async Task AddMovieAsync_ShouldReturnAddedMovieId()
        {
            // Arrange
            var movieToCreate = new CreateMovieDto { Title = "New Movie" };
            int addedMovieId = 1;
            _movieRepositoryMock.Setup(repo => repo.AddMovieAsync(It.IsAny<Movie>())).ReturnsAsync(addedMovieId);

            // Act
            var result = await _movieService.AddMovieAsync(movieToCreate);

            // Assert
            Assert.Equal(addedMovieId, result);
        }

        [Fact]
        public async Task UpdateMovieAsync_ShouldReturnUpdatedMovieId()
        {
            // Arrange
            var movieToUpdate = new MovieDto { Id = 1, Title = "Updated Movie" };
            int updatedMovieId = 1;
            _movieRepositoryMock.Setup(repo => repo.UpdateMovieAsync(It.IsAny<Movie>())).ReturnsAsync(updatedMovieId);

            // Act
            var result = await _movieService.UpdateMovieAsync(movieToUpdate);

            // Assert
            Assert.Equal(updatedMovieId, result);
        }

        [Fact]
        public async Task DeleteMovieAsync_ShouldReturnDeletedMovieId()
        {
            // Arrange
            int movieId = 1;
            int deletedMovieId = 1;
            _movieRepositoryMock.Setup(repo => repo.DeleteMovieAsync(movieId)).ReturnsAsync(deletedMovieId);

            // Act
            var result = await _movieService.DeleteMovieAsync(movieId);

            // Assert
            Assert.Equal(deletedMovieId, result);
        }
    }
}