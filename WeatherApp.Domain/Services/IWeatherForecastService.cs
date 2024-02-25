using WeatherApp.Domain.Entities;

namespace WeatherApp.Domain.Services;

public interface IWeatherForecastService
{
    Task<WeatherResponse?> GetWeatherAsync(string cityName, string units);
    Task<ForecastResponse?> GetForecastAsync(string cityName, string units);
}