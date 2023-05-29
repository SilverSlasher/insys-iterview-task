using Moq;
using MovieLibrary.Core.Dtos.Categories;
using MovieLibrary.Core.Mappers;
using MovieLibrary.Core.Services.Categories;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories.Categories;
using MovieLibrary.UnitTests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MovieLibrary.Tests.ServiceTests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly CategoryService _categoryService;

        public CategoryServiceTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _categoryService = new CategoryService(_categoryRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllCategoriesAsync_ShouldReturnAllCategories()
        {
            // Arrange
            var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1" },
            new Category { Id = 2, Name = "Category 2" },
            new Category { Id = 3, Name = "Category 3" }
        };
            _categoryRepositoryMock.Setup(repo => repo.GetAllCategoriesAsync()).ReturnsAsync(categories);

            // Act
            var result = await _categoryService.GetAllCategoriesAsync();

            // Assert
            Assert.Equal(categories.Count, result.Count());
            CustomAssert.ValueEqual(categories.Select(c => c.ToCategoryDto()), result);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ExistingId_ShouldReturnCategory()
        {
            // Arrange
            int categoryId = 1;
            var category = new Category { Id = categoryId, Name = "Category 1" };
            _categoryRepositoryMock.Setup(repo => repo.GetCategoryByIdAsync(categoryId)).ReturnsAsync(category);

            // Act
            var result = await _categoryService.GetCategoryByIdAsync(categoryId);

            // Assert
            CustomAssert.ValueEqual(category.ToCategoryDto(), result);
        }

        [Fact]
        public async Task AddCategoryAsync_ShouldReturnAddedCategoryId()
        {
            // Arrange
            var categoryToCreate = new CreateCategoryDto { Name = "New Category" };
            int addedCategoryId = 1;
            _categoryRepositoryMock.Setup(repo => repo.AddCategoryAsync(It.IsAny<Category>())).ReturnsAsync(addedCategoryId);

            // Act
            var result = await _categoryService.AddCategoryAsync(categoryToCreate);

            // Assert
            Assert.Equal(addedCategoryId, result);
        }

        [Fact]
        public async Task UpdateCategoryAsync_ShouldReturnNumberOfUpdatedCategories()
        {
            // Arrange
            var categoryToUpdate = new CategoryDto { Id = 1, Name = "Updated Category" };
            int numberOfUpdatedCategories = 1;
            _categoryRepositoryMock.Setup(repo => repo.UpdateCategoryAsync(It.IsAny<Category>())).ReturnsAsync(numberOfUpdatedCategories);

            // Act
            var result = await _categoryService.UpdateCategoryAsync(categoryToUpdate);

            // Assert
            Assert.Equal(numberOfUpdatedCategories, result);
        }

        [Fact]
        public async Task DeleteCategoryAsync_ShouldReturnNumberOfDeletedCategories()
        {
            // Arrange
            int categoryId = 1;
            int numberOfDeletedCategories = 1;
            _categoryRepositoryMock.Setup(repo => repo.DeleteCategoryAsync(categoryId)).ReturnsAsync(numberOfDeletedCategories);

            // Act
            var result = await _categoryService.DeleteCategoryAsync(categoryId);

            // Assert
            Assert.Equal(numberOfDeletedCategories, result);
        }
    }
}