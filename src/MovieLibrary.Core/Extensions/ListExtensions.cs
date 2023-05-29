using System.Collections;

namespace MovieLibrary.Core.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty(this IList list) => list is null || list.Count == 0;
    }
}