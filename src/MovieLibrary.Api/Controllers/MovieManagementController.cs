using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Dtos.Movies;
using MovieLibrary.Core.Services.Movies;
using MovieLibrary.Data.Dtos.Movies;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers
{
    [ApiController]
    public class MovieManagementController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieManagementController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: v1/MovieManagement
        [HttpGet("v1/[controller]")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            return Ok(await _movieService.GetAllMoviesAsync());
        }

        // GET: v1/MovieManagement/5
        [HttpGet("v1/[controller]/{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            return Ok(await _movieService.GetMovieByIdAsync(id));
        }

        // PUT: v1/MovieManagement/5
        [HttpPut("v1/[controller]")]
        public async Task<IActionResult> UpdateMovie(MovieDto movie)
        {
            return Ok(await _movieService.UpdateMovieAsync(movie));
        }

        // POST: v1/MovieManagement
        [HttpPost("v1/[controller]")]
        public async Task<ActionResult<MovieDto>> AddMovie(CreateMovieDto movie)
        {
            var id = await _movieService.AddMovieAsync(movie);
            return CreatedAtAction("GetMovie", new { id }, movie);
        }

        // DELETE: v1/MovieManagement/5
        [HttpDelete("v1/[controller]/{id}")]
        public async Task<ActionResult<MovieDto>> DeleteMovie(int id)
        {
            return Ok(await _movieService.DeleteMovieAsync(id));
        }

        // GET: v1/CategoryManagement/5
        [HttpGet("v1/Movie/Filter", Name = "Filter")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> Filter(
            [FromQuery] string text,
            [FromQuery] int[]? categoryIds,
            [FromQuery] decimal? minImdb,
            [FromQuery] decimal? maxImdb,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var dto = new MovieFiltersDto()
            {
                CategoryIds = categoryIds?.ToList(),
                MinImdb = minImdb,
                MaxImdb = maxImdb,
                Text = text,
                Page = page,
                PageSize = pageSize
            };

            return Ok(await _movieService.GetFilteredMoviesAsync(dto));
        }
    }
}