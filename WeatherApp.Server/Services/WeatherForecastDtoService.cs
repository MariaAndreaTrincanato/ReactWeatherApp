using WeatherApp.Domain.Services;
using WeatherApp.Server.Dtos;
using WeatherApp.Server.Extensions;

namespace WeatherApp.Server.Services;

public class WeatherForecastDtoService
{
    public IWeatherForecastService _weatherForecastService;
    
    public WeatherForecastDtoService(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    public async Task<WeatherDto> GetWeatherAsync(string cityName, string units)
    {
        var response = await _weatherForecastService.GetWeatherAsync(cityName, units);
        ArgumentNullException.ThrowIfNull(response, nameof(response));
        return response.MapToWeatherDto();
    }
    
    public async Task<ForecastDto> GetForecastAsync(long id, string units)
    {
        var response = await _weatherForecastService.GetForecastAsync(id, units);
        ArgumentNullException.ThrowIfNull(response, nameof(response));
        return response.MapToForecastDto();
    }
}
