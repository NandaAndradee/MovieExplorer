using MovieExplorer.Data.Repository;
using MovieExplorer.Domain.Interfaces;
using MovieExplorer.Service.Interfaces;
using MovieExplorer.Service.Services;

namespace MovieExplorer.Web.Configuration
{
    public static class IoCConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
        }
    }
}
