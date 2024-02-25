using WeatherApp.Domain.Entities;

namespace WeatherApp.Domain.Services;

public interface IWeatherForecastService
{
    Task<ForecastResponse?> GetWeatherForecast(string cityName, string units);
}