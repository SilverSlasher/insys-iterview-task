using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Core.Dtos.Categories
{
    public class CategoryDto : CreateCategoryDto
    {
        [Required] public int Id { get; set; }
    }
}