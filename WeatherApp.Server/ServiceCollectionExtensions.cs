using WeatherApp.Server.Services;

namespace WeatherApp.Server;

public static class ServiceCollectionExtensions
{
    // , IConfiguration configuration
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddTransient<WeatherForecastDtoService>();
    }
}