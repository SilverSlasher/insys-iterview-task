using MovieLibrary.Core.Dtos.Movies;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Data.Dtos.Movies
{
    public class MovieDto : CreateMovieDto
    {
        [Required] public int Id { get; set; }
    }
}