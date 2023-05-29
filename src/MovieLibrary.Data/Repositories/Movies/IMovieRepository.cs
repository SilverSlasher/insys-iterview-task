using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories.Movies
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<IEnumerable<Movie>> GetFilteredMoviesAsync(Expression<Func<Movie, bool>> queryFilter, int page, int pageSize);

        Task<Movie> GetMovieByIdAsync(int id);

        Task<int> AddMovieAsync(Movie movie);

        Task<int> UpdateMovieAsync(Movie movie);

        Task<int> DeleteMovieAsync(int id);
    }
}