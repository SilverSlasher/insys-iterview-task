using MovieLibrary.Core.Dtos.Movies;
using MovieLibrary.Data.Entities;
using System.Linq;

namespace MovieLibrary.Core.Mappers
{
    public static class MovieMovieCategoryDtoMapper
    {
        public static MovieCategoryDto ToMovieWithCategoriesDto(this Movie movie)
        {
            return new MovieCategoryDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                ImdbRating = movie.ImdbRating,
                Categories = movie?.MovieCategories
                    .Select(x => x.Category.ToCategoryDto())
                    .ToList()
            };
        }
    }
}