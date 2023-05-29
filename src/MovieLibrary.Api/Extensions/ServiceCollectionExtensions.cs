using Microsoft.Extensions.DependencyInjection;
using MovieLibrary.Api.Middlewares;
using MovieLibrary.Core.Services.Categories;
using MovieLibrary.Core.Services.Movies;
using MovieLibrary.Data.Repositories.Categories;
using MovieLibrary.Data.Repositories.Movies;

namespace MovieLibrary.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void SetDefaultDependencies(this IServiceCollection serviceCollection)
        {
            SetRepositories(serviceCollection);
            SetServices(serviceCollection);
            SetMiddlewares(serviceCollection);
        }

        private static void SetRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        private static void SetServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMovieService, MovieService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
        }

        private static void SetMiddlewares(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ExceptionHandlingMiddleware>();
        }
    }
}