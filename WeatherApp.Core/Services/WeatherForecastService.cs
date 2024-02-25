using WeatherApp.Core.Constants;
using WeatherApp.Core.Helpers;
using WeatherApp.Core.Interfaces;
using WeatherApp.Domain.Entities;
using WeatherApp.Domain.Http;
using WeatherApp.Domain.Services;

namespace WeatherApp.Core.Services;

public class WeatherForecastService : IWeatherForecastService
{
    public IAppSettings _appSettings;
    public IHttpClientFactory _httpClientFactory;
    
    public WeatherForecastService(
        IAppSettings settings,
        IHttpClientFactory httpClientFactory)
    {
        _appSettings = settings;
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<WeatherResponse?> GetWeatherAsync(string cityName, string units = DataConst.DefaultUnits)
    {
        var uri = UriHelper.BuildWeatherUri(_appSettings, cityName, units);
        var client = new WeatherClient(_httpClientFactory.CreateClient(), uri);
        return await client.GetWeather();
    }

    public async Task<ForecastResponse?> GetForecastAsync(long id, string units = DataConst.DefaultUnits)
    {
        var uri = UriHelper.BuildForecastUri(_appSettings, id, units);
        var client = new WeatherClient(_httpClientFactory.CreateClient(), uri);
        return await client.GetForecast();
    }
}
