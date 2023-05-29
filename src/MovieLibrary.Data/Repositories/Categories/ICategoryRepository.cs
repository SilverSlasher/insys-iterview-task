using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<int> AddCategoryAsync(Category movie);
        Task<int> UpdateCategoryAsync(Category movie);
        Task<int> DeleteCategoryAsync(int id);
    }
}