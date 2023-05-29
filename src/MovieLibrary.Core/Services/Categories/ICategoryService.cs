using MovieLibrary.Core.Dtos.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

        Task<CategoryDto> GetCategoryByIdAsync(int id);

        Task<int> AddCategoryAsync(CreateCategoryDto movie);

        Task<int> UpdateCategoryAsync(CategoryDto movie);

        Task<int> DeleteCategoryAsync(int id);
    }
}