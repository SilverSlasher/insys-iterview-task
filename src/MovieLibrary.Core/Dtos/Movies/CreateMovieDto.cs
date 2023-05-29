using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Core.Dtos.Movies
{
    public class CreateMovieDto
    {
        [Required] public string Title { get; set; }

        [Required] public string Description { get; set; }

        [Required] public int Year { get; set; }

        [Required] public decimal ImdbRating { get; set; }
    }
}