using UrlShortener.Application.Interfaces;
using UrlShortener.API.MapperProfiles;
using UrlShortener.Application.Implementations;


namespace UrlShortener.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            
            services.AddScoped<IUrlService, UrlService>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }

}
