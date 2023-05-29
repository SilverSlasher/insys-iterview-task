using MovieLibrary.Core.Dtos.Categories;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Mappers
{
    public static class CategoryCategoryDtoMapper
    {
        public static Category ToCategory(this CategoryDto dto)
        {
            return new Category()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static Category ToCategory(this CreateCategoryDto dto)
        {
            return new Category()
            {
                Name = dto.Name
            };
        }

        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}