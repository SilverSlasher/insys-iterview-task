using MovieLibrary.Core.Dtos.Movies;
using MovieLibrary.Data.Dtos.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services.Movies
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();

        Task<IEnumerable<MovieCategoryDto>> GetFilteredMoviesAsync(MovieFiltersDto movieFilers);

        Task<MovieDto> GetMovieByIdAsync(int id);

        Task<int> AddMovieAsync(CreateMovieDto movie);

        Task<int> UpdateMovieAsync(MovieDto movie);

        Task<int> DeleteMovieAsync(int id);
    }
}