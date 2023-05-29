using MovieLibrary.Core.Dtos.Movies;
using MovieLibrary.Core.Extensions;
using MovieLibrary.Core.Mappers;
using MovieLibrary.Data.Dtos.Movies;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync() => (await _movieRepository.GetAllMoviesAsync()).Select(x => x.ToMovieDto());

        public async Task<IEnumerable<MovieCategoryDto>> GetFilteredMoviesAsync(MovieFiltersDto movieFilers)
        {
            Expression<Func<Movie, bool>> expression = x =>
                (string.IsNullOrEmpty(movieFilers.Text) || x.Title.ToLower().Contains(movieFilers.Text.ToLower())) &&
                (movieFilers.MinImdb == null || x.ImdbRating >= movieFilers.MinImdb) &&
                (movieFilers.MaxImdb == null || x.ImdbRating <= movieFilers.MaxImdb) &&
                (movieFilers.CategoryIds.IsNullOrEmpty() || x.MovieCategories.Any(y => movieFilers.CategoryIds.Any(z => z == y.CategoryId)));

            return (await _movieRepository.GetFilteredMoviesAsync(expression, movieFilers.Page, movieFilers.PageSize)).Select(x => x.ToMovieWithCategoriesDto());
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id) => (await _movieRepository.GetMovieByIdAsync(id)).ToMovieDto();

        public async Task<int> AddMovieAsync(CreateMovieDto movie) => await _movieRepository.AddMovieAsync(movie.ToMovie());

        public async Task<int> UpdateMovieAsync(MovieDto movie) => await _movieRepository.UpdateMovieAsync(movie.ToMovie());

        public async Task<int> DeleteMovieAsync(int id) => await _movieRepository.DeleteMovieAsync(id);
    }
}