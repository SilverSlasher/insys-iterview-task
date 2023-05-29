using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories.Categories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly MovieLibraryContext _context;

        public CategoryRepository(MovieLibraryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync() => await GetAllEntitiesAsync();

        public async Task<Category> GetCategoryByIdAsync(int id) => await GetEntityByIdAsync(id);

        public async Task<int> AddCategoryAsync(Category category) => await AddEntityAsync(category);

        public async Task<int> UpdateCategoryAsync(Category category) => await UpdateEntityAsync(category);

        public async Task<int> DeleteCategoryAsync(int id) => await DeleteEntityAsync(id);
    }
}