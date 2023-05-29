using System.Collections.Generic;

namespace MovieLibrary.Data.Dtos.Movies
{
    public class MovieFiltersDto
    {
        public string Text { get; set; }
        public List<int> CategoryIds { get; set; }
        public decimal? MinImdb { get; set; }
        public decimal? MaxImdb { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}