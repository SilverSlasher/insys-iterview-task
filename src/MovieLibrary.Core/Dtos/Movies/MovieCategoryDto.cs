﻿using MovieLibrary.Core.Dtos.Categories;
using System.Collections.Generic;

namespace MovieLibrary.Core.Dtos.Movies
{
    public class MovieCategoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public decimal ImdbRating { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
    }
}