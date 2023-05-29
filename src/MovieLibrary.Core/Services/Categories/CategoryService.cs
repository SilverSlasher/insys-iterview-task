using MovieLibrary.Core.Dtos.Categories;
using MovieLibrary.Core.Mappers;
using MovieLibrary.Data.Repositories.Categories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync() => (await _categoryRepository.GetAllCategoriesAsync()).Select(x => x.ToCategoryDto());

        public async Task<CategoryDto> GetCategoryByIdAsync(int id) => (await _categoryRepository.GetCategoryByIdAsync(id)).ToCategoryDto();

        public async Task<int> AddCategoryAsync(CreateCategoryDto category) => await _categoryRepository.AddCategoryAsync(category.ToCategory());

        public async Task<int> UpdateCategoryAsync(CategoryDto category) => await _categoryRepository.UpdateCategoryAsync(category.ToCategory());

        public async Task<int> DeleteCategoryAsync(int id) => await _categoryRepository.DeleteCategoryAsync(id);
    }
}