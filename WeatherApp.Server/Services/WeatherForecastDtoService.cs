using WeatherApp.Core.Interfaces;
using WeatherApp.Domain.Services;
using WeatherApp.Server.Dtos;
using WeatherApp.Server.Extensions;

namespace WeatherApp.Server.Services;

public class WeatherForecastDtoService
{
    public IWeatherForecastService _weatherForecastService;
    public IAppSettings _settings;
    
    public WeatherForecastDtoService(
        IWeatherForecastService weatherForecastService,
        IAppSettings settings)
    {
        _weatherForecastService = weatherForecastService;
        _settings = settings;
    }

    public async Task<WeatherDto> GetWeatherAsync(string cityName, string units)
    {
        var response = await _weatherForecastService.GetWeatherAsync(cityName, units);
        ArgumentNullException.ThrowIfNull(response, nameof(response));
        return response.MapToWeatherDto(_settings.IconsUrl);
    }
    
    public async Task<ForecastDto> GetForecastAsync(string cityName, string units)
    {
        var response = await _weatherForecastService.GetForecastAsync(cityName, units);
        ArgumentNullException.ThrowIfNull(response, nameof(response));
        return response.MapToForecastDto(_settings.IconsUrl);
    }
}
