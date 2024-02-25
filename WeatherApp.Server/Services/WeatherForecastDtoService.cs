using WeatherApp.Domain.Services;
using WeatherApp.Server.Dtos;

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
        var ret = new WeatherDto();

        var response = await _weatherForecastService.GetWeatherAsync(cityName, units);
        // map to dto
        
        return ret;
    }
    
    public async Task<ForecastDto> GetForecastAsync(long id, string units)
    {
        var ret = new ForecastDto();

        var response = await _weatherForecastService.GetForecastAsync(id, units);
        // map to dto
        
        return ret;
    }
}
