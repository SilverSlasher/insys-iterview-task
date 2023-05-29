using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Dtos.Categories;
using MovieLibrary.Core.Services.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CategoryManagementController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryManagementController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/CategoryManagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        // GET: api/CategoryManagement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            return Ok(await _categoryService.GetCategoryByIdAsync(id));
        }

        // PUT: api/CategoryManagement/5
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto category)
        {
            return Ok(await _categoryService.UpdateCategoryAsync(category));
        }

        // POST: api/CategoryManagement
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddCategory(CreateCategoryDto category)
        {
            var id = await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction("GetCategory", new { id }, category);
        }

        // DELETE: api/CategoryManagement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDto>> DeleteCategory(int id)
        {
            return Ok(await _categoryService.DeleteCategoryAsync(id));
        }
    }
}