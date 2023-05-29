using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories.Movies
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly MovieLibraryContext _context;

        public MovieRepository(MovieLibraryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync() => await GetAllEntitiesAsync();

        public async Task<Movie> GetMovieByIdAsync(int id) => await GetEntityByIdAsync(id);

        public async Task<int> AddMovieAsync(Movie movie) => await AddEntityAsync(movie);

        public async Task<int> UpdateMovieAsync(Movie movie) => await UpdateEntityAsync(movie);

        public async Task<int> DeleteMovieAsync(int id) => await DeleteEntityAsync(id);

        public async Task<IEnumerable<Movie>> GetFilteredMoviesAsync(Expression<Func<Movie, bool>> queryFilter, int page, int pageSize)
        {
            var offset = (page - 1) * pageSize;
            return await _context.Movies.AsNoTracking()
                .Include(x => x.MovieCategories)
                .ThenInclude(x => x.Category)
                .Where(queryFilter)
                .OrderByDescending(x => x.ImdbRating)
                .Skip(offset)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}