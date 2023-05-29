using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Core.Dtos.Categories
{
    public class CreateCategoryDto
    {
        [Required] public string Name { get; set; }
    }
}