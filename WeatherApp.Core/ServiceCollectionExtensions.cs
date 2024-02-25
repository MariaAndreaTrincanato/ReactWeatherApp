using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Core.Services;
using WeatherApp.Domain.Services;

namespace WeatherApp.Core;

public static class ServiceCollectionExtensions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IWeatherForecastService, WeatherForecastService>();
    }
}