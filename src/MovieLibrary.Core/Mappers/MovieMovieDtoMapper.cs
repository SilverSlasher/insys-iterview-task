using MovieLibrary.Core.Dtos.Movies;
using MovieLibrary.Data.Dtos.Movies;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Mappers
{
    public static class MovieMovieDtoMapper
    {
        public static Movie ToMovie(this MovieDto dto)
        {
            return new Movie
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Year = dto.Year,
                ImdbRating = dto.ImdbRating,
            };
        }

        public static Movie ToMovie(this CreateMovieDto dto)
        {
            return new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                Year = dto.Year,
                ImdbRating = dto.ImdbRating,
            };
        }

        public static MovieDto ToMovieDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                ImdbRating = movie.ImdbRating,
            };
        }
    }
}